using EveClientStandard.Extensions;
using EveIndustryStandard.Models;
using IO.Swagger.Api;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EveIndustryStandard.Managers
{
    public class MaterialsService
    {
        private readonly Dictionary<int?, double?> _adjustedPrices;

        public MaterialsService()
        {
            _adjustedPrices = GetAdjustedPrices();
        }

        public double GetInstallCost(IEnumerable<Component> components)
        {
            var baseJobCost = components.Sum(x => GetAdjustedPrice(x.Id) * x.Amount);

            var currentSystemIndex = 0.0627; // Read dynamically later
            var systemsCostIndex = 0.96 * currentSystemIndex;
            var jobFee = baseJobCost * systemsCostIndex;

            var facilityTax = jobFee * 2 / 100;

            return jobFee + facilityTax;
        }

        private Dictionary<int?, double?> GetAdjustedPrices()
        {
            return ApiExtension.GetAll(index => new MarketApi().GetMarketsPricesAsyncWithHttpInfo()).Result.ToDictionary(x => x.TypeId, x => x.AdjustedPrice);
        }

        private double GetAdjustedPrice(int itemId)
        {
            if (!_adjustedPrices.ContainsKey(itemId))
            {
                throw new ArgumentException("invalid itemId");
            }

            return _adjustedPrices[itemId].Value;
        }
    }
}