using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ITQJ.WebClient.Services
{
    public class APIClientService
    {
        public async Task<T> CallApiGetMethod<T>(string uri, string bearer = "", bool needJWT = false) where T : class
        {
            var client = new HttpClient();
            if (needJWT)
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearer);
            }

            var content = await client.GetStringAsync(uri);
            var json = JObject.Parse(content);

            T result = null;
            if (json.ContainsKey("result"))
                result = json["result"].ToObject<T>();
            else if (!json.ContainsKey("error"))
                result = json.ToObject<T>();
            else
                throw new Exception(json["error"].ToString());

            return result;
        }
    }
}
