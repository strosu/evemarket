using System;
using System.Configuration;
using System.Threading.Tasks;

namespace EveIndustry
{
    class Program
    {
        private const string RefreshToken = "D98EYs8SzDdFECDZq2Nl-Ucr_ZbBWhjSA1bFEcAkbxW9kWcAmyo5UQRhoIGGzVZQ0";

        public static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {
            Console.WriteLine("Hello World!");

            var regionId = int.Parse(ConfigurationManager.AppSettings["RegionId"]);
            var minAverageVolumePerDay = int.Parse(ConfigurationManager.AppSettings["MinAverageVolumePerDay"]);
            var daysToEvaluate = int.Parse(ConfigurationManager.AppSettings["DaysToEvaluate"]);
            var minOrdersPerDay = int.Parse(ConfigurationManager.AppSettings["MinOrdersPerDay"]);

            var manager = IndustryManager.Create(RefreshToken).Result;
            await manager.GetPotentialItems(regionId, minOrdersPerDay, minAverageVolumePerDay, daysToEvaluate);

            Console.ReadLine();
        }

    }
}
