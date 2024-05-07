using CarParkingCalculator.Services;
using NUnit.Framework;
using System;

namespace CarParkingCalculator.Tests
{
    [TestFixture]
    public class EarlyBirdServiceTests
    {
        private EarlyBirdService _earlyBirdService;

        [SetUp]
        public void Setup()
        {
            _earlyBirdService = new EarlyBirdService();
        }

        [Test]
        public void IsRateType_WhenEntryAndExitTimesAreInSpeciFiedTimes_ReturnTrue()
        {

            bool result = _earlyBirdService.IsRateType(new DateTime(2024,05,06,08,30,25), new DateTime(2024, 05, 06, 16, 30, 25));

            Assert.That(result, Is.True);

        }

        [Test]
        public void CalculateRate_WhenEntryAndExitTimesAreInSpeciFiedTimes_ReturnSpecifiedAmount()
        {

            var result = _earlyBirdService.CalculateRate(new DateTime(2024, 05, 06, 08, 30, 25), new DateTime(2024, 05, 06, 16, 30, 25));

            Assert.AreEqual(13, result.FinalRate);

        }

        [Test]
        public void IsRateType_WhenEntryTimeInSpeciFiedTimesButNotExitTime_ReturnFalse()
        {

            bool result = _earlyBirdService.IsRateType(new DateTime(2024, 05, 06, 08, 30, 25), new DateTime(2024, 05, 06, 12, 30, 25));

            Assert.That(result==false);

        }


        [Test]
        public void IsRateType_WhenExitTimeInSpeciFiedTimesButNotExitTime_ReturnFalse()
        {

            bool result = _earlyBirdService.IsRateType(new DateTime(2024, 05, 06, 10, 30, 25), new DateTime(2024, 05, 06, 16, 30, 25));

            Assert.IsFalse(result);

        }

        [Test]
        public void IsRateType_WhenEntryAndExitTimeIsWeekend_ReturnFalse()
        {
            
            bool result = _earlyBirdService.IsRateType(new DateTime(2024, 05, 04, 10, 30, 25), new DateTime(2024, 05, 05, 16, 30, 25));

            Assert.IsFalse(result);

        }

        [Test]
        public void IsRateType_WhenEntryTimeIsWeekendAndExitTimeIsWeekday_ReturnFalse()
        {

            bool result = _earlyBirdService.IsRateType(new DateTime(2024, 05, 04, 10, 30, 25), new DateTime(2024, 05, 06, 16, 30, 25));

            Assert.IsFalse(result);

        }

        [Test]
        public void IsRateType_WhenEntryTimeIsWeekdayAndExitTimeIsWeekEnd_ReturnFalse()
        {

            bool result = _earlyBirdService.IsRateType(new DateTime(2024, 05, 03, 10, 30, 25), new DateTime(2024, 05, 04, 16, 30, 25));

            Assert.IsFalse(result);

        }
    }
}
