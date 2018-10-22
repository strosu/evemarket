using System;
using System.Threading.Tasks;

namespace EveIndustry
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            YmlReader.GetSellableTypes();

            var refreshToken = "D98EYs8SzDdFECDZq2Nl-Ucr_ZbBWhjSA1bFEcAkbxW9kWcAmyo5UQRhoIGGzVZQ0";
            var manager = await IndustryManager.Create(refreshToken);
            manager.Compute();

            Console.ReadLine();
        }

    }
}
