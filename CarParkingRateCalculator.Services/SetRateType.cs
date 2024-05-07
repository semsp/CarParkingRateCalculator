using System;
using System.Collections.Generic;

namespace CarParkingCalculator.Services
{
    public class SetRateType : ISetRateType
    {
        private readonly IEnumerable<IRateCalculatorService> _rateCalculatorServices;

        public SetRateType(IEnumerable<IRateCalculatorService> rateCalculatorServices)
        {
            _rateCalculatorServices = rateCalculatorServices;
        }

        public RateRequestResponse RateCalculation(DateTime entryDateTime, DateTime exitDateTime)
        {
            IRateCalculatorService setRate = null;

            foreach (var calc in _rateCalculatorServices)
            {
                if (calc.IsRateType(entryDateTime, exitDateTime))
                {
                    setRate = calc;
                    break;
                }
            }

            return setRate.CalculateRate(entryDateTime, exitDateTime);
        }

    }
}
