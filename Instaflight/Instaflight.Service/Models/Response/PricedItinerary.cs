using System.Collections.Generic;

namespace Instaflight.Service.Models.Response
{
    public class PricedItinerary
    {
        public PricedItinerary(AirItinerary airItinerary)
        {
            AirItinerary = airItinerary;
        }

        public AirItinerary AirItinerary { get; }
    }
}