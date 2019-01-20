using EveIndustryStandard.Models;
using System.Collections.Generic;
using System.Linq;

namespace EveIndustryStandard.Helpers
{
    public static class DictionaryHelpers
    {
        public static double GetSellPriceForItemOrMax(int itemId, Dictionary<int, double> orders)
        {
            return orders.ContainsKey(itemId) ? orders[itemId] : double.MaxValue;
        }

        public static double GetSellPriceForItemOrMin(int itemId, Dictionary<int, double> orders)
        {
            return orders.ContainsKey(itemId) ? orders[itemId] : double.MinValue;
        }

        public static bool IsMaxValue(this double value)
        {
            return value > 1000000000000;
        }

        public static TValue GetValueOrNull<TValue>(this Dictionary<int, TValue> dictionary, int? key) where TValue : class 
        {
            if (key == null)
            {
                return null;
            }

            return dictionary.TryGetValue(key.Value, out var value) ? value : null;
        }

        public static void AddComponents(this ICollection<Component> previous, IEnumerable<Component> current)
        {
            foreach (var comp in current)
            {
                var prev = previous.FirstOrDefault(x => x.Id == comp.Id);
                if (prev.Equals(default(Component)))
                {
                    previous.Add(comp);
                    continue;
                }

                prev.Amount += comp.Amount;
            }
        }
    }
}