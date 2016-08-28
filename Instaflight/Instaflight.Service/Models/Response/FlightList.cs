using System.Collections.Generic;

namespace Instaflight.Service.Models.Response
{
    public class FlightList
    {
        public FlightList(IEnumerable<Flight> flightSegment)
        {
            FlightSegment = flightSegment;
        }

        public IEnumerable<Flight> FlightSegment { get; }
    }
}