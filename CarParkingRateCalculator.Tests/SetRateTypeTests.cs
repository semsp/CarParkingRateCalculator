using CarParkingCalculator.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CarParkingCalculator.Tests
{
    [TestFixture]
    class SetRateTypeTests
    {
        private Mock<IRateCalculatorService> _rateCalculatorService;

        [SetUp]
        public void Setup()
        {
            _rateCalculatorService = new Mock<IRateCalculatorService>();
        }

        [Test]
        public void RateCalculation_WhenFoundTheRateType_ShouldStopCheckingTypesAndReturnResponse()
        {
            _rateCalculatorService.Setup(rc => rc.IsRateType(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(true);
            _rateCalculatorService.Setup(rc => rc.CalculateRate(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(
                new RateRequestResponse {
                    FinalRate =20,
                    RateType= Enum.GetName(typeof(RequestRateType), RequestRateType.Earlybird)
                });

            var result = new SetRateType(new List<IRateCalculatorService>() { _rateCalculatorService.Object });

            result.RateCalculation(DateTime.Now.AddHours(-7), DateTime.Now.AddHours(-1));

            _rateCalculatorService.Verify(x => x.IsRateType(It.IsAny<DateTime>(), It.IsAny<DateTime>()), Times.AtMostOnce());
            _rateCalculatorService.Verify(x => x.CalculateRate(It.IsAny<DateTime>(), It.IsAny<DateTime>()), Times.AtMostOnce());
        }
    }
}
