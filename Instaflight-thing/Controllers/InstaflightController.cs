using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Instaflight.Service;
using Instaflight.Service.Models.Response;

namespace Instaflight_thing.Controllers
{
    public class InstaflightController : ApiController
    {
        private IInstaflightApi _instaflightApi;

        public InstaflightController(IInstaflightApi instaflightApi)
        {
            _instaflightApi = instaflightApi;
        }

        [HttpGet, Route("api/instaflight")]
        public async Task<InstaflightSearchResponse> SearchAsync(string origin, string destination, string departureDate, string returnDate)
        {
            return await _instaflightApi.SearchAsync(origin, destination, departureDate, returnDate);
        }
    }
}
