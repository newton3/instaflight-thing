using System.Collections.Generic;

namespace Instaflight.Service.Models.Response
{
    public class InstaflightSearchResponse
    {
        public InstaflightSearchResponse(IEnumerable<PricedItinerary> pricedItineraries, string returnDateTime, string departureDateTime, string destinationLocation, string originLocation)
        {
            PricedItineraries = pricedItineraries;
            ReturnDateTime = returnDateTime;
            DepartureDateTime = departureDateTime;
            DestinationLocation = destinationLocation;
            OriginLocation = originLocation;
        }

        public IEnumerable<PricedItinerary> PricedItineraries { get; }
        public string ReturnDateTime { get; }
        public string DepartureDateTime { get; }
        public string DestinationLocation { get; }
        public string OriginLocation { get; }
    }
}