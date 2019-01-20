using EveIndustryStandard.Helpers;
using EveIndustryStandard.Models;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EveIndustryStandard.Managers
{
    public class BlueprintManager
    {
        private readonly Dictionary<int, BlueprintCopy> _bpcs;

        public BlueprintManager()
        {
            _bpcs = GetBlueprints();
        }

        public BlueprintCopy GetBluePrint(int? bpcItemId)
        {
            return _bpcs.GetValueOrNull(bpcItemId);
        }

        private static Dictionary<int, BlueprintCopy> GetBlueprints()
        {
            var result = new Dictionary<int, BlueprintCopy>();

            var maxRunsDictionary = new Dictionary<int, int>();
            var materialsDictionary = new Dictionary<int, List<Tuple<int, int>>>();

            using (var parser = new TextFieldParser(@"Resources\industryBlueprints.csv"))
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

            using (var parser = new TextFieldParser(@"Resources\industryActivityMaterials.csv"))
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
    }
}