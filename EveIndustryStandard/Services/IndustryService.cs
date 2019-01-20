using System.Collections.Generic;
using System.Threading.Tasks;
using EveIndustry.Client;
using EveIndustry.Models;
using EveIndustryStandard.Managers;
using EveIndustryStandard.Strategies;
using IO.Swagger.Api;

namespace EveIndustryStandard.Services
{
    public class IndustryService
    {
        private readonly Dictionary<int, Item> _itemCache = new Dictionary<int, Item>();
        private readonly ItemFactory _itemFactory;
        
        private IndustryService(CitadelOrdersManager citadelOrdersManager, BlueprintService blueprintService)
        {
            _itemFactory = new ItemFactory(citadelOrdersManager, blueprintService);
        }

        public static async Task<IndustryService> Create(bool refreshCitadelData)
        {
            await ClientManager.Build();
            var marketApi = new MarketApi();
            var citadelManager = await CitadelOrdersManager.BuildCitadelManager(marketApi, refreshCitadelData);
            return new IndustryService(citadelManager, new BlueprintService(new BlueprintManager(), new ItemManager()));
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