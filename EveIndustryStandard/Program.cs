using EveIndustryStandard.Services;
using System;
using System.Configuration;
using System.Threading.Tasks;

namespace EveIndustry
{
    class Program
    {
        public static void Main()
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            Console.WriteLine("Hello World!");

            var regionId = int.Parse(ConfigurationManager.AppSettings["RegionId"]);
            var sourceRegionId = int.Parse(ConfigurationManager.AppSettings["SourceRegionId"]);
            var minAverageVolumePerDay = int.Parse(ConfigurationManager.AppSettings["MinAverageVolumePerDay"]);
            var daysToEvaluate = int.Parse(ConfigurationManager.AppSettings["DaysToEvaluate"]);
            var minOrdersPerDay = int.Parse(ConfigurationManager.AppSettings["MinOrdersPerDay"]);
            var refreshCitadelData = bool.Parse(ConfigurationManager.AppSettings["RefreshCitadelData"]);

            int amount = 1;
            var industryService = await ItemFactoryBuilder.CreateAsync(refreshCitadelData);
            // var result = await manager.ComputePrice(23055, sourceRegionId, 30000142); 
            // var result2 = await industryService.ComputePriceAsync("Templar I", amount); 
            var result2 = await industryService.ComputePriceAsync("Tritanium", 6000000);
            //var resultMalleus = await manager.ComputePrice(32340, sourceRegionId, 30000142);
            //var resultNyx = await manager.ComputePrice(23913, sourceRegionId, 30000142); 
            // var currentPrices = await manager.ComputeCurrentPrices(sourceRegionId, regionId);
            //await manager.GetPotentialItems(regionId, minOrdersPerDay, minAverageVolumePerDay, daysToEvaluate);

            result2.BestObtainingStrategy.PrintObtainingMethod();

            Console.ReadLine();
            Console.WriteLine(result2);
        }
    }
}
