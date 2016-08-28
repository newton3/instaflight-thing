using System.Collections.Generic;

namespace Instaflight.Service.Models.Response
{
    public class OriginDestinationOptions
    {
        public OriginDestinationOptions(IEnumerable<FlightList> originDestinationOption)
        {
            OriginDestinationOption = originDestinationOption;
        }

        public IEnumerable<FlightList> OriginDestinationOption { get; }
    }
}