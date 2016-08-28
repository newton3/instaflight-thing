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

        public static T ServiceWithOauth<T>(string baseUrl, string clientId, string secret)
        {
            var client64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(clientId));
            var secret64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(secret));

            var token64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(client64 + ":" + secret64));

            var authApi = ServiceWithToken<IInstaflightAuthApi>(baseUrl, token64);

            return RestService.For<T>(
                new HttpClient(new OauthAuthenticationHandler(authApi))
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
    }
}
