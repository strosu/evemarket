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
    public class ItemFactoryBuilder
    {
        private readonly ItemFactory _itemFactory;
        
        private ItemFactoryBuilder(CitadelOrdersManager citadelOrdersManager, BlueprintService blueprintService, Func<int, string> getItemNameFunc, Func<string, int> getItemIdFunc, MaterialsService materialsService)
        {
            _itemFactory = new ItemFactory(citadelOrdersManager, blueprintService, getItemNameFunc, getItemIdFunc, materialsService);
        }

        public static async Task<ItemFactoryBuilder> CreateAsync(bool refreshCitadelData)
        {
            await ClientManager.Build();
            var marketApi = new MarketApi();
            var citadelManager = await CitadelOrdersManager.BuildAsync(marketApi, refreshCitadelData);
            var itemManager = new GeneralItemManager();
            return new ItemFactoryBuilder(citadelManager, new BlueprintService(new BlueprintManager(), itemManager), itemManager.GetItemName, itemManager.GetItemId, new MaterialsService());
        }

        /// <summary>
        /// Entry point for computing prices, strategies etc
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public async Task<Item> ComputePriceAsync(int itemId, int amount)
        {
            return await _itemFactory.BuildAsync(itemId, amount);
        }

        /// <summary>
        /// Entry point for computing prices, strategies etc
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public async Task<Item> ComputePriceAsync(string itemName, int amount)
        {
            return await _itemFactory.BuildAsync(itemName, amount);
        }
    }
}