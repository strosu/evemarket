using EveIndustry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EveIndustryStandard.Managers;
using EveIndustryStandard.Strategies;

namespace EveIndustry.Strategies
{
    public class BuildLocalItemStrategy : ObtainingStrategy
    {
        private readonly BlueprintCopy _bpc;
        private readonly ItemFactory _itemFactory;
        private readonly List<Component> _components;

        private BuildLocalItemStrategy(Item item, BlueprintCopy bpc, ItemFactory itemItemFactory, List<Component> components) : base(item)
        {
            _bpc = bpc;
            _itemFactory = itemItemFactory;
            _components = components;
        }

        public static ObtainingStrategy Build(Item item, BlueprintCopy bpc, ItemFactory itemFactory, List<Component> components)
        {
            if (bpc == null)
            {
                return new NullObtainingStrategy(item);
            }

            return new BuildLocalItemStrategy(item, bpc, itemFactory, components);
        }

        protected override Task<double> ComputePrice()
        {
            var installCost = GetInstallCost() * _item.Amount;

            _item.Components = new List<Item>();
            foreach (var comp in _components)
            {
                _item.Components.Add(_itemFactory.Build(comp.Id, comp.Amount));
            }

            return Task.FromResult(installCost + _item.Components.Sum(x => x.BestPrice));
        }

        private double GetInstallCost()
        {
            return MaterialsManager.GetInstallCost(_components);
        }

        public override void PrintObtainingMethod(int amount)
        {
            Console.WriteLine($"Building {amount} locally for item {_item.Id}");
        }
    }
}