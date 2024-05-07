using CarParkingCalculator.Api.Models;
using CarParkingCalculator.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace CarParkingCalculator.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RateCalculatorController : ControllerBase
    {
        private readonly ILogger<RateCalculatorController> _logger;
        private readonly ISetRateType _setRateType;

        public RateCalculatorController(ILogger<RateCalculatorController> logger, ISetRateType setRateType)
        {
            _logger = logger;
            _setRateType = setRateType;
        }

        /// <summary>
        /// Calculate the car parking rate based on the entry time and exit time
        /// </summary>
        /// <param name="rateRequest"></param>
        /// <returns></returns>
        [HttpGet]
        [Microsoft.AspNetCore.Authorization.AllowAnonymous]
        public IActionResult Get([FromQuery]RateRequest rateRequest)
        {
            try
            {
                if (rateRequest == null)
                {
                    return BadRequest("Missing input parameters. Entry time and Exit time");
                }

                if (rateRequest.EntryDateTime == DateTime.MinValue || rateRequest.ExitDateTime == DateTime.MinValue)
                {
                    _logger.LogInformation($"Not valid times. Entry Time = {rateRequest.EntryDateTime} & Exit Time = {rateRequest.ExitDateTime}");
                    return BadRequest("Invalid dates");
                }

                if (rateRequest.EntryDateTime >= rateRequest.ExitDateTime)
                {
                    _logger.LogInformation($" Entry Time  {rateRequest.EntryDateTime} cannot be greater than Exit Time  {rateRequest.ExitDateTime}");
                    return BadRequest("Car Parking Entry Time cannot be greater than Exit Time");
                }

                var result = _setRateType.RateCalculation(rateRequest.EntryDateTime, rateRequest.ExitDateTime);

                return Ok(result); ;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while calculating the rate", rateRequest);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving the calculations");
            }
        }


    }
}
