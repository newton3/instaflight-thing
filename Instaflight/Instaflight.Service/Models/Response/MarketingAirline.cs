namespace Instaflight.Service.Models.Response
{
    public class MarketingAirline
    {
        public MarketingAirline(string code)
        {
            Code = code;
        }

        public string Code { get; }
    }
}