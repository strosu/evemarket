using System.Collections.Generic;
using EveIndustry.Models;
using Microsoft.VisualBasic.FileIO;

namespace EveIndustryStandard.Managers
{
    public class ItemManager
    {
        public static Dictionary<int, Item> GetMarketItems()
        {
            var result = new Dictionary<int, Item>();
            var filePath = @"Resources\types.txt";

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
                        var id = int.Parse(fields[0]);
                        result.Add(id, new Item
                        {
                            Id = id,
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