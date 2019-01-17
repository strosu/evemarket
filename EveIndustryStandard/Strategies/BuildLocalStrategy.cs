using EveIndustry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EveIndustryStandard.Managers;
using EveIndustryStandard.Strategies;

namespace EveIndustry.Strategies
{
    public class BuildLocalStrategy : ObtainingStrategy
    {
        private readonly BlueprintCopy _bpc;
        private readonly ItemFactory _itemFactory;

        private BuildLocalStrategy(Item item, BlueprintCopy bpc, ItemFactory itemItemFactory) : base(item)
        {
            _bpc = bpc;
            _itemFactory = itemItemFactory;
        }

        public static ObtainingStrategy Build(Item item, BlueprintCopy bpc, ItemFactory itemFactory)
        {
            if (bpc == null)
            {
                return new NullObtainingStrategy(item);
            }

            return new BuildLocalStrategy(item, bpc, itemFactory);
        }

        protected override Task<double> ComputePrice()
        {
            var installCost = GetInstallCost() * _item.Amount;

            List<Item> components = new List<Item>();
            foreach (var comp in _bpc.UnresearchedRequiredComponentsForSingleRun)
            {
                components.Add(_itemFactory.Build(comp.Id, comp.Amount));
            }

            return Task.FromResult((double)installCost + components.Sum(x => x.BestPrice));
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