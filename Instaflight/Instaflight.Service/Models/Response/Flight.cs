namespace Instaflight.Service.Models.Response
{
    public class Flight
    {
        public Flight(Airport departureAirport, Airport arrivalAirport)
        {
            DepartureAirport = departureAirport;
            ArrivalAirport = arrivalAirport;
        }

        public Airport DepartureAirport { get; }
        public Airport ArrivalAirport { get; }
    }
}