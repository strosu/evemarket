using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EveIndustryStandard.Helpers;
using EveIndustryStandard.Models;

namespace EveIndustryStandard.Strategies.Obtaining
{
    public class BuyLocalStrategy : Strategy
    {
        private readonly Dictionary<int, double> _localSellOrders;

        private BuyLocalStrategy(Item item, Dictionary<int, double> localSellOrders) : base(item)
        {
            _localSellOrders = localSellOrders;
        }

        public static Strategy Build(Item item, Dictionary<int, double> localSellOrders)
        {
            if (DictionaryHelpers.GetSellPriceForItemOrMax(item.Id, localSellOrders).IsMaxValue())
            {
                return new NullObtainingStrategy(item);
            }

            return new BuyLocalStrategy(item, localSellOrders);
        }

        protected override Task<double> ComputePrice()
        {
            return Task.FromResult(DictionaryHelpers.GetSellPriceForItemOrMax(_item.Id, _localSellOrders) * _item.Amount);
        }

        public override void PrintObtainingMethod()
        {
            Console.WriteLine($"Buying {_item.Amount} pieces of {_item.ItemName} - {_item.Id} in 1DQ at a price of {GetPrice}");
        }
    }
}