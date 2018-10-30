using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EveClientStandard.Extensions;
using EveIndustry;
using EveIndustry.Client;
using EveIndustry.Models;
using IO.Swagger.Api;
using IO.Swagger.Model;
using Newtonsoft.Json;

namespace EveIndustryStandard.Managers
{
    public class IndustryManager
    {
        private CharInfo _charInfo;
        private MarketApi _marketApi;
        private Dictionary<int, MarketItem> _marketItems;
        private Dictionary<int, BlueprintCopy> _bpcs;
        private LazyAsync<List<GetMarketsStructuresStructureId200Ok>> _destinationOrders;
        private Dictionary<int, double> _destinationBuyPrices = new Dictionary<int, double>();
        private Dictionary<int, double> _destinationSellPrices = new Dictionary<int, double>();
        private Dictionary<int, ItemPrice> _itemPriceCache = new Dictionary<int, ItemPrice>();
        private Dictionary<int, Item> _itemCache = new Dictionary<int, Item>();

        private List<int> _highValueItems = new List<int>();

        private IndustryManager()
        {
            _marketItems = ItemManager.GetMarketItems();
            _bpcs = BlueprintManager.GetBlueprints();
            _marketApi = new MarketApi();
        }

        public static async Task<IndustryManager> Create()
        {
            await ClientManager.Build();
            var manager = new IndustryManager();
            await manager.InitializeCitadelOrders();
            // await manager.InitializeSourceAndDestContracts();
            return manager;
        }

        #region sellable - move

        public async Task GetPotentialItems(int regionId, int daysToEvaluate, int minAverageVolumePerDay, int minOrdersPerDay)
        {
            var sellable = await GetSellableItems(regionId, daysToEvaluate, minAverageVolumePerDay, minOrdersPerDay);
        }

        private async Task<ConcurrentBag<MarketItem>> GetSellableItems(int regionId, int daysToEvaluate, int minAverageVolumePerDay, int minOrdersPerDay)
        {
            var result = new ConcurrentBag<MarketItem>();

            var tasks = _marketItems.Select(async item =>
            {
                if (await HasMarket(item.Value, regionId, daysToEvaluate, minAverageVolumePerDay, minOrdersPerDay))
                {
                    result.Add(item.Value);
                };
            });

            await Task.WhenAll(tasks);
            return result;
        }

        private async Task<bool> HasMarket(MarketItem marketItem, int regionId, int daysToEvaluate, int minAverageVolumePerDay, int minOrdersPerDay)
        {
            try
            {
                var orders = (await _marketApi.GetMarketsRegionIdHistoryAsync(regionId, marketItem.Id)).OrderByDescending(x => x.Date)
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

        public async Task<List<ItemPrice>> ComputeCurrentPrices(int buyRegionId)
        {
            var tasks = _marketItems.Values.Select(item => ComputePrice(item.Id, buyRegionId, 30000142));
            return (await Task.WhenAll(tasks)).ToList();
        }

        public async Task<ItemPrice> ComputePrice(int itemId, int buyRegion, int buySystemId)
        {
            if (_itemPriceCache.ContainsKey(itemId))
            {
                return _itemPriceCache[itemId];
            }

            var itemName = _marketItems[itemId].Name;
            var bpcItemId = GetBpcItemId(itemName);

            var zz = new ItemPrice()
            {
                ItemId = itemId,
                JitaSellPrice = await GetPriceForItemInRegion(itemId, buyRegion, buySystemId),
                OneDqSellPrice = GetSellPriceForItemAtDestination(itemId),
                OneDqBuyPrice = GetBuyPriceForItemAtDestination(itemId),
                Blueprint = bpcItemId != null ? _bpcs[bpcItemId.Value] : null,
                Components = bpcItemId != null ?
                    _bpcs[bpcItemId.Value].UnresearchedRequiredComponentsForSingleRun.Select(
                        x => new ItemPriceWithAmount()
                        {
                            Item = ComputePrice(x.Id, buyRegion, buySystemId).Result,
                            Amount = GetRequiredComponents(bpcItemId.Value, x.Id)
                        }).ToList()
                    : null,
                MaxRunsPerBpc = bpcItemId != null ? (int?)_bpcs[bpcItemId.Value].MaxRuns : null,
                InstallCost = bpcItemId != null ? (double?)MaterialsManager.GetInstallCost(_bpcs[bpcItemId.Value]) : null
            };

            _itemPriceCache.Add(itemId, zz);

            return zz;
        }

        public async Task<Item> ComputePrice2(int itemId, int buyRegion, int buySystemId)
        {
            if (_itemCache.ContainsKey(itemId))
            {
                return _itemCache[itemId];
            }

            var itemName = _marketItems[itemId].Name;
            var bpcItemId = GetBpcItemId(itemName);
            var bpc = bpcItemId != null ? _bpcs[bpcItemId.Value] : null;

            var zz = new Item()
                {
                    Id = itemId,

                }
                .WithOneDqBuildStrategy(bpc)
                .WithOneDqBuyStategy(_destinationSellPrices)
                .Build();

            _itemCache.Add(itemId, zz);

            return zz;
        }

        private int? GetBpcItemId(string itemName)
        {
            return _marketItems.Values.FirstOrDefault(x => x.Name == itemName + " Blueprint")?.Id;
        }

        private int GetRequiredComponents(int bpcId, int componentTypeId)
        {
            var multiplier = 0.853578;
            return (int)Math.Ceiling(_bpcs[bpcId].UnresearchedRequiredComponentsForSingleRun.FirstOrDefault(x => x.Id == componentTypeId).Amount * multiplier);
        }

        private async Task InitializeCitadelOrders()
        {
            // var structureId = new SearchApi().GetCharactersCharacterIdSearchWithHttpInfo(new List<string>() { "structure" }, _charInfo.CharacterID, "1DQ");

            // home
            // var filePath = @"D:\git\EveMarket\EveIndustryStandard\Resources\onedq.json";

            var filePath = @"C:\work\git\evemarket\EveIndustryStandard\Resources\onedq.json";

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
                (await GetCitadelSellOrders()).ApplyOrdersMapping(list => list.Min(x => x.Price.Value));

            _destinationBuyPrices = (await GetCitadelBuyOrders()).ApplyOrdersMapping(list => list.Max(x => x.Price.Value));
        }

        private async Task<IEnumerable<GetMarketsStructuresStructureId200Ok>> GetCitadelBuyOrders()
        {
            return (await _destinationOrders.Value).Where(x => x.IsBuyOrder.Value);
        }

        private async Task<IEnumerable<GetMarketsStructuresStructureId200Ok>> GetCitadelSellOrders()
        {
            return (await _destinationOrders.Value).Where(x => !x.IsBuyOrder.Value);
        }

        private double GetSellPriceForItemAtDestination(int itemId)
        {
            return _destinationSellPrices.ContainsKey(itemId) ? _destinationSellPrices[itemId] : double.MaxValue;
        }

        private double GetBuyPriceForItemAtDestination(int itemId)
        {
            return _destinationBuyPrices.ContainsKey(itemId) ? _destinationBuyPrices[itemId] : double.MaxValue;
        }

        private async Task<double> GetPriceForItemInRegion(int itemId, int regionId, int systemId)
        {
            var sellOrders = await ApiExtension.GetAll(index =>
                _marketApi.GetMarketsRegionIdOrdersAsyncWithHttpInfo("sell", regionId, "tranquility", typeId: itemId, page: index));

            // var sellOrders = await GetAllOrders(itemId, regionId);
            var minPrice = sellOrders.Where(x => x.SystemId == systemId).OrderBy(x => x.Price).FirstOrDefault();
            var price = minPrice?.Price ?? double.MaxValue;
            return price;
        }
    }
}