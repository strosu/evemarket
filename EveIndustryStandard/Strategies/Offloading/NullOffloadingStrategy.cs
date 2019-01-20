using System;
using System.Threading.Tasks;
using EveIndustryStandard.Models;

namespace EveIndustryStandard.Strategies.Offloading
{
    public class NullOffloadingStrategy : Strategy
    {
        public NullOffloadingStrategy(Item item) : base(item)
        {
        }

        protected override Task<double> ComputePrice()
        {
            return Task.FromResult(double.MaxValue);
        }

        public override void PrintObtainingMethod()
        {
            Console.WriteLine("Cannot be offloaded, to buy or sell orders");
        }
    }
}