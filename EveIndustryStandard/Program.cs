using System;
using System.Configuration;
using System.Threading.Tasks;
using EveIndustryStandard.Managers;

namespace EveIndustry
{
    class Program
    {
        public static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {
            Console.WriteLine("Hello World!");

            var regionId = int.Parse(ConfigurationManager.AppSettings["RegionId"]);
            var sourceRegionId = int.Parse(ConfigurationManager.AppSettings["SourceRegionId"]);
            var minAverageVolumePerDay = int.Parse(ConfigurationManager.AppSettings["MinAverageVolumePerDay"]);
            var daysToEvaluate = int.Parse(ConfigurationManager.AppSettings["DaysToEvaluate"]);
            var minOrdersPerDay = int.Parse(ConfigurationManager.AppSettings["MinOrdersPerDay"]);

            var manager = await IndustryManager.Create(); 
            var result = await manager.ComputePrice(23055, sourceRegionId, 30000142);
            var resultMalleus = await manager.ComputePrice(32340, sourceRegionId, 30000142);
            var resultNyx = await manager.ComputePrice(23913, sourceRegionId, 30000142); 
            // var currentPrices = await manager.ComputeCurrentPrices(sourceRegionId, regionId);
            //await manager.GetPotentialItems(regionId, minOrdersPerDay, minAverageVolumePerDay, daysToEvaluate);

            Console.ReadLine();
        }
    }
}
