using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EveIndustry.Strategies;
using EveIndustryStandard.Managers;

namespace EveIndustry.Models
{
    public class Item
    {
        public int Id { get; set; }

        public List<ItemWithAmount> Components => _itemBuilder.Components;

        private ItemBuilder _itemBuilder;

        private readonly List<ObtainingStrategy> _obtainingStrategies  = new List<ObtainingStrategy>();

        public Item WithOneDqBuyStategy(Dictionary<int, double> localPrices)
        {
            _obtainingStrategies.Add(BuyLocalStrategy.Build(this, localPrices));
            return this;
        }

        public Item WithOneDqBuildStrategy(BlueprintCopy bpc)
        {
            _obtainingStrategies.Add(BuildLocalStrategy.Build(this, bpc));
            _itemBuilder = new ItemBuilder(bpc);
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