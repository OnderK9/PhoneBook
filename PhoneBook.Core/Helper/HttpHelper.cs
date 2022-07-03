using Newtonsoft.Json;
using PhoneBook.Core.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PhoneBook.Core.Helper
{
    public class HttpHelper
    {

        public async Task<T> Get<T>(string url)
        {

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url);

            var httpClient = new HttpClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            T data = default(T);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string contentStream = httpResponseMessage.Content.ReadAsStringAsync().Result;

                data = JsonConvert.DeserializeObject<T>(contentStream);
            }

            return data;
        }
    }
}
