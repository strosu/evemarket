using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using EveIndustryStandard.Managers;

namespace EveIndustry.Models
{
    [SuppressMessage("ReSharper", "IdentifierTypo")]
    public class ItemPrice
    {
        public int ItemId { get; set; }

        public double JitaSellPrice { get; set; }

        public double OneDqSellPrice { get; set; }

        public double OneDqBuyPrice { get; set; }

        public int? BpcItemId { get; set; }

        public List<ItemPriceWithAmount> Components { get; set; }

        public int? MaxRunsPerBpc { get; set; }

        public double BuildPrice => BpcItemId.HasValue ? Components.Sum(x => x.Item.BestPrice * x.Amount) + MaterialsManager.GetInstallCost(this) : double.MaxValue;

        public double BestPrice
        {
            get
            {
                var min = Min(JitaSellPrice, OneDqSellPrice);
                return BpcItemId.HasValue ? Min(min, BuildPrice) : min;
            }
        }

        private double Min(params double[] args)
        {
            var min = args[0];
            foreach (var item in args)
            {
                if (min > item)
                {
                    min = item;
                }
            }

            return min;
        }
    }
}