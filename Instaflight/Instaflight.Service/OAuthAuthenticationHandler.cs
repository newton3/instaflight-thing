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
    public class OauthAuthenticationHandler : HttpClientHandler
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IInstaflightAuthApi _client;
        private DateTime _expiresAt;
        private string _token;

        public OauthAuthenticationHandler(IInstaflightAuthApi client)
        {
            _client = client;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var auth = request.Headers.Authorization;
            if (auth.Scheme == "Bearer")
            {
                _token = await GetToken(cancellationToken);
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                Logger.Debug($"Injecting oauth token ({_token}, expire: {_expiresAt}) into request {request.RequestUri}");

            }
            return await base.SendAsync(request, cancellationToken);
        }

        private async Task<string> GetToken(CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(_token) && _expiresAt <= DateTime.UtcNow) return _token;

            var token = await _client.GetTokenAsync("grant_type=client_credentials");
            Logger.Debug($"Got Bearer Token: {token.AccessToken}, expires in {token.ExpiresIn}");
            //if (token.IsError)
            //    throw new HttpRequestException($"Cannot get token: {token.Error}");
            _token = token.AccessToken;
            _expiresAt = DateTime.UtcNow.AddSeconds(token.ExpiresIn);

            return _token;
        }
    }
}
