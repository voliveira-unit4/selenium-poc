using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Text;
using System.Net.Http;

namespace selenium_poc_sr.helpers
{
    public class WebhookTrigger
    {
        private readonly HttpClient client;
        private readonly string url;

        public WebhookTrigger(HttpClient client, string url)
        {
            this.client = client;
            this.url = url; 
        }

        public string Trigger()
        {
            string triggerResponse = string.Empty;

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "application/json");
            request.Content = new StringContent("{\"command\": \"execute\"}", Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.Send(request);
            Stream stream = response.Content.ReadAsStream();

            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                triggerResponse = reader.ReadToEnd();
            }

            return triggerResponse;
        }
    }
}
