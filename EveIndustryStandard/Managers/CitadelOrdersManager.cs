using System;
using EveClientStandard.Extensions;
using EveIndustryStandard.Helpers;
using IO.Swagger.Api;
using IO.Swagger.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EveIndustryStandard.Managers
{
    public class CitadelOrdersManager
    {
        private readonly MarketApi _marketApi;
        public Dictionary<int, double> DestinationSellPrices { get; private set; } = new Dictionary<int, double>();
        public Dictionary<int, double> DestinationBuyPrices { get; private set; } = new Dictionary<int, double>();

        private LazyAsync<List<GetMarketsStructuresStructureId200Ok>> _allCitadelOrders;

        private CitadelOrdersManager(MarketApi marketApi)
        {
            _marketApi = marketApi;
        }

        public static async Task<CitadelOrdersManager> BuildAsync(MarketApi marketApi, bool refreshCitadelData)
        {
            var result = new CitadelOrdersManager(marketApi);
            return await result.InitializeCitadelOrdersAsync(refreshCitadelData);
        }

        private async Task<CitadelOrdersManager> InitializeCitadelOrdersAsync(bool refreshCitadelData)
        {
            await GetOrdersAsync(refreshCitadelData);

            DestinationSellPrices =
                (await GetCitadelSellOrdersAsync()).ApplyOrdersMapping(list => list.Min(x => x.Price.Value));

            DestinationBuyPrices = 
                (await GetCitadelBuyOrdersAsync()).ApplyOrdersMapping(list => list.Max(x => x.Price.Value));

            return this;
        }

        private async Task GetOrdersAsync(bool refreshCitadelData)
        {
            // var structureId = new SearchApi().GetCharactersCharacterIdSearchWithHttpInfo(new List<string>() { "structure" }, _charInfo.CharacterID, "1DQ");
            var filePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Resources\\onedq.json"));

            if (refreshCitadelData)
            {
                _allCitadelOrders =
                    new LazyAsync<List<GetMarketsStructuresStructureId200Ok>>(async () => await ApiExtension.GetAll(
                        index => _marketApi.GetMarketsStructuresStructureIdAsyncWithHttpInfo(1022734985679, page: index)));
                File.WriteAllText(filePath, JsonConvert.SerializeObject(await _allCitadelOrders.Value));
                return;
            }

            using (var file = File.OpenText(filePath))
            {
                var serializer = new JsonSerializer();

                _allCitadelOrders = new LazyAsync<List<GetMarketsStructuresStructureId200Ok>>(async () =>
                    (List<GetMarketsStructuresStructureId200Ok>) serializer.Deserialize(file,
                        typeof(List<GetMarketsStructuresStructureId200Ok>)));
                await _allCitadelOrders.Value;
            }
        }

        private async Task<IEnumerable<GetMarketsStructuresStructureId200Ok>> GetCitadelBuyOrdersAsync()
        {
            return (await _allCitadelOrders.Value).Where(x => x.IsBuyOrder.Value);
        }

        private async Task<IEnumerable<GetMarketsStructuresStructureId200Ok>> GetCitadelSellOrdersAsync()
        {
            return (await _allCitadelOrders.Value).Where(x => !x.IsBuyOrder.Value);
        }
    }
}