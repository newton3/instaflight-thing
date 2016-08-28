using System.Collections.Generic;

namespace Instaflight.Service.Models.Response
{
    public class InstaflightSearchResponse
    {
        public InstaflightSearchResponse(IEnumerable<PricedItinerary> pricedItineraries)
        {
            PricedItineraries = pricedItineraries;
        }

        public IEnumerable<PricedItinerary> PricedItineraries { get; }
    }
}