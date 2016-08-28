namespace Instaflight.Service.Models.Response
{
    public class TpaExtension
    {
        public TpaExtension(Airline validatingCarrier)
        {
            ValidatingCarrier = validatingCarrier;
        }

        public Airline ValidatingCarrier { get; }
    }
}