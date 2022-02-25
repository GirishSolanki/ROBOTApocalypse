using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ROBOTApocalypse.Common
{
    public static class WebApiCommon
    {
        public static T CallApi<T>(string apiUrl, string apiName, T parameter, HttpMethod httpMethod) where T : class
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);
            client.Timeout = new TimeSpan(0, 15, 0);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (httpMethod == HttpMethod.Get)
            {
                HttpResponseMessage httpResponseMessage = client.GetAsync(apiName).Result;
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var result = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<T>(result);
                }               
            }
            else if (httpMethod == HttpMethod.Post)
            {
                var json = JsonConvert.SerializeObject(parameter);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = client.PostAsync(apiName, data).Result;
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var result = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<T>(result);
                }
            }
            return null;
        }
    }
}
