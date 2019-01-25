using EveIndustryStandard.Managers;
using EveIndustryStandard.Managers.Market;
using EveIndustryStandard.Models;
using EveIndustryStandard.Services;
using System;
using System.Threading.Tasks;

namespace EveIndustryStandard.Strategies
{
    /// <summary>
    /// Handles the strategy configurations
    /// </summary>
    public class ItemFactory
    {
        private readonly CitadelObtainer _citadelObtainer;
        private readonly BlueprintService _blueprintService;
        private readonly Func<int, string> _getItemNameFunc;
        private readonly Func<string, int> _getItemIdFunc;
        private readonly MaterialsService _materialsService;

        public ItemFactory(CitadelObtainer citadelObtainer, BlueprintService blueprintService, Func<int, string> getItemNameFunc, Func<string, int> getItemIdFunc, MaterialsService materialsService)
        {
            _citadelObtainer = citadelObtainer;
            _blueprintService = blueprintService;
            _getItemNameFunc = getItemNameFunc;
            _getItemIdFunc = getItemIdFunc;
            _materialsService = materialsService;
        }

        public async Task<Item> BuildAsync(string itemName, int amount)
        {
            return await BuildAsync(_getItemIdFunc(itemName), amount);
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
                .WithOneDqBuyStrategy(_citadelObtainer)
                .BuildAsync();
        }
    }
}
