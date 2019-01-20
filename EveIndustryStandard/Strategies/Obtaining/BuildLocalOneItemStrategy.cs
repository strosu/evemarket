using EveIndustry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EveIndustry.Services;
using EveIndustryStandard.Managers;
using EveIndustryStandard.Strategies;

namespace EveIndustry.Strategies
{
    public class BuildLocalOneItemStrategy : ObtainingStrategy
    {
        private readonly ItemFactory _itemFactory;
        private readonly List<Component> _components;

        public double InstallCost { get; private set; }
        public double ComponentsCost { get; private set; }

        private BuildLocalOneItemStrategy(Item item, ItemFactory itemItemFactory, List<Component> components) : base(item)
        {
            _itemFactory = itemItemFactory;
            _components = components;
        }

        public static ObtainingStrategy Build(Item item, ItemFactory itemFactory, BlueprintService blueprintService)
        {
            if (!blueprintService.ItemHasBlueprint(item.Id))
            {
                return new NullObtainingStrategy(item);
            }

            return new BuildLocalOneItemStrategy(item, itemFactory, blueprintService.GetComponents(item.Id, item.Amount, 0.9));
        }

        protected override Task<double> ComputePrice()
        {
            InstallCost = GetInstallCost();

            _item.Components = new List<Item>();
            foreach (var comp in _components)
            {
                _item.Components.Add(_itemFactory.Build(comp.Id, comp.Amount));
            }

            ComponentsCost = _item.Components.Sum(x => x.BestPrice);


            return Task.FromResult(InstallCost + ComponentsCost);
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