using EveIndustryStandard.Helpers;
using EveIndustryStandard.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EveIndustryStandard.Strategies.Offloading
{
    public class ToLocalSellOffloadingStrategy : Strategy
    {
        private readonly Dictionary<int, double> _destinationBuyPrices;

        private ToLocalSellOffloadingStrategy(Item item, Dictionary<int, double> destinationBuyPrices) : base(item)
        {
            _destinationBuyPrices = destinationBuyPrices;
        }

        public Strategy Build(Item item, Dictionary<int, double> destinationBuyPrices)
        {
            if (DictionaryHelpers.GetSellPriceForItemOrMin(_item.Id, _destinationBuyPrices) < 0)
            {
                return new NullOffloadingStrategy(_item);
            }

            return new ToLocalSellOffloadingStrategy(_item, destinationBuyPrices);
        }

        protected override Task<double> ComputePrice()
        {
            return null;
        }

        public override void PrintObtainingMethod()
        {
            Console.WriteLine("Better sell it locally");
        }
    }
}