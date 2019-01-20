using System;
using System.Collections.Generic;
using EveIndustry.Models;
using EveIndustryStandard.Helpers;
using EveIndustryStandard.Managers;

namespace EveIndustryStandard.Services
{
    public class BlueprintService
    {
        private readonly BlueprintManager _blueprintManager;
        private readonly ItemManager _itemManager;

        public BlueprintService(BlueprintManager blueprintManager, ItemManager itemManager)
        {
            _blueprintManager = blueprintManager;
            _itemManager = itemManager;
        }

        public bool ItemHasBlueprint(int itemId)
        {
            return _itemManager.GetBpcIdForItem(itemId) != null;
        }

        public List<Component> GetComponentsWithMultipleRuns(int itemId, int amount, double bpcMaterialModifier)
        {
            var requiredComponents = new List<Component>();
            var bpcId = _itemManager.GetBpcIdForItem(itemId);
            var bpc = _blueprintManager.GetBluePrint(bpcId);

            if (bpc == null)
            {
                return null;
            }

            var fullRuns = amount / bpc.MaxRuns;
            var runsPartial = amount % bpc.MaxRuns;

            for (var i = 0; i < fullRuns; i++)
            {
                requiredComponents.AddComponents(ConcreteGetComponents(bpc.MaxRuns, bpcMaterialModifier, bpc));
            }

            requiredComponents.AddComponents(ConcreteGetComponents(runsPartial, bpcMaterialModifier, bpc));

            return requiredComponents;
        }

        private static List<Component> ConcreteGetComponents(int amount, double bpcMaterialModifier, BlueprintCopy bpc)
        {
            const double multiplier = 0.9484200063882373;
            var currentComponents = new List<Component>();
            foreach (var comp in bpc.UnresearchedRequiredComponentsForSingleRun)
            {
                currentComponents.Add(new Component
                {
                    Id = comp.Id,
                    Amount = (int)Math.Max(amount, Math.Ceiling(Math.Round(amount * comp.Amount * bpcMaterialModifier * multiplier, 2)))
                });
            }

            return currentComponents;
        }
    }
}