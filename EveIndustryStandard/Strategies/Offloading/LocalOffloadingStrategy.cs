using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EveIndustry.Models;

namespace EveIndustry.Strategies
{
    public class LocalOffloadingStrategy : OffloadingStrategy
    {
        public LocalOffloadingStrategy(Item item, Dictionary<int, double> localSellOrders, Dictionary<int, double> localBuyOrders) : base(item)
        {
        }

        protected override Task<double> ComputePrice()
        {
            throw new System.NotImplementedException();
        }

        public override void PrintObtainingMethod(int amount)
        {
            Console.WriteLine("Better sell it locally");
        }
    }
}