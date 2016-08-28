using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NLog;

namespace Instaflight.Service
{
    public class TokenAuthenticationHandler : HttpClientHandler
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly string _token;

        public TokenAuthenticationHandler(string token)
        {
            _token = token;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var auth = request.Headers.Authorization;
            if (auth.Scheme == "Basic")
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Basic", _token);
                Logger.Debug($"Injecting static token ({_token}) into request {request.RequestUri}");
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}
