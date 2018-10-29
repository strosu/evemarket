using EveIndustry.Models;
using System;
using System.Threading.Tasks;
using EveIndustryStandard.Managers;

namespace EveIndustry.Strategies
{
    public class BuildLocalStrategy : ObtainingStrategy
    {
        private readonly BlueprintCopy _bpc;

        private BuildLocalStrategy(Item item, BlueprintCopy bpc) : base(item)
        {
            _bpc = bpc;
        }

        public static ObtainingStrategy Build(Item item, BlueprintCopy bpc)
        {
            if (bpc == null)
            {
                return new NullObtainingStrategy(item);
            }

            return new BuildLocalStrategy(item, bpc);
        }

        protected override Task<double?> ComputePrice()
        {
            var installCost = GetInstallCost();

            var componentsCost = _item.Components

            return installCost;
        }

        private double GetInstallCost()
        {
            return MaterialsManager.GetInstallCost(_bpc);
        }

        public override void PrintObtainingMethod(int amount)
        {
            Console.WriteLine($"Building {amount} locally for item {_item.Id}");
        }
    }
}