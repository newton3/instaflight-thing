using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Instaflight.Service.Models.Response;
using Refit;

namespace Instaflight.Service
{
    public interface IInstaflightApi
    {
        [Headers("Authorization: Bearer")]
        [Get("/v1/shop/flights")]
        Task<InstaflightSearchResponse> SearchAsync(string origin, string destination, string departuredate, string returndate);
    }
}
