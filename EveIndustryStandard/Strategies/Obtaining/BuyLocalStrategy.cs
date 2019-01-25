using EveIndustryStandard.Helpers;
using EveIndustryStandard.Managers.Market;
using EveIndustryStandard.Models;
using System;
using System.Threading.Tasks;

namespace EveIndustryStandard.Strategies.Obtaining
{
    public class BuyLocalStrategy : Strategy
    {
        private readonly IMarketObtainer _obtainer;

        private BuyLocalStrategy(Item item, IMarketObtainer obtainer) : base(item)
        {
            _obtainer = obtainer;
        }

        public static Strategy Build(Item item, IMarketObtainer obtainer)
        {
            if (!obtainer.CanBuyHere(item.Id, item.Amount))
            {
                return new NullObtainingStrategy(item);
            }

            return new BuyLocalStrategy(item, obtainer);
        }

        protected override Task<double> ComputePrice()
        {
            return Task.FromResult(_obtainer.GetBuyingPrice(_item.Id, _item.Amount));
        }

        public override void PrintObtainingMethod()
        {
            Console.WriteLine($"Buying {_item.Amount} pieces of {_item.ItemName} - {_item.Id} in 1DQ at a price of {GetPrice}");
        }
    }
}