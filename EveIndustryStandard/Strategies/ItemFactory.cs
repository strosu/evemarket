using EveIndustry.Models;
using System.Collections.Generic;
using EveIndustryStandard.Managers;
using EveIndustryStandard.Services;

namespace EveIndustryStandard.Strategies
{
    public class ItemFactory
    {
        private readonly CitadelOrdersManager _citadelOrdersManager;
        private readonly BlueprintService _blueprintService;

        public ItemFactory(CitadelOrdersManager citadelOrdersManager, BlueprintService blueprintService)
        {
            _citadelOrdersManager = citadelOrdersManager;
            _blueprintService = blueprintService;
        }

        public Item Build(int itemId, int amount)
        {
            return new Item()
                {
                    Id = itemId,
                    Amount = amount
                }
                .WithOneDqBuildStrategy(this, _blueprintService)
                .WithOneDqBuyStrategy(_citadelOrdersManager.DestinationSellPrices)
                .Build();
        }
    }
}
