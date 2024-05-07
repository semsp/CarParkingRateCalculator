using System;

namespace CarParkingCalculator.Services
{
    public interface IRateCalculatorService
    {
        /// <summary>
        /// Calculates the parking rate based on the entry and exit times
        /// </summary>
        /// <param name="entryDateTime"></param>
        /// <param name="exitdateTime"></param>
        /// <returns></returns>
        RateRequestResponse CalculateRate(DateTime entryDateTime, DateTime exitDateTime);

        /// <summary>
        /// Selects the rate type based on the entry and exit time
        /// </summary>
        /// <param name="entryDateTime"></param>
        /// <param name="exitdateTime"></param>
        /// <returns></returns>
        bool IsRateType(DateTime entryDateTime, DateTime exitDateTime);

    }
}
