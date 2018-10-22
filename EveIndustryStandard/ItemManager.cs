using System;
using System.Collections.Generic;
using System.IO;
using EveIndustry.Models;
using Microsoft.VisualBasic.FileIO;

namespace EveIndustry
{
    public class ItemManager
    {
        public static List<Item> GetMarketItems()
        {
            var result = new List<Item>();
            var filePath = @"C:\Users\Stefan\Downloads\sde-20181009-TRANQUILITY\sde\fsd\types.txt";

            using (TextFieldParser parser = new TextFieldParser(filePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    //Processing row
                    string[] fields = parser.ReadFields();

                    //                    id = long(fields[0])

                    //                    name = fields[2].strip()

                    //                    published = 0

                    //                    description = fields[3].strip()
                    //                    if fields[7] == '':
                    //                    fields[7] = '0.001'
                    //                    volume = float(fields[7])
                    //                    if volume == 0:
                    //                    volume = 0.001


                    //                    published = "1"
                    //                    try:
                    //                    published = int(fields[12])
                    //                    except:
                    //                    pass

                    //                        marketgroup = fields[13]
                    //# Skip non-market items
                    //                    if marketgroup == "null" or marketgroup == "" or marketgroup == "0.0" or marketgroup == "0":
                    //                    print "SKIP: ",name,volume,published,marketgroup,id
                    //                        marketgroup = 1
                    //#continue
                    //                    marketgroup = int(marketgroup)

                    //                    group = int(fields[1])
                    //                    print name, volume, published, group, marketgroup, id

                    var marketGroup = fields[13];
                    if (!string.IsNullOrEmpty(marketGroup))
                    {
                        result.Add(new Item
                        {
                            Id = int.Parse(fields[0]),
                            Name = fields[2].Trim(),
                            MarketGroup = int.Parse(marketGroup),
                            Group = int.Parse(fields[1])
                        });
                    }
                }
            }

            return result;
        }
    }
}