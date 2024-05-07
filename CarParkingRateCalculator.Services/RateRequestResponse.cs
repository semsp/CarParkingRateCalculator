namespace CarParkingCalculator.Services
{
    public enum RequestRateType
    {
        Earlybird,
        NightRate,
        WeekendRate,
        StandardRate
    }

    public class RateRequestResponse
    {
        public double FinalRate { get; set; }

        public string RateType { get; set; }
    }
}
