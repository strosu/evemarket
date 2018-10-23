using System;
using EveClientStandard.Extensions;
using EveIndustry.Client;
using EveIndustry.Models;
using IO.Swagger.Api;
using IO.Swagger.Model;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EveIndustry
{
    public partial class IndustryManager
    {
        private CharInfo _charInfo;
        private MarketApi _marketApi;
        private List<Item> _marketItems;
        private LazyAsync<List<GetMarketsStructuresStructureId200Ok>> _destinationOrders;
        private Dictionary<int, double> _destinationBuyPrices = new Dictionary<int, double>();
        private Dictionary<int, double> _destinationSellPrices = new Dictionary<int, double>();

        private List<int> _highValueItems = new List<int>();

        private IndustryManager()
        {
            _marketItems = ItemManager.GetMarketItems();
        }

        public static async Task<IndustryManager> Create()
        {
            await ClientManager.Build();
            var manager = new IndustryManager();
            manager.Initialize();
            await manager.InitializeCitadelOrders();
            return manager;
        }

        private void Initialize()
        {
            _marketApi = new MarketApi();
        }

        #region sellable - move

        public async Task GetPotentialItems(int regionId, int daysToEvaluate, int minAverageVolumePerDay, int minOrdersPerDay)
        {
            var sellable = await GetSellableItems(regionId, daysToEvaluate, minAverageVolumePerDay, minOrdersPerDay);
        }

        private async Task<ConcurrentBag<Item>> GetSellableItems(int regionId, int daysToEvaluate, int minAverageVolumePerDay, int minOrdersPerDay)
        {
            var result = new ConcurrentBag<Item>();

            var tasks = _marketItems.Select(async item =>
            {
                if (await HasMarket(item, regionId, daysToEvaluate, minAverageVolumePerDay, minOrdersPerDay))
                {
                    result.Add(item);
                };
            });

            await Task.WhenAll(tasks);
            return result;
        }

        private async Task<bool> HasMarket(Item item, int regionId, int daysToEvaluate, int minAverageVolumePerDay, int minOrdersPerDay)
        {
            try
            {
                var orders = (await _marketApi.GetMarketsRegionIdHistoryAsync(regionId, item.Id)).OrderByDescending(x => x.Date)
                    .Take(daysToEvaluate).ToList();

                return AreConsecutiveDays(orders, daysToEvaluate)
                       && GetAverageDailyRevenue(orders) >= minAverageVolumePerDay
                       && HasMinNumberOfOrders(orders, minOrdersPerDay);
            }
            catch
            {
                return false;
            }
        }

        private static bool HasMinNumberOfOrders(List<GetMarketsRegionIdHistory200Ok> orders, int minOrdersPerDay)
        {
            return orders.Average(x => x.OrderCount).Value >= minOrdersPerDay;
        }

        private static bool AreConsecutiveDays(List<GetMarketsRegionIdHistory200Ok> orders, int daysToEvaluate)
        {
            if (orders.Count < daysToEvaluate)
            {
                return false;
            }

            var tmp = orders.First().Date - orders.Last().Date;

            return tmp.Value.TotalDays == daysToEvaluate;
        }

        private static double GetAverageDailyRevenue(List<GetMarketsRegionIdHistory200Ok> orders)
        {
            return orders.Select(x => x.Average * x.Volume).Average().Value;
        }

        #endregion

        public async Task<List<ItemPrice>> ComputeCurrentPrices(int buyRegionId, int sellRegionId)
        {
            var tasks = _marketItems.Select(item => ComputePrice(item.Id, buyRegionId, sellRegionId, 30000142, 30004759));
            return (await Task.WhenAll(tasks)).ToList();
        }

        private async Task<ItemPrice> ComputePrice(int itemId, int buyRegion, int sellRegion, int buySystemId, int sellSystemId)
        {
            return new ItemPrice()
            {
                ItemId = itemId,
                JitaSellPrice = await GetPriceForItemInRegion(itemId, buyRegion, buySystemId),
                OneDqSellPrice= await GetPriceForItemInRegion(itemId, sellRegion, sellSystemId),
            };
        }

        private async Task InitializeCitadelOrders()
        {
            // var structureId = new SearchApi().GetCharactersCharacterIdSearchWithHttpInfo(new List<string>() { "structure" }, _charInfo.CharacterID, "1DQ");

            var filePath = @"D:\git\EveMarket\EveIndustryStandard\Resources\onedq.json";
            //_destinationOrders =
            //    new LazyAsync<List<GetMarketsStructuresStructureId200Ok>>(async () => await ApiExtension.GetAll(
            //        index => _marketApi.GetMarketsStructuresStructureIdAsyncWithHttpInfo(1022734985679, page: index)));
            //File.WriteAllText(filePath, JsonConvert.SerializeObject(await _destinationOrders.Value));

            using (StreamReader file = File.OpenText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();

                _destinationOrders = new LazyAsync<List<GetMarketsStructuresStructureId200Ok>>(async () =>
                    (List<GetMarketsStructuresStructureId200Ok>)serializer.Deserialize(file, typeof(List<GetMarketsStructuresStructureId200Ok>)));
                var tmp = await _destinationOrders.Value;
            }

            _destinationSellPrices =
                ApplyOrdersMapping((await _destinationOrders.Value).Where(x => x.IsBuyOrder.Value == false), list => list.Min(x => x.Price.Value));

            _destinationBuyPrices = ApplyOrdersMapping((await _destinationOrders.Value).Where(x => x.IsBuyOrder.Value), list => list.Max(x => x.Price.Value));
        }

        private Dictionary<int, double> ApplyOrdersMapping(IEnumerable<GetMarketsStructuresStructureId200Ok> filteredOrders, Func<IEnumerable<GetMarketsStructuresStructureId200Ok>, double> func)
        {
            return filteredOrders.GroupBy(x => x.TypeId.Value,
                (key, g) => new { TypeId = key, Prices = g.ToList() }).ToDictionary(x => x.TypeId, x => func(x.Prices));
        }

        private async Task<double> GetPriceForItemInRegion(int itemId, int regionId, int systemId)
        {
            var sellOrders = await ApiExtension.GetAll(index =>
                _marketApi.GetMarketsRegionIdOrdersAsyncWithHttpInfo("sell", regionId, "tranquility", typeId: itemId, page: index));
            
            // var sellOrders = await GetAllOrders(itemId, regionId);
            var minPrice = sellOrders.Where(x => x.SystemId == systemId).OrderBy(x => x.Price).FirstOrDefault();
            return minPrice?.Price ?? double.MaxValue;
        }

        private async Task<List<GetMarketsRegionIdOrders200Ok>> GetAllOrders(int itemId, int regionId)
        {
            var result = await _marketApi.GetMarketsRegionIdOrdersAsyncWithHttpInfo("sell", regionId, "tranquility", typeId: itemId);
            var pages = int.Parse(result.Headers["X-Pages"]);
            var list = result.Data;

            var index = 1;
            while (index < pages)
            {
                index++;
                var currentPageResults =
                    await _marketApi.GetMarketsRegionIdOrdersAsync("sell", regionId, "tranquility", typeId: itemId, page: index);
                list.AddRange(currentPageResults);
            }

            return list;
        }
    }
}