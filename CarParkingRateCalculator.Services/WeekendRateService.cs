using System;

namespace CarParkingCalculator.Services
{
    public class WeekendRateService : IRateCalculatorService
    {
        public RateRequestResponse CalculateRate(DateTime entryDateTime, DateTime exitDateTime)
        {
            return new RateRequestResponse { FinalRate = 10, RateType = Enum.GetName(typeof(RequestRateType), RequestRateType.WeekendRate) };
        }

        public bool IsRateType(DateTime entryDateTime, DateTime exitDateTime)
        {

            if (entryDateTime.DayOfWeek == DayOfWeek.Saturday || entryDateTime.DayOfWeek == DayOfWeek.Sunday)
            {
                return (exitDateTime.DayOfWeek == DayOfWeek.Saturday || exitDateTime.DayOfWeek == DayOfWeek.Sunday);
            }

            return false;
        }
    }
}
