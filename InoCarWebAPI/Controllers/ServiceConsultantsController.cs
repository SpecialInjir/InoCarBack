using InoCar.Api.Model;
using InoCar.Services.DTO;
using InoCar.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RolesIdentityApp.Models;

namespace InoCarWebAPI.Controllers
{  /// <summary>
   /// ServiceConsultants controller
   /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ServiceConsultantsController : BaseController
    {

        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();
        #region constructors
        public ServiceConsultantsController(IServiceConsultantService serviceConsultantService)
        {

            _serviceConsultantService = serviceConsultantService;

        }
        #endregion constructors

        #region public methods

        /// <summary>
        /// Add time-slot for service-consultant.
        /// </summary>
        /// <remarks>User must be authorized as admin </remarks>
        /// <param name="serviceConsultantId">Service consultant identifier.</param>
        /// <param name="dto">TimeSlotDTO</param>
        /// <response code="200">Time slot for service consultant was added</response>
        /// <response code="403">Not authorized as admin</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>


        [HttpPost]
        [Route("{serviceConsultantId:int}/time-slot")]
      //  [Authorize(Roles = UserRole.Admin)]
        public async Task<ActionResult> AddTimeSlotAsync([FromRoute] int serviceConsultantId, [FromBody] TimeSlotDTO dto)
        {

            var results = await _serviceConsultantService.AddTimeSlotAsync(serviceConsultantId, dto);
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
        /// Get all service consultants.
        /// </summary>
        /// <remarks>User must be authorized as admin </remarks>
        /// <response code="200">Service consultant was received </response>
        /// <response code="403">Not authorized as admin</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>

        [HttpGet]
        //[Authorize(Roles = UserRole.Admin)]
        public async Task<ActionResult> GetAllServiceConsultantAsync()
        {

            var results = await _serviceConsultantService.GetAllServiceConsultantAsync();
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
        /// Update service consultant.
        /// </summary>
        /// <remarks>User must be authorized as admin </remarks>
        /// <param name="serviceConsultantId">Service consultant identifier.</param>
        /// <param name="dto">ServiceConsultantDTO</param>
        /// <response code="200">Service was updated</response>
        /// <response code="403">Not authorized as admin</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>

        [HttpPut]
        [Route("{serviceConsultantId:int}")]
        [Authorize(Roles = UserRole.Admin)]
        public async Task<ActionResult> UpdateServiceConsultantAsync([FromRoute] int serviceConsultantId, [FromBody] ServiceConsultantDTO dto)
        {

            var results = await _serviceConsultantService.UpdateServiceConsultantAsync(serviceConsultantId, dto);
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
        /// Delete service consultant.
        /// </summary>
        /// <remarks>User must be authorized as admin </remarks>
        /// <param name="serviceConsultantId">Service consultant identifier.</param>
        /// <response code="403">Not authorized as admin</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="200">Service was deleted</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>

        [HttpDelete]
        [Route("{serviceConsultantId:int}")]
        [Authorize(Roles = UserRole.Admin)]
        public async Task<ActionResult> DeleteServiceConsultantAsync([FromRoute] int serviceConsultantId)
        {

            var results = await _serviceConsultantService.DeleteServiceConsultantAsync(serviceConsultantId);
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
        [Route("{serviceConsultantId:int}/time-slots")]
       // [Authorize(Roles = UserRole.Admin)]
        public async Task<ActionResult<ApiResponseMessage<ApiResponse<ApiTimeSlot>>>> GetTimeslotsConsultantAsync([FromRoute] int serviceConsultantId)
        {

            var results = await _serviceConsultantService.GetConsultantsTimeSlotsAsync(serviceConsultantId);
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

        #endregion public methods

        #region private fields

        private readonly IServiceConsultantService _serviceConsultantService;
    
        #endregion private fields
    }
}
