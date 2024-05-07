using System;

namespace CarParkingCalculator.Services
{
    public class EarlyBirdService:IRateCalculatorService
    {
        public RateRequestResponse CalculateRate(DateTime entryDateTime, DateTime exitDateTime)
        {
            return new RateRequestResponse { FinalRate = 13, RateType= Enum.GetName(typeof(RequestRateType), RequestRateType.Earlybird)} ;
        }

        public bool IsRateType(DateTime entryDateTime, DateTime exitDateTime)
        {
            var startTime = new DateTime(entryDateTime.Year, entryDateTime.Month, entryDateTime.Day, 6, 0, 0);
            var exitTime = new DateTime(entryDateTime.Year, entryDateTime.Month, entryDateTime.Day, 15, 30, 0);
            if (!(entryDateTime.DayOfWeek == DayOfWeek.Saturday || entryDateTime.DayOfWeek == DayOfWeek.Sunday))
            {
                if (entryDateTime >= startTime && entryDateTime <= startTime.AddHours(3))
                {
                    return (exitDateTime >= exitTime && exitDateTime <= exitTime.AddHours(8));
                }
            }
            return false;   
        }
    }
}
