namespace Instaflight.Service.Models.Response
{
    public class ArrivalTimeZone
    {
        public ArrivalTimeZone(int gmtOffset)
        {
            GMTOffset = gmtOffset;
        }

        public int GMTOffset { get; }
    }
}