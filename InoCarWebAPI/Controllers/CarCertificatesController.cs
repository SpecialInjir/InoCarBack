using InoCar.Api.Model;
using InoCar.Data.Entities;
using InoCar.Services;
using InoCar.Services.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InoCarWebAPI.Controllers
{
    /// <summary>
    /// CarCertificates controller
    /// </summary>

    [Route("api/v1/[controller]")]
    [ApiController]
    public class CarCertificatesController : BaseController
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();
        #region constructors

        public CarCertificatesController(ICarCertificateService carCertificateService, ICarService carService)
        {
            _carCertificateService = carCertificateService;
            _carService = carService;
        }

        #endregion constructors

        /// <summary>
        /// Create car certificate.
        /// </summary>
        /// <remarks>User must be authorized </remarks>
        /// <param name="dto">AddCarCertificateDTO</param>
        /// <response code="200">Car certificate was created</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>
        /// <response code="404">Not found</response>

        [HttpPost]
     //   [Authorize]
        public async Task<IActionResult> AddCarCertificateAsync([FromBody] AddCarCertificateDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            string UserId = GetUserId();

            var results = await _carCertificateService.AddCarCertificateAsync(dto, UserId);

            if (results.IsSuccess)
            {
                return Ok(results);
            }
            else
            {
                Log.Debug(message: results.Message);
                return BadRequest(results.Message);
            }

        }

        /// <summary>
        /// Delete car certificate.
        /// </summary>
        /// <param name="carCertificateId">CarCertificate identifier</param>
        /// <param name="removeCarReasonId">RemoveCarReason identifier </param>
        /// <response code="200">Car certificate was deleted</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>
        /// <response code="404">Not found</response>

        [HttpDelete]
        [Route("{carCertificateId:int}/{removeCarReasonId:int}")]
      //  [Authorize]
        public async Task<IActionResult> DeleteCarAsync([FromRoute] int carCertificateId, int removeCarReasonId)
        {

            var results = await _carService.DeleteCarAsync(carCertificateId, removeCarReasonId);

            if (results.IsSuccess)
            {
                return NoContent();
            }
            else
            {
                Log.Debug(message: results.Message);
                return BadRequest(results.Message);
            }

        }

        /// <summary>
        /// Get car details.
        /// </summary>
        /// <param name="carCertificateId">CarCertificate identifier</param>
        /// <response code="200">Car details was received</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>
        /// <response code="404">Not found</response>

        [HttpGet]
        [Route("{carCertificateId:int}/car-details")]
       // [Authorize]

        public async Task<ActionResult<ApiCarDetails>> GetCarDetailsAsync([FromRoute] int carCertificateId)
        {

            var results = await _carCertificateService.GetCarDetailsAsync(carCertificateId);

            if (results.IsSuccess)
            {
                return Ok(results);
            }
            else
            {
                Log.Debug(message: results.Message);
                return NotFound(results.Message);
            }
        }
        #region private fields

        private readonly ICarCertificateService _carCertificateService;
        private readonly ICarService _carService;

        #endregion private fields
    }
}
