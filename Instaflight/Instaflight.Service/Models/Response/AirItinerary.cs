namespace Instaflight.Service.Models.Response
{
    public class AirItinerary
    {
        public AirItinerary(OriginDestinationOptions originDestinationOptions)
        {
            OriginDestinationOptions = originDestinationOptions;
        }

        public OriginDestinationOptions OriginDestinationOptions { get; }
    }
}