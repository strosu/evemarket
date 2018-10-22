using System.Collections.Generic;
using System.IO;

namespace EveIndustry
{
    public class ItemManager
    {
        public static List<int> GetMarketItems()
        {
            var result = new List<int>();
            var filePath = @"C:\Users\Stefan\Downloads\sde-20181009-TRANQUILITY\sde\fsd\types.txt";

            using (TextFieldParser parser = new TextFieldParser(@"c:\temp\test.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    //Processing row
                    string[] fields = parser.ReadFields();
                    foreach (string field in fields)
                    {
                        //TODO: Process field
                    }
                }
            }

            return result;
        }
    }
}