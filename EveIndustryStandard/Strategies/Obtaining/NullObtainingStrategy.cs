using System;
using System.Threading.Tasks;
using EveIndustryStandard.Models;

namespace EveIndustryStandard.Strategies.Obtaining
{
    public class NullObtainingStrategy : Strategy
    {
        public NullObtainingStrategy(Item item) : base(item)
        {
        }

        protected override Task<double> ComputePrice()
        {
            return Task.FromResult(double.MaxValue);
        }

        public override void PrintObtainingMethod()
        {
            Console.WriteLine("Cannot be obtained");
        }
    }
}