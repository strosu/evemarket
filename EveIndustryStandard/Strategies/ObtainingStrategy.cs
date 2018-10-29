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

        protected abstract Task<double?> ComputePrice();

        public abstract void PrintObtainingMethod(int amount);

        public async Task ComputeFinalPrice()
        {
            var price = await ComputePrice();
            GetPrice = price ?? double.MaxValue;
        }
    }

    public class NullObtainingStrategy : ObtainingStrategy
    {
        public NullObtainingStrategy(Item item) : base(item)
        {
        }

        protected override Task<double?> ComputePrice()
        {
            return null;
        }

        public override void PrintObtainingMethod(int amount)
        {
            Console.WriteLine("Cannot be obtained");
        }
    }
}