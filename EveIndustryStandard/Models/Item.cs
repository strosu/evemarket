using EveIndustry.Strategies;
using EveIndustryStandard.Strategies;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EveIndustryStandard.Services;

namespace EveIndustry.Models
{
    public class Item
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        public double BestPrice => _obtainingStrategies.Min(x => x.GetPrice);

        public List<Item> Components { get; set; }

        private readonly List<ObtainingStrategy> _obtainingStrategies  = new List<ObtainingStrategy>();

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

        public Item Build()
        {
            var results = new List<Task>();

            foreach (var strategy in _obtainingStrategies)
            {
                results.Add(strategy.ComputeFinalPrice());
            }

            Task.WaitAll(results.ToArray());

            return this;
        }
    }
}