using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EveClientStandard.Extensions;
using EveIndustry.Models;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;
using Newtonsoft.Json;
using RestSharp;

namespace EveIndustry
{
    public partial class IndustryManager
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string Credentials = "2590e8414d08467693e11d5e9ca22248:zBv5izRIZiiPIAf8tOAcUyeVckw0Qckfeflwg9zz";
        private CharInfo _charInfo;
        private UserToken _token;
        private MarketApi _marketApi;
        private readonly List<Item> _marketItems;
        private LazyAsync<List<GetMarketsStructuresStructureId200Ok>> _destinationOrders;

        private List<int> _highValueItems = new List<int>();

        private IndustryManager()
        {
            var byteArray = Encoding.ASCII.GetBytes(Credentials);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            _marketItems = ItemManager.GetMarketItems();
        }

        public static async Task<IndustryManager> Create(string token)
        {
            var manager = new IndustryManager();
            await manager.RefreshToken(token);
            await manager.SetCharInfo();
            manager.ConfigureApi();

            return manager;
        }

        public void Compute()
        {
            var characterApi = new CharacterApi();

            var x = characterApi.GetCharactersCharacterIdBlueprints(_charInfo.CharacterID, "tranquility", null, null, _token.AccessToken);
        }

        public async Task GetPotentialItems(int regionId, int daysToEvaluate, int minAverageVolumePerDay, int minOrdersPerDay)
        {
            var sellable = await GetSellableItems(_marketItems, regionId, daysToEvaluate, minAverageVolumePerDay, minOrdersPerDay);
        }

        public async Task<List<ItemPrice>> ComputeCurrentPrices(int buyRegionId, int sellRegionId)
        {
            InitializeCitadelOrders();
            var tasks = _marketItems.Select(item => ComputePrice(item.Id, buyRegionId, sellRegionId, 30000142, 30004759));
            return (await Task.WhenAll(tasks)).ToList();
        }

        private async Task<ItemPrice> ComputePrice(int itemId, int buyRegion, int sellRegion, int buySystemId, int sellSystemId)
        {
            return new ItemPrice()
            {
                ItemId = itemId,
                JitaPrice = await GetPriceForItemInRegion(itemId, buyRegion, buySystemId),
                OneDQPrice= await GetPriceForItemInRegion(itemId, sellRegion, sellSystemId),
            };
        }

        private void InitializeCitadelOrders()
        {
            // var structureId = new SearchApi().GetCharactersCharacterIdSearchWithHttpInfo(new List<string>(){ "structure" }, _charInfo.CharacterID, "1DQ");
            _destinationOrders = 
                new LazyAsync<List<GetMarketsStructuresStructureId200Ok>>(async () => await ApiExtension.GetAll(
                    index => _marketApi.GetMarketsStructuresStructureIdAsyncWithHttpInfo(1022734985679, page: index)));

            // _destinationOrders = await _marketApi.GetMarketsStructuresStructureIdAsync(1022734985679);
        }

        private async Task<double> GetPriceForItemInRegion(int itemId, int regionId, int systemId)
        {
            var sellOrders = await ApiExtension.GetAll(index =>
                _marketApi.GetMarketsRegionIdOrdersAsyncWithHttpInfo("sell", regionId, "tranquility", typeId: itemId, page: index));
            
            // var sellOrders = await GetAllOrders(itemId, regionId);
            var minPrice = sellOrders.Where(x => x.SystemId == systemId).OrderBy(x => x.Price).FirstOrDefault();
            return minPrice?.Price ?? double.MaxValue;
        }

        private async Task<List<GetMarketsRegionIdOrders200Ok>> GetAllOrders(int itemId, int regionId)
        {
            var result = await _marketApi.GetMarketsRegionIdOrdersAsyncWithHttpInfo("sell", regionId, "tranquility", typeId: itemId);
            var pages = int.Parse(result.Headers["X-Pages"]);
            var list = result.Data;

            var index = 1;
            while (index < pages)
            {
                index++;
                var currentPageResults =
                    await _marketApi.GetMarketsRegionIdOrdersAsync("sell", regionId, "tranquility", typeId: itemId, page: index);
                list.AddRange(currentPageResults);
            }

            return list;
        }

        private async Task<ConcurrentBag<Item>> GetSellableItems(List<Item> marketItems, int regionId, int daysToEvaluate, int minAverageVolumePerDay, int minOrdersPerDay)
        {
            var result = new ConcurrentBag<Item>();

            var tasks = marketItems.Select(async item =>
            {
                if (await HasMarket(item, regionId, daysToEvaluate, minAverageVolumePerDay, minOrdersPerDay))
                {
                    result.Add(item);
                };
            });

            await Task.WhenAll(tasks);

            //foreach (var item in marketItems)
            //{
            //    if (await HasMarket(item, regionId, daysToEvaluate, minAverageVolumePerDay, minOrdersPerDay))
            //    {
            //        result.Add(item);
            //    }
            //}

            return result;
        }

        private async Task<bool> HasMarket(Item item, int regionId, int daysToEvaluate, int minAverageVolumePerDay, int minOrdersPerDay)
        {
            try
            {
                var orders = (await _marketApi.GetMarketsRegionIdHistoryAsync(regionId, item.Id)).OrderByDescending(x => x.Date)
                    .Take(daysToEvaluate).ToList();

                return AreConsecutiveDays(orders, daysToEvaluate) 
                       && GetAverageDailyRevenue(orders) >= minAverageVolumePerDay
                       && HasMinNumberOfOrders(orders, minOrdersPerDay);
            }
            catch
            {
                return false;
            }
        }

        private static bool HasMinNumberOfOrders(List<GetMarketsRegionIdHistory200Ok> orders, int minOrdersPerDay)
        {
            return orders.Average(x => x.OrderCount).Value >= minOrdersPerDay;
        }

        private static bool AreConsecutiveDays(List<GetMarketsRegionIdHistory200Ok> orders, int daysToEvaluate)
        {
            if (orders.Count < daysToEvaluate)
            {
                return false;
            }

            var tmp = orders.First().Date - orders.Last().Date;

            return tmp.Value.TotalDays == daysToEvaluate;
        }

        private static double GetAverageDailyRevenue(List<GetMarketsRegionIdHistory200Ok> orders)
        {
            return orders.Select(x => x.Average * x.Volume).Average().Value;
        }

        private void ConfigureApi()
        {
            var api = new ApiClient();
            api.RestClient.AddDefaultHeader("User-Agent", "Ender's agent"); // Set a relevant user agent so we know which software is actually using ESI
            api.RestClient.BaseUrl = new Uri("https://esi.tech.ccp.is");
            // api.BasePath = "https://esi.tech.ccp.is";
            api.RestClient.AddDefaultHeader("access_token", _token.AccessToken);
            Configuration.Default.ApiClient = api;
            Configuration.Default.AccessToken = _token.AccessToken;
            _marketApi = new MarketApi();
        }

        private async Task SetCharInfo()
        {
            // Get the ID;
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token.AccessToken);
            var characterResponse = await client.GetStringAsync("https://login.eveonline.com/oauth/verify");
            _charInfo = JsonConvert.DeserializeObject<CharInfo>(characterResponse);
        }

        private async Task RefreshToken(string token)
        {
            var values = new Dictionary<string, string>
            {   { "grant_type", "refresh_token" },
                { "refresh_token", token }
            };

            _token = await SendTokenRequestWithValues(values);
        }

        private static async Task<UserToken> SendTokenRequestWithValues(Dictionary<string, string> values)
        {
            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("https://login.eveonline.com/oauth/token", content);

            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<UserToken>(responseString);
        }
    }
}