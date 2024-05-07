using CarParkingCalculator.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CarParkingCalculator.Tests
{
    [TestClass]
    public class WeekendServiceTests
    {
        private WeekendRateService _weekendRateService;

        [TestInitialize]
        public void Setup()
        {
            _weekendRateService = new WeekendRateService();
        }

        [TestMethod]
        public void IsRateType_WhenEntryAndExitTimesAreInSpeciFiedTimes_ReturnTrue()
        {

            bool result = _weekendRateService.IsRateType(new DateTime(2024, 05, 04, 18, 30, 25), new DateTime(2024, 05, 05, 22, 30, 25));

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void CalculateRate_WhenEntryAndExitTimesAreInSpeciFiedTimes_ReturnCorrectAmount()
        {

            var result = _weekendRateService.CalculateRate(new DateTime(2024, 05, 05, 19, 30, 25), new DateTime(2024, 05, 05, 21, 30, 25));

            Assert.AreEqual(10, result.FinalRate);

        }

        [TestMethod]
        public void IsRateType_WhenEntryAndExitTimeIsWeekend_ReturnTrue()
        {

            bool result = _weekendRateService.IsRateType(new DateTime(2024, 05, 04, 10, 30, 25), new DateTime(2024, 05, 05, 16, 30, 25));

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void IsRateType_WhenEntryTimeIsWeekendAndExitTimeIsWeekday_ReturnFalse()
        {

            bool result = _weekendRateService.IsRateType(new DateTime(2024, 05, 04, 10, 30, 25), new DateTime(2024, 05, 06, 16, 30, 25));

            Assert.IsFalse(result);

        }

        [TestMethod]
        public void IsRateType_WhenEntryTimeIsWeekdayAndExitTimeIsWeekEnd_ReturnFalse()
        {

            bool result = _weekendRateService.IsRateType(new DateTime(2024, 05, 03, 10, 30, 25), new DateTime(2024, 05, 04, 16, 30, 25));

            Assert.IsFalse(result);

        }
    }
}
