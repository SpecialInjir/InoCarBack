using InoCar.Api.Model;
using InoCar.Data.Entities;
using InoCar.Services;
using InoCar.Services.DTO;
using InoCar.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InoCarWebAPI.Controllers
{
    /// <summary>
    ///  Cars controller
    /// </summary>

    [Route("api/v1/[controller]")]
    [ApiController]
    public class CarsController : BaseController
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        #region constructors

        public CarsController(ICarService carService, IServiceRequest serviceRequest)
        {
            _carService = carService;
            _serviceRequest = serviceRequest;
        }

        #endregion constructors

        /// <summary>
        /// Get user cars.
        /// </summary>
        /// <response code="200">Cars was received</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>
        /// <response code="404">Not found</response>

        [HttpGet]
       // [Authorize]
        public async Task<ActionResult<ApiResponse<ApiCar>>> GetCarsByUserIdAsync()
        {
            string userId = GetUserId();
            var results = await _carService.GetUserCarsAsync(userId);

            if (results.IsSuccess)
            {
                return Ok(results.Result);
                
            }
            else
            {
                Log.Debug(message: results.Message);
                return NotFound(results.Message);
            }
        }

        /// <summary>
        /// Add user car.
        /// </summary>
        /// <param name="dto">AddCarDTO</param>
        /// <response code="200">Cars was added</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>
        /// <response code="404">Not found</response>

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddCarAsync([FromBody] AddCarDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);


            var results = await _carService.AddCarAsync(dto);
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
        /// Send car characteristics to email.
        /// </summary>
        /// <param name="dto">CarCharacteristicsRequestDTO</param>
        /// <response code="200">Car characteristics was sent</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>
        /// <response code="404">Not found</response>

        [HttpPost]
        [Route("send-email")]
   
        public async Task<ActionResult> SendCarCharacteristicsToEmail([FromBody] CarCharacteristicsRequestDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            string userId = GetUserId();

            var results = await _carService.SendCarCharacteristics(dto, userId);
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
        [HttpGet]
        [Route("car-characteristics")]

        public async Task<ActionResult<ApiResponseMessage<ApiCar>>> GetCarCharacteristics( int Id)
        {
           
        
            var results = await _carService.GetCarByIdAsync(Id);
            if (results.IsSuccess)
            {
                return Ok(results.Result);
            }
            else
            {
                Log.Debug(message: results.Message);
                return BadRequest(results.Message);
            }

        }

        
        /// <summary>
        /// Get completed car service-requests. 
        /// </summary>
        /// <param name="carId">Car identifier</param>
        /// <response code="200">Service-requests history  was received</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>
        /// <response code="404">Not found</response>

        [HttpGet]
        [Route("{carId:int}/service-requests")]
     //   [Authorize]
        public async Task<ActionResult<ApiResponse<ApiServiceRequestHistory>>> GetCarServiceRequestsAsync([FromRoute] int carId)
        {

            var results = await _serviceRequest.GetCarServiceRequestsAsync(carId);
            
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

        /// <summary>
        /// Update car information.
        /// </summary>
        /// <param name="carId">Car identifier</param>
        /// <param name="dto">UpdateCarDTO</param>
        /// <response code="200">Car was updated</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>
        /// <response code="404">Not found</response>

        [HttpPut]
        [Route("{carId:int}")]
        //[Authorize]
        public async Task<ActionResult> UpdateCarAsync([FromRoute] int carId, UpdateCarDTO dto)
        {

            var results = await _carService.UpdateCarAsync(carId, dto);

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

        #region private fields

        private readonly ICarService _carService;
        private readonly IServiceRequest _serviceRequest;

        #endregion private fields

    }
}
