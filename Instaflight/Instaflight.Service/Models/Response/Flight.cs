namespace Instaflight.Service.Models.Response
{
    public class Flight
    {

        public Flight(Airport departureAirport, Airport arrivalAirport, MarketingAirline marketingAirline, ArrivalTimeZone arrivalTimeZone, string departureDateTime, string arrivalDateTime, int flightNumber)
        {
            DepartureAirport = departureAirport;
            ArrivalAirport = arrivalAirport;
            MarketingAirline = marketingAirline;
            ArrivalTimeZone = arrivalTimeZone;
            DepartureDateTime = departureDateTime;
            ArrivalDateTime = arrivalDateTime;
            FlightNumber = flightNumber;
        }

        public Airport DepartureAirport { get; }
        public Airport ArrivalAirport { get; }
        public MarketingAirline MarketingAirline { get; }
        public ArrivalTimeZone ArrivalTimeZone { get; }
        public string DepartureDateTime { get; }
        public string ArrivalDateTime { get; }
        public int FlightNumber { get; }
    }
}