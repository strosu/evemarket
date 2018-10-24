﻿using System;
using System.Collections.Generic;
using System.Linq;
using EveIndustry.Models;
using Microsoft.VisualBasic.FileIO;

namespace EveIndustryStandard.Managers
{
    public class BlueprintManager
    {
        private const double Modifier = 0.948;

        public static Dictionary<int, BlueprintCopy> GetBlueprints()
        {
            var result = new Dictionary<int, BlueprintCopy>();
            var filePath = @"Resources\industryBlueprints.csv";
            var filePath2 = @"Resources\industryActivityMaterials.csv";

            var maxRunsDictionary = new Dictionary<int, int>();
            var materialsDictionary = new Dictionary<int, List<Tuple<int, int>>>();

            using (TextFieldParser parser = new TextFieldParser(filePath))
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

            using (TextFieldParser parser = new TextFieldParser(filePath2))
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
                    RequiredComponentsForSingleRun = materialsDictionary[key].Select(x => new Component()
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