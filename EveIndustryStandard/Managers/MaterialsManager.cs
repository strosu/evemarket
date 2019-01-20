using EveClientStandard.Extensions;
using EveIndustry.Models;
using IO.Swagger.Api;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EveIndustryStandard.Managers
{
    public class MaterialsManager
    {
        private static readonly Dictionary<int?, double?> AdjustedPrices = GetAdjustedPrices();

        public static double GetInstallCost(List<Component> components)
        {
            var baseJobCost = components.Sum(x => GetAdjustedPrice(x.Id) * x.Amount);

            var currentSystemIndex = 0.0627; // Read dynamically later
            var systemsCostIndex = 0.96 * currentSystemIndex;
            var jobFee = baseJobCost * systemsCostIndex;

            var facilityTax = jobFee * 2 / 100;

            return jobFee + facilityTax;
        }

        private static Dictionary<int?, double?> GetAdjustedPrices()
        {
            return ApiExtension.GetAll(index => new MarketApi().GetMarketsPricesAsyncWithHttpInfo()).Result.ToDictionary(x => x.TypeId, x => x.AdjustedPrice);
        }

        private static double GetAdjustedPrice(int itemId)
        {
            if (!AdjustedPrices.ContainsKey(itemId))
            {
                throw new ArgumentException("invalid itemId");
            }

            return AdjustedPrices[itemId].Value;
        }
    }
}