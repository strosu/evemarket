using System;
using System.Threading.Tasks;
using EveIndustry.Models;

namespace EveIndustry.Strategies
{
    public abstract class ObtainingStrategy
    {
        protected readonly Item _item;

        protected ObtainingStrategy(Item item)
        {
            _item = item;
        }

        public double GetPrice { get; private set; }

        protected abstract Task<double> ComputePrice();

        public abstract void PrintObtainingMethod();

        public async Task ComputeFinalPrice()
        {
            GetPrice = await ComputePrice();
        }
    }

    public class NullObtainingStrategy : ObtainingStrategy
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