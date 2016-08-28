using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Instaflight.Service
{
    public class Token
    {
        public Token(string accessToken, string tokenType, int expiresIn)
        {
            AccessToken = accessToken;
            TokenType = tokenType;
            ExpiresIn = expiresIn;
        }

        [JsonProperty("access_token")]
        public string AccessToken { get; }

        [JsonProperty("token_type")]
        public string TokenType { get; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; }
    }
}
