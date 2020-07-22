using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ITQJ.WebPWA.Services
{
    public class APIClientService : Controller
    {
        // Metodo generico para extraer los datos de un endpoint del API.
        public async Task<T> CallApiGetMethod<T>(string uri, bool needJWT = false) where T : class
        {
            var client = new HttpClient();
            if (needJWT)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }

            var content = await client.GetStringAsync(uri);
            var json = new JObject(content);

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
