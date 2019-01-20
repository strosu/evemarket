using EveIndustry.Models;
using System.Collections.Generic;
using EveIndustryStandard.Managers;
using EveIndustry.Services;

namespace EveIndustryStandard.Strategies
{
    public class ItemFactory
    {
        private readonly Dictionary<int, double> _destinationSellPrices;
        private readonly Dictionary<int, double> _destinationBuyPrices;
        private readonly BlueprintService _blueprintService;

        public ItemFactory(Dictionary<int, double> destinationSellPrices, Dictionary<int, double> destinationBuyPrices, BlueprintService blueprintService)
        {
            _destinationSellPrices = destinationSellPrices;
            _destinationBuyPrices = destinationBuyPrices;
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
                .WithOneDqBuyStrategy(_destinationSellPrices)
                .Build();
        }
    }
}
