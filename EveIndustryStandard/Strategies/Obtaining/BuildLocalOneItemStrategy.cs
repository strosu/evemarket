using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EveIndustryStandard.Managers;
using EveIndustryStandard.Models;
using EveIndustryStandard.Services;

namespace EveIndustryStandard.Strategies.Obtaining
{
    public class BuildLocalOneItemStrategy : Strategy
    {
        private readonly Func<int, int, Task<Item>> _buildFunc;
        private readonly MaterialsService _materialsService;
        private readonly List<Component> _components;

        public double InstallCost { get; private set; }
        public double ComponentsCost { get; private set; }

        private BuildLocalOneItemStrategy(Item item, Func<int, int, Task<Item>> buildFunc, BlueprintService blueprintService, MaterialsService materialsService) : base(item)
        {
            _buildFunc = buildFunc;
            _materialsService = materialsService;
            _components = blueprintService.GetComponentsWithMultipleRuns(item.Id, item.Amount, 0.9);
        }

        public static Strategy Build(Item item, Func<int, int, Task<Item>> buildFunc, BlueprintService blueprintService, MaterialsService materialsService)
        {
            if (!blueprintService.ItemHasBlueprint(item.Id))
            {
                return new NullObtainingStrategy(item);
            }

            return new BuildLocalOneItemStrategy(item, buildFunc, blueprintService, materialsService);
        }

        protected override async Task<double> ComputePrice()
        {
            InstallCost = _materialsService.GetInstallCost(_components);

            _item.Components = new List<Item>();
            var componentTasks = new List<Task<Item>>();
            foreach (var comp in _components)
            {
                componentTasks.Add(_buildFunc(comp.Id, comp.Amount));
            }

            _item.Components = (await Task.WhenAll(componentTasks.ToArray())).ToList();

            ComponentsCost = _item.Components.Sum(x => x.BestBuyingPrice);

            return InstallCost + ComponentsCost;
        }
        
        public override void PrintObtainingMethod()
        {
            Console.WriteLine($"Building {_item.Amount} locally for item {_item.ItemName} - {_item.Id}. " +
                              $"Components cost: {ComponentsCost}, install cost {InstallCost}");

            foreach (var comp in _item.Components)
            {
                comp.BestObtainingStrategy.PrintObtainingMethod();
            }
        }
    }
}