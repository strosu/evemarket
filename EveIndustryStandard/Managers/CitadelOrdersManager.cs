using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EveClientStandard.Extensions;
using EveIndustry;
using IO.Swagger.Api;
using IO.Swagger.Model;
using Newtonsoft.Json;

namespace EveIndustryStandard.Managers
{
    public class CitadelOrdersManager
    {
        public static async Task<Tuple<Dictionary<int, double>, Dictionary<int, double>>> InitializeCitadelOrders(bool refreshCitadelData, MarketApi marketApi)
        {
            // var structureId = new SearchApi().GetCharactersCharacterIdSearchWithHttpInfo(new List<string>() { "structure" }, _charInfo.CharacterID, "1DQ");
            var filePath = @"D:\git\EveMarket\EveIndustryStandard\Resources\onedq.json";

            LazyAsync<List<GetMarketsStructuresStructureId200Ok>> destinationOrders;

            if (refreshCitadelData)
            {
                destinationOrders =
                    new LazyAsync<List<GetMarketsStructuresStructureId200Ok>>(async () => await ApiExtension.GetAll(
                        index => marketApi.GetMarketsStructuresStructureIdAsyncWithHttpInfo(1022734985679, page: index)));
                File.WriteAllText(filePath, JsonConvert.SerializeObject(await destinationOrders.Value));
            }

            using (StreamReader file = File.OpenText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();

                destinationOrders = new LazyAsync<List<GetMarketsStructuresStructureId200Ok>>(async () =>
                    (List<GetMarketsStructuresStructureId200Ok>)serializer.Deserialize(file, typeof(List<GetMarketsStructuresStructureId200Ok>)));
                await destinationOrders.Value;
            }

            var destinationSellPrices =
                (await GetCitadelSellOrders(destinationOrders)).ApplyOrdersMapping(list => list.Min(x => x.Price.Value));

            var destinationBuyPrices = (await GetCitadelBuyOrders(destinationOrders)).ApplyOrdersMapping(list => list.Max(x => x.Price.Value));

            return new Tuple<Dictionary<int, double>, Dictionary<int, double>>(destinationSellPrices, destinationBuyPrices);
        }

        private static async Task<IEnumerable<GetMarketsStructuresStructureId200Ok>> GetCitadelBuyOrders(LazyAsync<List<GetMarketsStructuresStructureId200Ok>> destinationOrders)
        {
            return (await destinationOrders.Value).Where(x => x.IsBuyOrder.Value);
        }

        private static async Task<IEnumerable<GetMarketsStructuresStructureId200Ok>> GetCitadelSellOrders(LazyAsync<List<GetMarketsStructuresStructureId200Ok>> destinationOrders)
        {
            return (await destinationOrders.Value).Where(x => !x.IsBuyOrder.Value);
        }
    }
}