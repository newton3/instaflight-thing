using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NLog;

namespace Instaflight.Service
{
    public class OauthAuthenticationHandler : HttpClientHandler
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IInstaflightAuthApi _client;
        private DateTime _expiresAt;
        private static volatile string _token;
        private static object _syncRoot = new Object();

        public OauthAuthenticationHandler(IInstaflightAuthApi client)
        {
            _client = client;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var auth = request.Headers.Authorization;
            if (auth.Scheme == "Bearer")
            {
                await GetToken(cancellationToken);
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                Logger.Debug($"Injecting oauth token ({_token}, expire: {_expiresAt}) into request {request.RequestUri}");

            }
            return await base.SendAsync(request, cancellationToken);
        }

        private async Task GetToken(CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(_token) || _expiresAt <= DateTime.UtcNow)
            {
                var sw = new Stopwatch();
                sw.Start();
                var token = await _client.GetTokenAsync(new Dictionary<string, object>()
                {
                    { "grant_type", "client_credentials"}
                });
                sw.Stop();
                Logger.Debug($"Got Bearer Token in {sw.ElapsedMilliseconds} ms: {token.AccessToken}, expires in {token.ExpiresIn}");

                lock (_syncRoot)
                {
                    if (string.IsNullOrEmpty(_token) || _expiresAt <= DateTime.UtcNow)
                    {
                        _token = token.AccessToken;
                        _expiresAt = DateTime.UtcNow.AddSeconds(token.ExpiresIn);
                    }
                }
            }
        }
    }
}
