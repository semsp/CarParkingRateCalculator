using CarParkingCalculator.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CarParkingCalculator.Tests
{
    [TestClass]
    public class NightRateServiceTests
    {
        private NightRateService _nightRateService;

        [TestInitialize]
        public void Setup()
        {
            _nightRateService = new NightRateService();
        }

        [TestMethod]
        public void IsRateType_WhenEntryAndExitTimesAreInSpeciFiedTimes_ReturnTrue()
        {

            bool result = _nightRateService.IsRateType(new DateTime(2024, 05, 05, 18, 30, 25), new DateTime(2024, 05, 05, 22, 30, 25));

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void CalculateRate_WhenEntryAndExitTimesAreInSpeciFiedTimes_ReturnCorrectAmount()
        {

            var result = _nightRateService.CalculateRate(new DateTime(2024, 05, 06, 19, 30, 25), new DateTime(2024, 05, 06, 21, 30, 25));

            Assert.AreEqual(6.5, result.FinalRate);

        }

        [TestMethod]
        public void IsRateType_WhenEntryTimeInSpeciFiedTimesButNotExitTime_ReturnFalse()
        {

            bool result = _nightRateService.IsRateType(new DateTime(2024, 05, 06, 19, 30, 25), new DateTime(2024, 05, 07, 02, 30, 25));

            Assert.IsFalse(result);

        }

        [TestMethod]
        public void IsRateType_WhenExitTimeInSpeciFiedTimesButNotEntryTime_ReturnFalse()
        {

            bool result = _nightRateService.IsRateType(new DateTime(2024, 05, 06, 16, 30, 25), new DateTime(2024, 05, 06, 22, 30, 25));

            Assert.IsFalse(result);

        }

    }
}
