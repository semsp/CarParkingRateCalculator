using CarParkingCalculator.Api.Models;
using CarParkingCalculator.Controllers;
using CarParkingCalculator.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;

namespace CarParkingCalculator.Tests
{
    [TestFixture]
    class RateCalculatorControllerTests
    {
        private Mock<ILogger<RateCalculatorController>> _loggerMock;
        private Mock<ISetRateType> _setRateType;
        private RateCalculatorController _controller;

        [SetUp]
        public void Setup()
        {
            // _setRateType = new SetRateType();
            _loggerMock = new Mock<ILogger<RateCalculatorController>>();
            _setRateType = new Mock<ISetRateType>();
            _controller = new RateCalculatorController(_loggerMock.Object, _setRateType.Object);
        }

        [Test]
        public void Get_WhenPassedNull_ReturnsBadRequestResult()
        {
            var result = _controller.Get(null);
            //BadRequest
            Assert.That(result, Is.TypeOf<BadRequestObjectResult>());
            //BadRequest or one of its derivatives
            //Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }

        [Test]
        public void Get_WhenPassedMinDateTimes_ReturnsBadRequestResult()
        {
            var result = _controller.Get(new RateRequest());
 
            Assert.IsInstanceOf<BadRequestObjectResult>(result);

            var validationResult = result as BadRequestObjectResult;

            Assert.AreEqual("Invalid dates", validationResult.Value);
        }


        [Test]
        public void Get_WhenEntryTimeGreaterThanExitTime_ReturnsBadRequestResult()
        {
            var result = _controller.Get(new RateRequest { EntryDateTime= DateTime.Now.AddHours(5), ExitDateTime=DateTime.Now});

            Assert.IsInstanceOf<BadRequestObjectResult>(result);

            var validationResult = result as BadRequestObjectResult;

            Assert.AreEqual("Car Park Entry Time cannot be greater than Exit Time", validationResult.Value);
        }

        [Test]
        public void Get_WhenPassedAcceptedEntryAndExitTimes_ReturnOkWithAmountChargedBasedOnTimes()
        {
            _setRateType.Setup(sr => sr.RateCalculation(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(
                new RateRequestResponse { 
                    FinalRate=20,
                    RateType= Enum.GetName(typeof(RequestRateType), RequestRateType.Earlybird)
                });

            var result = _controller.Get(new RateRequest { EntryDateTime = DateTime.Now.AddHours(-8), ExitDateTime = DateTime.Now.AddHours(-1) });

            var exceptionResult = result as OkObjectResult;

            Assert.AreEqual(200, exceptionResult.StatusCode);
        }

        [Test]
        public void Get_WhenExceptionOccured_ReturnInternalServerError()
        {
            _setRateType.Setup(sr => sr.RateCalculation(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Throws<Exception>();
            var result = _controller.Get(new RateRequest { EntryDateTime = DateTime.Now.AddHours(-8), ExitDateTime = DateTime.Now.AddHours(-1)});

            var exceptionResult = result as ObjectResult;

            Assert.AreEqual(500, exceptionResult.StatusCode);
            Assert.AreEqual("Error retrieving the calculations", exceptionResult.Value);

        }

    }
}
