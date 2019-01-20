using System;
using System.Collections.Generic;
using System.Linq;
using EveIndustry.Models;
using Microsoft.VisualBasic.FileIO;

namespace EveIndustryStandard.Managers
{
    public class BlueprintManager
    {
        private readonly Dictionary<int, BlueprintCopy> _bpcs;

        public BlueprintManager()
        {
            _bpcs = GetBlueprints();
        }

        public List<Component> GetComponents(int itemId, int amount, double bpcMaterialModifier, BlueprintCopy bpc)
        {
            var requiredComponents = new List<Component>();

            var fullRuns = amount / bpc.MaxRuns;
            var runsPartial = amount % bpc.MaxRuns;

            for (int i = 0; i < fullRuns; i++)
            {
                AddComponents(requiredComponents, ConcreteGetComponents(itemId, bpc.MaxRuns, bpcMaterialModifier, bpc));
            }

            AddComponents(requiredComponents, ConcreteGetComponents(itemId, runsPartial, bpcMaterialModifier, bpc));

            return requiredComponents;
        }

        private void AddComponents(List<Component> previous, List<Component> current)
        {
            foreach (var comp in current)
            {
                var prev = previous.FirstOrDefault(x => x.Id == comp.Id);
                if (prev == null)
                {
                    previous.Add(comp);
                    continue;
                }

                prev.Amount += comp.Amount;
            }
        }

        private List<Component> ConcreteGetComponents(int itemId, int amount, double bpcMaterialModifier, BlueprintCopy bpc)
        {
            var multiplier = 0.853578;
            var baseComponents = bpc.UnresearchedRequiredComponentsForSingleRun.ToList();
            foreach (var comp in baseComponents)
            {
                comp.Amount = (int)Math.Max(amount, Math.Ceiling(Math.Round(amount * comp.Amount * bpcMaterialModifier * multiplier, 2)));
            }

            return baseComponents;
        }

        // Take itemId => bpc => List<Component> needed => send back to ItemBUilder
        // maybe also take the efficiencies here
        public static Dictionary<int, BlueprintCopy> GetBlueprints()
        {
            var result = new Dictionary<int, BlueprintCopy>();

            var maxRunsDictionary = new Dictionary<int, int>();
            var materialsDictionary = new Dictionary<int, List<Tuple<int, int>>>();

            using (TextFieldParser parser = new TextFieldParser(@"Resources\industryBlueprints.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    //Processing row
                    string[] fields = parser.ReadFields();

                    var id = int.Parse(fields[0]);
                    var maxRuns = int.Parse(fields[1]);
                    maxRunsDictionary.Add(id, maxRuns);
                }
            }

            using (TextFieldParser parser = new TextFieldParser(@"Resources\industryActivityMaterials.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    //Processing row
                    string[] fields = parser.ReadFields();

                    var id = int.Parse(fields[0]);
                    var jobType = int.Parse(fields[1]);
                    var materialType = int.Parse(fields[2]);
                    var materialAmount = int.Parse(fields[3]);

                    if (jobType != 1) continue;

                    if (!materialsDictionary.ContainsKey(id))
                    {
                        materialsDictionary.Add(id, new List<Tuple<int, int>>());
                    }

                    materialsDictionary[id].Add(new Tuple<int, int>(materialType, materialAmount));
                }
            }

            var keyList = maxRunsDictionary.Keys.Where(x => materialsDictionary.ContainsKey(x));

            foreach (var key in keyList)
            {
                result.Add(key, new BlueprintCopy()
                {
                    MaxRuns = maxRunsDictionary[key],
                    UnresearchedRequiredComponentsForSingleRun = materialsDictionary[key].Select(x => new Component()
                    {
                        Id = x.Item1,
                        Amount = x.Item2
                    }).ToList()
                });
            }

            return result;
        }

        private int GetRequiredComponents(int bpcId, int componentTypeId)
        {
            var multiplier = 0.853578; // should be the citadel effect
            return (int)Math.Ceiling(_bpcs[bpcId].UnresearchedRequiredComponentsForSingleRun.FirstOrDefault(x => x.Id == componentTypeId).Amount * multiplier);
        }
    }
}