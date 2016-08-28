using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;

namespace Instaflight.Service
{
    public static class ServiceFactory
    {
        public static T Service<T>(string baseUrl)
        {
            return RestService.For<T>(baseUrl, new RefitSettings
            {
                JsonSerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                }
            });
        }

        public static T ServiceWithToken<T>(string baseUrl, string token)
        {
            return RestService.For<T>(new HttpClient(new TokenAuthenticationHandler(token))
            {
                BaseAddress = new Uri(baseUrl)
            },
            new RefitSettings
            {
                JsonSerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                }
            });
        }

        public static T ServiceWithOauth<T>(string baseUrl)
        {
            const string clientId = "V1:tchxizyztahatc5v:DEVCENTER:EXT";
            const string secret = "PvF5N4wo";
            const string token = clientId + ":" + secret;

            var bytes = Encoding.UTF8.GetBytes(token);
            var token64 = Convert.ToBase64String(bytes);

            var authApi = ServiceWithToken<IInstaflightAuthApi>(baseUrl, token64);

            return RestService.For<T>(
                new HttpClient(new OauthAuthenticationHandler(authApi)),
                new RefitSettings
                {
                    JsonSerializerSettings = new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    }
                });
        }
    }
}
