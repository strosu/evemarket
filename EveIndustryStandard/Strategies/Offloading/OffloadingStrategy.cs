using System;
using System.Threading.Tasks;
using EveIndustry.Models;

namespace EveIndustry.Strategies
{
    public abstract class OffloadingStrategy
    {
        protected readonly Item _item;

        protected OffloadingStrategy(Item item)
        {
            _item = item;
        }

        public double GetPrice { get; private set; }

        protected abstract Task<double> ComputePrice();

        public abstract void PrintObtainingMethod(int amount);

        public async Task ComputeFinalPrice()
        {
            GetPrice = await ComputePrice();
        }
    }

    public class NullOffloadingStrategy : OffloadingStrategy
    {
        public NullOffloadingStrategy(Item item) : base(item)
        {
        }

        protected override Task<double> ComputePrice()
        {
            return Task.FromResult(double.MaxValue);
        }

        public override void PrintObtainingMethod(int amount)
        {
            Console.WriteLine("Cannot be offloaded, bo buy or sell info");
        }
    }
}