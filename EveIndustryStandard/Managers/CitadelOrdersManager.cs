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
        private readonly MarketApi _marketApi;
        public Dictionary<int, double> DestinationSellPrices { get; private set; }= new Dictionary<int, double>();
        public Dictionary<int, double> DestinationBuyPrices { get; private set; }= new Dictionary<int, double>();
        private LazyAsync<List<GetMarketsStructuresStructureId200Ok>> _destinationOrders;

        private CitadelOrdersManager(MarketApi marketApi)
        {
            _marketApi = marketApi;
        }

        public static async Task<CitadelOrdersManager> BuildCitadelManager(MarketApi marketApi, bool refreshCitadelData)
        {
            var result = new CitadelOrdersManager(marketApi);
            await result.InitializeCitadelOrders(refreshCitadelData);

            return result;
        }

        public async Task InitializeCitadelOrders(bool refreshCitadelData)
        {
            

            DestinationSellPrices =
                (await GetCitadelSellOrders()).ApplyOrdersMapping(list => list.Min(x => x.Price.Value));

            DestinationBuyPrices = (await GetCitadelBuyOrders()).ApplyOrdersMapping(list => list.Max(x => x.Price.Value));
        }

        private async Task GetOrders(bool refreshCitadelData)
        {
            // var structureId = new SearchApi().GetCharactersCharacterIdSearchWithHttpInfo(new List<string>() { "structure" }, _charInfo.CharacterID, "1DQ");
            var filePath = @"D:\git\EveMarket\EveIndustryStandard\Resources\onedq.json";

            if (refreshCitadelData)
            {
                _destinationOrders =
                    new LazyAsync<List<GetMarketsStructuresStructureId200Ok>>(async () => await ApiExtension.GetAll(
                        index => _marketApi.GetMarketsStructuresStructureIdAsyncWithHttpInfo(1022734985679, page: index)));
                File.WriteAllText(filePath, JsonConvert.SerializeObject(await _destinationOrders.Value));
            }

            using (var file = File.OpenText(filePath))
            {
                var serializer = new JsonSerializer();

                _destinationOrders = new LazyAsync<List<GetMarketsStructuresStructureId200Ok>>(async () =>
                    (List<GetMarketsStructuresStructureId200Ok>) serializer.Deserialize(file,
                        typeof(List<GetMarketsStructuresStructureId200Ok>)));
                await _destinationOrders.Value;
            }
        }

        private async Task<IEnumerable<GetMarketsStructuresStructureId200Ok>> GetCitadelBuyOrders()
        {
            return (await _destinationOrders.Value).Where(x => x.IsBuyOrder.Value);
        }

        private async Task<IEnumerable<GetMarketsStructuresStructureId200Ok>> GetCitadelSellOrders()
        {
            return (await _destinationOrders.Value).Where(x => !x.IsBuyOrder.Value);
        }
    }
}