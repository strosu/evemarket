using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EveIndustry.Models;
using EveIndustryStandard.Helpers;

namespace EveIndustry.Strategies
{
    public class BuyLocalStrategy : ObtainingStrategy
    {
        private readonly Dictionary<int, double> _localSellOrders;

        private BuyLocalStrategy(Item item, Dictionary<int, double> localSellOrders) : base(item)
        {
            _localSellOrders = localSellOrders;
        }

        public static ObtainingStrategy Build(Item item, Dictionary<int, double> localSellOders)
        {
            if (DictionaryHelpers.GetSellPriceForItemOrMax(item.Id, localSellOders).IsMaxValue())
            {
                return new NullObtainingStrategy(item);
            }

            return new BuyLocalStrategy(item, localSellOders);
        }

        protected override Task<double> ComputePrice()
        {
            return Task.FromResult(DictionaryHelpers.GetSellPriceForItemOrMax(_item.Id, _localSellOrders) * _item.Amount);
        }

        public override void PrintObtainingMethod(int amount)
        {
            Console.WriteLine($"Buying {0} pieces of {_item.Id} in 1DQ");
        }
    }
}