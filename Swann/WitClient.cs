using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Swann
{
    public class WitClient : IDisposable
    {
        private const string DefaultVersion = "20170307";
        private const string BaseUri = "https://api.wit.ai/message?v={0}&q={1}";

        private readonly HttpClient httpClient;

        public string Version { get; set; }

        public WitClient(string serverAccessToken)
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {serverAccessToken}");

            Version = DefaultVersion;
        }

        private string GetUri(string message)
        {
            var escapedMessage = Uri.EscapeDataString(message);
            return String.Format(BaseUri, Version, escapedMessage);
        }

        public async Task<WitResponse> SendMessageAsync(string message)
        {
            var response = await httpClient.GetAsync(GetUri(message));

            if(response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var witResponse = JsonConvert.DeserializeObject<WitResponse>(jsonResponse);
                return witResponse;
            }

            return null;
        }

        public void Dispose()
        {
            httpClient.Dispose();
        }
    }
}
