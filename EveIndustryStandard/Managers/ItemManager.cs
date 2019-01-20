using System.Collections.Generic;
using System.Linq;
using EveIndustry.Models;
using EveIndustryStandard.Helpers;
using Microsoft.VisualBasic.FileIO;

namespace EveIndustryStandard.Managers
{
    public class ItemManager
    {
        private readonly Dictionary<int, MarketItem> _marketItems;

        public ItemManager()
        {
            _marketItems = GetMarketItems();
        }

        public MarketItem GetMarketItem(int itemId)
        {
            return _marketItems.GetValueOrNull(itemId);
        }

        public IEnumerable<MarketItem> GetAll()
        {
            return _marketItems.Values;
        }

        public int? GetBpcIdForItem(int itemId)
        {
            var itemName = GetItemName(itemId);
            return GetBpcItemId(itemName);
        }

        public string GetItemName(int itemId)
        {
            return _marketItems[itemId].Name;
        }

        private int? GetBpcItemId(string itemName)
        {
            return _marketItems.Values.FirstOrDefault(x => x.Name == itemName + " Blueprint")?.Id;
        }

        private static Dictionary<int, MarketItem> GetMarketItems()
        {
            var result = new Dictionary<int, MarketItem>();
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
                        result.Add(id, new MarketItem
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