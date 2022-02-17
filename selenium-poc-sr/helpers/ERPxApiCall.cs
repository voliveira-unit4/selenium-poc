using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.Net.Http;
using System.IO;
using System.Text;


namespace selenium_poc_sr.helpers
{
    public class ERPxAuthResponse
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string token_type { get; set; }
        public string scope { get; set; }
    }
    public class ERPxApiCall
    {
        private readonly HttpClient client;
        private readonly string authUrl;
        private readonly string clientId;
        private readonly string clientSecret;

        public ERPxApiCall(HttpClient client, string authUrl, string clientId, string clientSecret)
        {
            this.client = client;
            this.authUrl = authUrl;
            this.clientId = clientId;
            this.clientSecret = clientSecret;
        }

        private string Authenticate()
        {
            ERPxAuthResponse authResponse;
            string strResponse = string.Empty;

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, authUrl);
            request.Headers.Add("Accept", "application/json");
            request.Content = new StringContent($"client_id={clientId}&client_secret={clientSecret}&scope=u4erp&grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded");
            HttpResponseMessage response = client.Send(request);
            Stream stream = response.Content.ReadAsStream();

            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                strResponse = reader.ReadToEnd();
            }
            authResponse = JsonConvert.DeserializeObject<ERPxAuthResponse>(strResponse);
            return authResponse.access_token;
        }

        public string Get(string url)
        {
            string strResponse = string.Empty;
            string token = Authenticate();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Authorization", $"Bearer {token}");
            HttpResponseMessage response = client.Send(request);
            Stream stream = response.Content.ReadAsStream();

            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                strResponse = reader.ReadToEnd();
            }

            return strResponse;
        }
    }
}
