using EveIndustry.Models;
using IO.Swagger.Client;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EveIndustry.Client
{
    public class ClientManager
    {
        private static readonly HttpClient Client = new HttpClient();
        private const string Credentials = "2590e8414d08467693e11d5e9ca22248:zBv5izRIZiiPIAf8tOAcUyeVckw0Qckfeflwg9zz";
        private const string Token = "MTAnnx9LZz-XAFZ1pEQkK-YRJw2Kj5AjGMcZOd4ZwsUk8iceeTKhOQvCzAv1EafA0";
        private UserToken _token;

        public CharInfo CharInfo { get; private set; }

        private static void InitializeClient()
        {
            var byteArray = Encoding.ASCII.GetBytes(Credentials);
            Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        }

        public static async Task<ClientManager> Build()
        {
            var client = new ClientManager();
            InitializeClient();
            await client.RefreshToken(Token);
            client.ConfigureApi();
            await client.SetCharInfo();

            return client;
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
        }

        private async Task SetCharInfo()
        {
            // Get the ID;
            Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token.AccessToken);
            var characterResponse = await Client.GetStringAsync("https://login.eveonline.com/oauth/verify");
            CharInfo = JsonConvert.DeserializeObject<CharInfo>(characterResponse);
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

            var response = await Client.PostAsync("https://login.eveonline.com/oauth/token", content);

            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<UserToken>(responseString);
        }
    }
}