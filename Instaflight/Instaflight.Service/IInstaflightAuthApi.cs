using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;

namespace Instaflight.Service
{
    public interface IInstaflightAuthApi
    {
        [Headers("Authorization: Basic")]
        [Post("/v2/auth/token")]
        Task<Token> GetTokenAsync(string grantType);
    }
}
