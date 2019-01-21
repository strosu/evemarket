using System;
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
        
        private IndustryService(CitadelOrdersManager citadelOrdersManager, BlueprintService blueprintService, Func<int, string> getItemNameFunc, MaterialsService materialsService)
        {
            _itemFactory = new ItemFactory(citadelOrdersManager, blueprintService, getItemNameFunc, materialsService);
        }

        public static async Task<IndustryService> CreateAsync(bool refreshCitadelData)
        {
            await ClientManager.Build();
            var marketApi = new MarketApi();
            var citadelManager = await CitadelOrdersManager.BuildAsync(marketApi, refreshCitadelData);
            var itemManager = new ItemManager();
            return new IndustryService(citadelManager, new BlueprintService(new BlueprintManager(), itemManager), itemManager.GetItemName, new MaterialsService());
        }

        /// <summary>
        /// Entry point for computing prices, strategies etc
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public async Task<Item> ComputePriceAsync(int itemId, int amount)
        {
            if (_itemCache.ContainsKey(itemId))
            {
                return _itemCache[itemId];
            }

            var currentItem = await _itemFactory.BuildAsync(itemId, amount);

            _itemCache.Add(itemId, currentItem);

            return currentItem;
        }
    }
}