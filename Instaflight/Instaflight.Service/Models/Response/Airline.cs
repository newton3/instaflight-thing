namespace Instaflight.Service.Models.Response
{
    public class Airline
    {
        public Airline(string code)
        {
            Code = code;
        }

        public string Code { get; }
    }
}