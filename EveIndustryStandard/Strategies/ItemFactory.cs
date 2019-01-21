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
        private readonly ItemManager _itemManager;

        public ItemFactory(CitadelOrdersManager citadelOrdersManager, BlueprintService blueprintService, ItemManager itemManager)
        {
            _citadelOrdersManager = citadelOrdersManager;
            _blueprintService = blueprintService;
            _itemManager = itemManager;
        }

        public async Task<Item> BuildAsync(int itemId, int amount)
        {
            return await new Item
                {
                    Id = itemId,
                    Amount = amount,
                    ItemName = _itemManager.GetItemName(itemId)
                }
                .WithOneDqBuildStrategy(this, _blueprintService)
                .WithOneDqBuyStrategy(_citadelOrdersManager.DestinationSellPrices)
                .BuildAsync();
        }
    }
}
