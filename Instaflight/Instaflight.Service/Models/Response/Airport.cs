namespace Instaflight.Service.Models.Response
{
    public class Airport
    {
        public Airport(string locationCode)
        {
            LocationCode = locationCode;
        }

        public string LocationCode { get; }
    }
}