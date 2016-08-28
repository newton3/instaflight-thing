using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Instaflight.Service;

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
        public async Task<InstaflightSearchResponse> SearchAsync()
        {
            return await _instaflightApi.SearchAsync();
        }
    }
}
