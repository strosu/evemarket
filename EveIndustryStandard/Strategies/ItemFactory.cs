using EveIndustry.Models;
using System.Collections.Generic;
using System.Linq;

namespace EveIndustryStandard.Strategies
{
    public class ItemFactory
    {
        private readonly Dictionary<int, MarketItem> _marketItems;
        private readonly Dictionary<int, BlueprintCopy> _bpcs;
        private readonly Dictionary<int, double> _destinationSellPrices;
        private readonly Dictionary<int, double> _destinationBuyPrices;

        public ItemFactory(Dictionary<int, MarketItem> marketItems, Dictionary<int, BlueprintCopy> bpcs, Dictionary<int, double> destinationSellPrices, Dictionary<int, double> destinationBuyPrices)
        {
            _marketItems = marketItems;
            _bpcs = bpcs;
            _destinationSellPrices = destinationSellPrices;
            _destinationBuyPrices = destinationBuyPrices;
        }

        public Item Build(int itemId)
        {
            var itemName = _marketItems[itemId].Name;
            var bpcItemId = GetBpcItemId(itemName);
            var bpc = bpcItemId != null ? _bpcs[bpcItemId.Value] : null;

            return new Item()
                {
                    Id = itemId,
                    Amount = 1
                }
                .WithOneDqBuildStrategy(bpc)
                .WithOneDqBuyStategy(_destinationSellPrices)
                .Build();
        }

        private int? GetBpcItemId(string itemName)
        {
            return _marketItems.Values.FirstOrDefault(x => x.Name == itemName + " Blueprint")?.Id;
        }
    }
}
