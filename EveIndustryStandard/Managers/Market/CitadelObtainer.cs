using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EveClientStandard.Extensions;
using EveIndustryStandard.Helpers;
using IO.Swagger.Api;
using IO.Swagger.Model;
using Newtonsoft.Json;

namespace EveIndustryStandard.Managers.Market
{
    public class CitadelObtainer : IMarketObtainer
    {
        private readonly MarketApi _marketApi;
        private Dictionary<int, List<Order>> _localSellPrices = new Dictionary<int, List<Order>>();
        private Dictionary<int, List<Order>> _localBuyPrices = new Dictionary<int, List<Order>>();

        private LazyAsync<List<GetMarketsStructuresStructureId200Ok>> _allCitadelOrders;

        private CitadelObtainer(MarketApi marketApi)
        {
            _marketApi = marketApi;
        }

        public static async Task<CitadelObtainer> BuildAsync(MarketApi marketApi, bool refreshCitadelData)
        {
            var result = new CitadelObtainer(marketApi);
            return await result.InitializeCitadelOrdersAsync(refreshCitadelData);
        }

        public double GetBuyingPriceViaBuyOrder(int itemId, int amount)
        {
            if (!_localBuyPrices.TryGetValue(itemId, out var orders))
            {
                return double.MaxValue;
            }

            // We can buy a presumably "infinite" amount, the only constraint is to have a higher price than the most expensive buy order
            return orders.OrderBy(x => x.Price).FirstOrDefault().Price + 0.01;
        }

        public bool CanBuyHere(int itemId, int amount)
        {
            if (!_localBuyPrices.ContainsKey(itemId)) return false;

            double availableAmount = _localSellPrices[itemId].Select(x => (double)x.Amount).Sum();
            return availableAmount >= amount;
        }

        public double GetBuyingPrice(int itemId, int amount)
        {
            if (!CanBuyHere(itemId, amount)) return double.MaxValue;

            var totalPrice = 0d;
            var toBuy = amount;

            for (var i = 0; i < _localSellPrices[itemId].Count && toBuy > 0; i++)
            {
                var currentOrder = _localSellPrices[itemId][i];
                if (currentOrder.Amount > toBuy)
                {
                    currentOrder.Amount -= toBuy;
                    return totalPrice + toBuy * currentOrder.Price;
                }

                toBuy -= currentOrder.Amount;
                totalPrice += currentOrder.Amount * currentOrder.Price;
                _localSellPrices[itemId].Remove(currentOrder);
            }

            return totalPrice;
        }

        private async Task<CitadelObtainer> InitializeCitadelOrdersAsync(bool refreshCitadelData)
        {
            await GetOrdersAsync(refreshCitadelData);

            _localSellPrices = (await GetCitadelSellOrdersAsync()).GetOrdersAndApplyMapping2(x => x.OrderBy(y => y.Price).ToList());

            _localBuyPrices = (await GetCitadelBuyOrdersAsync()).GetOrdersAndApplyMapping2(x => x.OrderBy(y => y.Price).ToList());

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