using System.Threading.Tasks;
using EveIndustryStandard.Models;

namespace EveIndustryStandard.Strategies
{
    public abstract class Strategy
    {
        protected readonly Item _item;

        protected Strategy(Item item)
        {
            _item = item;
        }

        public double GetPrice { get; private set; }

        protected abstract Task<double> ComputePrice();

        public abstract void PrintObtainingMethod();

        public async Task ComputeFinalPriceAsync()
        {
            GetPrice = await ComputePrice();
        }
    }
}