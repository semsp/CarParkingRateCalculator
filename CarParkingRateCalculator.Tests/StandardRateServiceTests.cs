using CarParkingCalculator.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CarParkingCalculator.Tests
{
    [TestClass]
    public class StandardRateServiceTests
    {
        private StandardRateService _standardRateService;

        [TestInitialize]
        public void Setup()
        {
            _standardRateService = new StandardRateService();
        }

        [TestMethod]
        public void IsRateType_WhenEntryAndExitTimesAreInSpeciFiedTimes_ReturnTrue()
        {

            bool result = _standardRateService.IsRateType(new DateTime(2024, 05, 02, 10, 45, 25), new DateTime(2024, 05, 05, 22, 30, 25));

            Assert.IsTrue(result);

        }

        [DataTestMethod]
        [DataRow(2024, 05, 02, 10,30,30,25,5,DisplayName ="LessThanHour")]
        [DataRow(2024, 05, 02, 10, 30, 30, 75, 10, DisplayName = "1-2Hours")]
        [DataRow(2024, 05, 02, 10, 30, 30, 135, 15, DisplayName = "2-3Hours")]
        [DataRow(2024, 05, 02, 10, 30, 30, 185, 20, DisplayName = "3+Hours")]
        public void CalculateRate_WhenEntryAndExitTimesAreInSpeciFiedTimes_ReturnCorrectAmount(int year, int month, int day,int hour, int mins, int secs, int addmins, double expectedresult)
        {
            var EntryDateTime = new DateTime(year, month, day, hour, mins, secs);
            var ExitDateTime = EntryDateTime.AddMinutes(addmins);
            var result = _standardRateService.CalculateRate(EntryDateTime, ExitDateTime );

            Assert.AreEqual(expectedresult, result.FinalRate);

        }

        [TestMethod]
        public void IsRateType_WhenEntryAndExitTimeIsWeekend_ReturnFalse()
        {

            bool result = _standardRateService.IsRateType(new DateTime(2024, 05, 04, 10, 30, 25), new DateTime(2024, 05, 05, 16, 30, 25));

            Assert.IsFalse(result);

        }

    }
}
