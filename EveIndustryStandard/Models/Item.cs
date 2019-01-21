using EveIndustryStandard.Services;
using EveIndustryStandard.Strategies;
using EveIndustryStandard.Strategies.Obtaining;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EveIndustryStandard.Models
{
    public class Item
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        public string ItemName { get; set; }

        public double BestBuyingPrice => BestObtainingStrategy.GetPrice;
        public double BestSellingPrice => BestOffloadingStrategy.GetPrice;

        public Strategy BestObtainingStrategy =>
            _obtainingStrategies.Aggregate((i1, i2) => i1.GetPrice < i2.GetPrice ? i1 : i2);

        public Strategy BestOffloadingStrategy =>
            _offLoadingStrategies.Aggregate((i1, i2) => i1.GetPrice > i2.GetPrice ? i1 : i2);

        public List<Item> Components { get; set; }

        private readonly List<Strategy> _obtainingStrategies  = new List<Strategy>();
        private readonly List<Strategy> _offLoadingStrategies  = new List<Strategy>();

        public Item WithOneDqBuyStrategy(Dictionary<int, double> localPrices)
        {
            _obtainingStrategies.Add(BuyLocalStrategy.Build(this, localPrices));
            return this;
        }

        public Item WithOneDqBuildStrategy(ItemFactory itemFactory, BlueprintService blueprintService)
        {
            _obtainingStrategies.Add(BuildLocalOneItemStrategy.Build(this, itemFactory, blueprintService));
            return this;
        }

        public async Task<Item> BuildAsync()
        {
            var results = new List<Task>();

            foreach (var strategy in _obtainingStrategies)
            {
                results.Add(strategy.ComputeFinalPriceAsync());
            }

            await Task.WhenAll(results.ToArray());

            return this;
        }
    }
}