using System;

namespace CarParkingCalculator.Services
{
    public class NightRateService : IRateCalculatorService
    {
        public RateRequestResponse CalculateRate(DateTime entryDateTime, DateTime exitDateTime)
        {
            return new RateRequestResponse { FinalRate = 6.5, RateType =  Enum.GetName(typeof(RequestRateType), RequestRateType.NightRate) };
        }

        public bool IsRateType(DateTime entryDateTime, DateTime exitDateTime)
        {
            //This condition is not clear
            var startTime = new DateTime(entryDateTime.Year, entryDateTime.Month, entryDateTime.Day, 18, 0, 0);
            var exitTime = new DateTime(entryDateTime.Year, entryDateTime.Month, entryDateTime.Day, 15, 30, 0);

            if(entryDateTime.DayOfWeek != DayOfWeek.Saturday || entryDateTime.DayOfWeek != DayOfWeek.Sunday)
            {
                return ((entryDateTime >= startTime && entryDateTime <= startTime.AddHours(6)) && (exitDateTime >= exitTime && exitDateTime <= exitTime.AddHours(8)));
            }

            return false;
        }
    }
}
