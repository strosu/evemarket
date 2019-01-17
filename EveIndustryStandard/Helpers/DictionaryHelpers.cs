using System.Collections.Generic;

namespace EveIndustry.Helpers
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
    }
}