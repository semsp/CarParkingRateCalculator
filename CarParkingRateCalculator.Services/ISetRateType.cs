using System;

namespace CarParkingCalculator.Services
{
    public interface ISetRateType
    {
        RateRequestResponse RateCalculation(DateTime entryDateTime, DateTime exitDateTime);
    }
}