using EveIndustryStandard.Managers;
using EveIndustryStandard.Models;
using EveIndustryStandard.Strategies;
using IO.Swagger.Api;
using System.Collections.Generic;
using System.Threading.Tasks;
using EveIndustryStandard.Client;

namespace EveIndustryStandard.Services
{
    public class IndustryService
    {
        private readonly Dictionary<int, Item> _itemCache = new Dictionary<int, Item>();
        private readonly ItemFactory _itemFactory;
        
        private IndustryService(CitadelOrdersManager citadelOrdersManager, BlueprintService blueprintService, ItemManager itemManager)
        {
            _itemFactory = new ItemFactory(citadelOrdersManager, blueprintService, itemManager);
        }

        public static async Task<IndustryService> Create(bool refreshCitadelData)
        {
            await ClientManager.Build();
            var marketApi = new MarketApi();
            var citadelManager = await CitadelOrdersManager.BuildCitadelManager(marketApi, refreshCitadelData);
            var itemManager = new ItemManager();
            return new IndustryService(citadelManager, new BlueprintService(new BlueprintManager(), itemManager), itemManager);
        }

        /// <summary>
        /// Entry point for computing prices, strategies etc
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="amount"></param>
        /// <param name="buyRegion"></param>
        /// <param name="buySystemId"></param>
        /// <returns></returns>
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