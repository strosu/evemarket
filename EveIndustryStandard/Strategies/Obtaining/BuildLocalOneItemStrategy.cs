using EveIndustry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EveIndustryStandard.Managers;
using EveIndustryStandard.Services;
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

            return new BuildLocalOneItemStrategy(item, itemFactory, blueprintService.GetComponentsWithMultipleRuns(item.Id, item.Amount, 0.9));
        }

        protected override Task<double> ComputePrice()
        {
            InstallCost = GetInstallCost();

            _item.Components = new List<Item>();
            foreach (var comp in _components)
            {
                _item.Components.Add(_itemFactory.Build(comp.Id, comp.Amount));
            }

            ComponentsCost = _item.Components.Sum(x => x.BestBuyingPrice);


            return Task.FromResult(InstallCost + ComponentsCost);
        }

        private double GetInstallCost()
        {
            return MaterialsManager.GetInstallCost(_components);
        }

        public override void PrintObtainingMethod()
        {
            Console.WriteLine($"Building {_item.Amount} locally for item {_item.ItemName} - {_item.Id}");
            foreach (var comp in _item.Components)
            {
                comp.BestObtainingStrategy.PrintObtainingMethod();
            }
        }
    }
}