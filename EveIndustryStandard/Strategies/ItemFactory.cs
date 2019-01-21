using System;
using System.Threading.Tasks;
using EveIndustryStandard.Managers;
using EveIndustryStandard.Models;
using EveIndustryStandard.Services;

namespace EveIndustryStandard.Strategies
{
    public class ItemFactory
    {
        private readonly CitadelOrdersManager _citadelOrdersManager;
        private readonly BlueprintService _blueprintService;
        private readonly Func<int, string> _getItemNameFunc;
        private readonly MaterialsService _materialsService;

        public ItemFactory(CitadelOrdersManager citadelOrdersManager, BlueprintService blueprintService, Func<int, string> getItemNameFunc, MaterialsService materialsService)
        {
            _citadelOrdersManager = citadelOrdersManager;
            _blueprintService = blueprintService;
            _getItemNameFunc = getItemNameFunc;
            _materialsService = materialsService;
        }

        public async Task<Item> BuildAsync(int itemId, int amount)
        {
            return await new Item
                {
                    Id = itemId,
                    Amount = amount,
                    ItemName = _getItemNameFunc(itemId)
                }
                .WithOneDqBuildStrategy(BuildAsync, _blueprintService, _materialsService)
                .WithOneDqBuyStrategy(_citadelOrdersManager.DestinationSellPrices)
                .BuildAsync();
        }
    }
}
