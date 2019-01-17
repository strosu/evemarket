using EveIndustry.Client;
using EveIndustry.Models;
using EveIndustryStandard.Strategies;
using IO.Swagger.Api;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EveIndustryStandard.Managers
{
    public class IndustryManager
    {
        private readonly Dictionary<int, Item> _itemCache = new Dictionary<int, Item>();
        private readonly ItemFactory _itemFactory;
        
        private IndustryManager(Dictionary<int, double> destinationBuyPrices, Dictionary<int, double> destinationSellPrices, MarketApi marketApi)
        {
            _itemFactory = new ItemFactory(ItemManager.GetMarketItems(), BlueprintManager.GetBlueprints(), destinationSellPrices, destinationBuyPrices);
        }

        public static async Task<IndustryManager> Create(bool refreshCitadelData)
        {
            await ClientManager.Build();
            var marketApi = new MarketApi();
            var orders = await CitadelOrdersManager.InitializeCitadelOrders(refreshCitadelData, marketApi);
            var manager = new IndustryManager(orders.Item2, orders.Item1, marketApi);
            return manager;
        }

        public Item ComputePrice2(int itemId, int amount, int buyRegion, int buySystemId)
        {
            if (_itemCache.ContainsKey(itemId))
            {
                return _itemCache[itemId];
            }

            var currentItem = _itemFactory.Build(itemId, amount);

            _itemCache.Add(itemId, currentItem);

            return currentItem;
        }
        
        //private double GetSellPriceForItemAtDestination(int itemId)
        //{
        //    return _destinationSellPrices.ContainsKey(itemId) ? _destinationSellPrices[itemId] : double.MaxValue;
        //}

        //private double GetBuyPriceForItemAtDestination(int itemId)
        //{
        //    return _destinationBuyPrices.ContainsKey(itemId) ? _destinationBuyPrices[itemId] : double.MaxValue;
        //}

        //private async Task<double> GetPriceForItemInRegion(int itemId, int regionId, int systemId)
        //{
        //    var sellOrders = await ApiExtension.GetAll(index =>
        //        _marketApi.GetMarketsRegionIdOrdersAsyncWithHttpInfo("sell", regionId, "tranquility", typeId: itemId, page: index));

        //    // var sellOrders = await GetAllOrders(itemId, regionId);
        //    var minPrice = sellOrders.Where(x => x.SystemId == systemId).OrderBy(x => x.Price).FirstOrDefault();
        //    var price = minPrice?.Price ?? double.MaxValue;
        //    return price;
        //}

        //public async Task<List<ItemPrice>> ComputeCurrentPrices(int buyRegionId)
        //{
        //    var tasks = _marketItems.Values.Select(item => ComputePrice(item.Id, buyRegionId, 30000142));
        //    return (await Task.WhenAll(tasks)).ToList();
        //}

        //public async Task<ItemPrice> ComputePrice(int itemId, int buyRegion, int buySystemId)
        //{
        //    if (_itemPriceCache.ContainsKey(itemId))
        //    {
        //        return _itemPriceCache[itemId];
        //    }

        //    var itemName = _marketItems[itemId].Name;
        //    var bpcItemId = GetBpcItemId(itemName);

        //    var zz = new ItemPrice()
        //    {
        //        ItemId = itemId,
        //        JitaSellPrice = await GetPriceForItemInRegion(itemId, buyRegion, buySystemId),
        //        OneDqSellPrice = GetSellPriceForItemAtDestination(itemId),
        //        OneDqBuyPrice = GetBuyPriceForItemAtDestination(itemId),
        //        Blueprint = bpcItemId != null ? _bpcs[bpcItemId.Value] : null,
        //        Components = bpcItemId != null ?
        //            _bpcs[bpcItemId.Value].UnresearchedRequiredComponentsForSingleRun.Select(
        //                x => new ItemPriceWithAmount()
        //                {
        //                    Item = ComputePrice(x.Id, buyRegion, buySystemId).Result,
        //                    Amount = GetRequiredComponents(bpcItemId.Value, x.Id)
        //                }).ToList()
        //            : null,
        //        MaxRunsPerBpc = bpcItemId != null ? (int?)_bpcs[bpcItemId.Value].MaxRuns : null,
        //        InstallCost = bpcItemId != null ? (double?)MaterialsManager.GetInstallCost(_bpcs[bpcItemId.Value]) : null
        //    };

        //    _itemPriceCache.Add(itemId, zz);

        //    return zz;
        //}
    }
}