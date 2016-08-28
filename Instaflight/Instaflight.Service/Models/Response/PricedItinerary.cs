using System.Collections.Generic;
using Newtonsoft.Json;

namespace Instaflight.Service.Models.Response
{
    public class PricedItinerary
    {
        public PricedItinerary(AirItinerary airItinerary, TpaExtension tpaExtension, int sequenceNumber, AirItineraryPricingInfo airItineraryPricingInfo, TicketingInfo ticketingInfo)
        {
            AirItinerary = airItinerary;
            TpaExtension = tpaExtension;
            SequenceNumber = sequenceNumber;
            AirItineraryPricingInfo = airItineraryPricingInfo;
            TicketingInfo = ticketingInfo;
        }

        public AirItinerary AirItinerary { get; }

        [JsonProperty("TPA_Extensions")]
        public TpaExtension TpaExtension { get; }

        public int SequenceNumber { get; }

        public AirItineraryPricingInfo AirItineraryPricingInfo { get; }

        public TicketingInfo TicketingInfo { get; }
    }
}