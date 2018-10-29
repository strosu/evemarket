using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EveIndustry.Models;

namespace EveIndustry.Strategies
{
    public class BuyLocalStrategy : ObtainingStrategy
    {
        private readonly Dictionary<int, double> _localSellOders;

        private BuyLocalStrategy(Item item, Dictionary<int, double> localSellOders) : base(item)
        {
            _localSellOders = localSellOders;
        }

        public static ObtainingStrategy Build(Item item, Dictionary<int, double> localSellOders)
        {
            if (GetSellPriceForItemAtDestination(item.Id, localSellOders) == null)
            {
                return new NullObtainingStrategy(item);
            }

            return new BuyLocalStrategy(item, localSellOders);
        }

        protected override Task<double?> ComputePrice()
        {
            return Task.FromResult(GetSellPriceForItemAtDestination(_item.Id, _localSellOders));
        }

        public override void PrintObtainingMethod(int amount)
        {
            Console.WriteLine($"Buying {0} pieces of {_item.Id} in 1DQ");
        }

        private static double? GetSellPriceForItemAtDestination(int itemId, Dictionary<int, double> localSellOders)
        {
            return localSellOders.ContainsKey(itemId) ? (double?)localSellOders[itemId] : null;
        }
    }
}