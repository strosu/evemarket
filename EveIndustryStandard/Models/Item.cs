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

        public string ItemName { get; set; }

        public double BestBuyingPrice => BestObtainingStrategy.GetPrice;
        public double BestSellingPrice => BestOffloadingStrategy.GetPrice;

        public ObtainingStrategy BestObtainingStrategy =>
            _obtainingStrategies.Aggregate((i1, i2) => i1.GetPrice < i2.GetPrice ? i1 : i2);

        public OffloadingStrategy BestOffloadingStrategy =>
            _offLoadingStrategies.Aggregate((i1, i2) => i1.GetPrice > i2.GetPrice ? i1 : i2);

        public List<Item> Components { get; set; }

        private readonly List<ObtainingStrategy> _obtainingStrategies  = new List<ObtainingStrategy>();
        private readonly List<OffloadingStrategy> _offLoadingStrategies  = new List<OffloadingStrategy>();

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