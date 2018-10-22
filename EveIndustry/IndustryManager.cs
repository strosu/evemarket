using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EveIndustry.Models;
using IO.Swagger.Api;
using IO.Swagger.Client;
using Newtonsoft.Json;

namespace EveIndustry
{
    public class IndustryManager
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string Credentials = "2590e8414d08467693e11d5e9ca22248:zBv5izRIZiiPIAf8tOAcUyeVckw0Qckfeflwg9zz";
        private CharInfo _charInfo;
        private UserToken _token;

        private const int DelveRegionId = 10000060;

        private const double MinVolumePerDay = 1000000000;
        private List<int> _highValueItems = new List<int>();

        private IndustryManager()
        {
            var byteArray = Encoding.ASCII.GetBytes(Credentials);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
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

        public void GetPotentialItems()
        {

        }

        private void ConfigureApi()
        {
            var api = new ApiClient();
            api.RestClient.AddDefaultHeader("User-Agent", "Ender's agent"); // Set a relevant user agent so we know which software is actually using ESI
            api.BasePath = "https://esi.tech.ccp.is";
            api.AddDefaultHeader("access_token", _token.AccessToken);
            Configuration.DefaultApiClient = api;
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