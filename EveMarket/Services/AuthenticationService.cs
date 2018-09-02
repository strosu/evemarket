using EveMarket.Models;
using IO.Swagger.Api;
using IO.Swagger.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EveMarket.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string Credentials = "2590e8414d08467693e11d5e9ca22248:zBv5izRIZiiPIAf8tOAcUyeVckw0Qckfeflwg9zz";

        public AuthenticationService()
        {
            var byteArray = Encoding.ASCII.GetBytes(Credentials);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        }

        public async Task LogIn()
        {
            // Get from DB
            var refreshToken = "D98EYs8SzDdFECDZq2Nl-Ucr_ZbBWhjSA1bFEcAkbxW9kWcAmyo5UQRhoIGGzVZQ0";
            var result = await RefreshToken(refreshToken);
            await GetBlueprints(result);
        }

        public async Task LogIn(string code)
        {
            var result = await GetToken(code);

            await GetBlueprints(result);
        }

        private static async Task GetBlueprints(UserToken result)
        {
            // Get the ID;
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", result.AccessToken);
            var characterResponse = await client.GetStringAsync("https://login.eveonline.com/oauth/verify");
            var character = JsonConvert.DeserializeObject<CharInfo>(characterResponse);

            var api = new ApiClient();
            api.RestClient.AddDefaultHeader("User-Agent", "Ender's agent"); // Set a relevant user agent so we know which software is actually using ESI
            api.BasePath = "https://esi.tech.ccp.is";
            api.AddDefaultHeader("access_token", result.AccessToken);
            Configuration.DefaultApiClient = api;
            var characterApi = new CharacterApi();

            var x = characterApi.GetCharactersCharacterIdBlueprints(character.CharacterID, "tranquility", null, null, result.AccessToken);
        }

        private async Task<UserToken> GetToken(string code)
        {
            var values = new Dictionary<string, string>
            {   { "grant_type", "authorization_code" },
                { "code", code }
            };

            return await SendTokenRequestWithValues(values);
        }

        private async Task<UserToken> RefreshToken(string refreshToken)
        {
            var values = new Dictionary<string, string>
            {   { "grant_type", "refresh_token" },
                { "refresh_token", refreshToken }
            };

            return await SendTokenRequestWithValues(values);
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
