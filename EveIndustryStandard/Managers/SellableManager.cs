using EveIndustryStandard.Models;
using IO.Swagger.Api;
using IO.Swagger.Model;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EveIndustryStandard.Managers
{
    public class SellableManager
    {
        private readonly Dictionary<int, MarketItem> _marketItems;
        private readonly MarketApi _marketApi;

        public SellableManager(Dictionary<int, MarketItem> marketItems, MarketApi marketApi)
        {
            _marketItems = marketItems;
            _marketApi = marketApi;
        }

        public async Task GetPotentialItems(int regionId, int daysToEvaluate, int minAverageVolumePerDay, int minOrdersPerDay)
        {
            var sellable = await GetSellableItems(regionId, daysToEvaluate, minAverageVolumePerDay, minOrdersPerDay);
        }

        private async Task<ConcurrentBag<MarketItem>> GetSellableItems(int regionId, int daysToEvaluate, int minAverageVolumePerDay, int minOrdersPerDay)
        {
            var result = new ConcurrentBag<MarketItem>();

            var tasks = _marketItems.Select(async item =>
            {
                if (await HasMarket(item.Value, regionId, daysToEvaluate, minAverageVolumePerDay, minOrdersPerDay))
                {
                    result.Add(item.Value);
                };
            });

            await Task.WhenAll(tasks);
            return result;
        }

        private async Task<bool> HasMarket(MarketItem marketItem, int regionId, int daysToEvaluate, int minAverageVolumePerDay, int minOrdersPerDay)
        {
            try
            {
                var orders = (await _marketApi.GetMarketsRegionIdHistoryAsync(regionId, marketItem.Id)).OrderByDescending(x => x.Date)
                    .Take(daysToEvaluate).ToList();

                return AreConsecutiveDays(orders, daysToEvaluate)
                       && GetAverageDailyRevenue(orders) >= minAverageVolumePerDay
                       && HasMinNumberOfOrders(orders, minOrdersPerDay);
            }
            catch
            {
                return false;
            }
        }

        private static bool HasMinNumberOfOrders(List<GetMarketsRegionIdHistory200Ok> orders, int minOrdersPerDay)
        {
            return orders.Average(x => x.OrderCount).Value >= minOrdersPerDay;
        }

        private static bool AreConsecutiveDays(List<GetMarketsRegionIdHistory200Ok> orders, int daysToEvaluate)
        {
            if (orders.Count < daysToEvaluate)
            {
                return false;
            }

            var tmp = orders.First().Date - orders.Last().Date;

            return tmp.Value.TotalDays == daysToEvaluate;
        }

        private static double GetAverageDailyRevenue(List<GetMarketsRegionIdHistory200Ok> orders)
        {
            return orders.Select(x => x.Average * x.Volume).Average().Value;
        }
    }
}