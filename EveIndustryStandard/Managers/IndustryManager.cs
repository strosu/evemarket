using EveIndustry.Client;
using EveIndustry.Models;
using EveIndustryStandard.Strategies;
using IO.Swagger.Api;
using System.Collections.Generic;
using System.Threading.Tasks;
using EveIndustry.Services;

namespace EveIndustryStandard.Managers
{
    public class IndustryManager
    {
        private readonly Dictionary<int, Item> _itemCache = new Dictionary<int, Item>();
        private readonly ItemFactory _itemFactory;
        
        private IndustryManager(Dictionary<int, double> destinationBuyPrices, Dictionary<int, double> destinationSellPrices, BlueprintService blueprintService)
        {
            _itemFactory = new ItemFactory(destinationSellPrices, destinationBuyPrices, blueprintService);
        }

        public static async Task<IndustryManager> Create(bool refreshCitadelData)
        {
            await ClientManager.Build();
            var marketApi = new MarketApi();
            var orders = await CitadelOrdersManager.InitializeCitadelOrders(refreshCitadelData, marketApi);
            var manager = new IndustryManager(orders.Item2, orders.Item1, new BlueprintService(new BlueprintManager(), new ItemManager()));
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
    }
}