using InoCar.Api.Model;
using InoCar.Services.DTO;
using InoCar.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RolesIdentityApp.Models;

namespace InoCarWebAPI.Controllers
{
    /// <summary>
    /// Dealerships controller
    /// </summary>

    [Route("api/v1/[controller]")]
    [ApiController]
    public class DealershipsController : BaseController
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();
        #region constructors
        public DealershipsController(IDealershipService dealershipService, IServiceConsultantService serviceConsultantService, IServiceRequest serviceRequest)
        {

            _dealershipService = dealershipService;
            _serviceConsultantService = serviceConsultantService;
            _serviceRequest = serviceRequest;
        }
        #endregion constructors

        #region public methods

        /// <summary>
        /// Get dealerships by brand and sity for user service-request.
        /// </summary>
        /// <param name="city">City</param>
        /// <param name="carId">User carId</param>
        /// <response code="200">Dealerships was received</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>
        /// <response code="404">Not found</response>

        [HttpGet]
        [Route("user/{city}/{carId:int}")]
       // [Authorize]
        public async Task<ActionResult<ApiResponse<ApiDealership>>> GetDealershipsAsync([FromRoute] string city, int carId)
        {

            var results = await _dealershipService.GetDealershipsAsync(city, carId);

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
        /// Get all dealerships by user city.
        /// </summary>
        /// <response code="200">Dealerships was received</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>
        /// <response code="404">Not found</response>

        [HttpGet]
      //  [Authorize]
        public async Task<ActionResult<ApiResponse<ApiDealershipInformation>>> GetAllDealershipsAsync()
        {
            string userId = GetUserId();
            var results = await _dealershipService.GetDealershipsAllAsync(userId);
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
        /// Get service-consultants in dealership.
        /// </summary>
        /// <param name="dealershipId">Dealership identifier</param>
        /// <response code="200">Service-consultants was received</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>
        /// <response code="404">Not found</response>
        [HttpGet]
        [Route("{dealershipId:int}/consultants")]
      //  [Authorize]
        public async Task<ActionResult<ApiResponse<ApiConsultant>>> GetServiceConsultantsAsync(int dealershipId)
        {

            var results = await _serviceConsultantService.GetConsultantsByDealershipIdAsync(dealershipId);
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
        /// Get dealership.
        /// </summary>
        /// <param name="dealershipId">Dealership identifier</param>
        /// <response code="200">Dealership was received</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>
        /// <response code="404">Not found</response>
        [HttpGet]
        [Route("{dealershipId:int}")]
      //  [Authorize]
        public async Task<ActionResult<ApiDealershipInformation>> GetDealershipAsync([FromRoute] int dealershipId)
        {

            var results = await _dealershipService.GetDealershipByIdAsync(dealershipId);
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
        /// Create dealership feedback.
        /// </summary>
        /// <param name="dealershipId">Dealership identifier</param>
        /// <param name="dto">DealershipFeedbackDTO</param>
        /// <response code="200">Dealership feedback was created</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>

        [HttpPost]
        [Route("{dealershipId:int}/feedback")]
      //  [Authorize]
        public async Task<ActionResult> AddDealershipFeedbackAsync([FromRoute] int dealershipId, [FromBody] DealershipFeedbackDTO dto)
        {
            string userId = GetUserId();
            var serviceRequestExist = await _serviceRequest.UserServiceRequestExistsAsync(userId, dealershipId);
            if (!serviceRequestExist) return BadRequest("Not found any Service Requests");
            var results = await _dealershipService.AddFeedbackAsync(dealershipId, dto);
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
        /// Get dealership feedback.
        /// </summary>
        /// <param name="dealershipFeedbackId">Dealership feedback identifier</param>
        /// <response code="200">Dealership feedback was received</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>
        /// <response code="404">Not found</response>

        [HttpGet]
        [Route("feedbacks/{dealershipFeedbackId:int}")]
      //  [Authorize]
        public async Task<ActionResult<ApiDealershipFeedback>> GetDealershipFeedbackAsync([FromRoute] int dealershipFeedbackId)
        {

            var results = await _dealershipService.GetFeedbackAsync(dealershipFeedbackId);
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
        /// Create dealership.
        /// </summary>
        /// <remarks>User must be authorized as admin </remarks>
        /// <param name="dto">DealershipDTO</param>
        /// <response code="200">Dealership was created</response>
        /// <response code="403">Not authorized as admin</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>

        [HttpPost]
     //   [Authorize(Roles = UserRole.Admin)]
        public async Task<ActionResult<int>> AddDealershipAsync([FromBody] DealershipDTO dto)
        {

            var results = await _dealershipService.AddDealershipAsync(dto);
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
        /// Create service consultant. 
        /// </summary>
        /// <remarks>User must be authorized as admin </remarks>
        /// <param name="dealershipId">Dealership identifier</param>
        /// <param name="dto">ServiceConsultantDTO</param>
        /// <response code="200">Service consultant was created</response>
        /// <response code="403">Not authorized as admin</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>

        [HttpPost]
        [Route("{dealershipId:int}/service-consultant")]
    //   [Authorize(Roles = UserRole.Admin)]
        public async Task<ActionResult<int>> AddServiceConsultantAsync([FromRoute] int dealershipId, [FromBody] ServiceConsultantDTO dto)
        {

            var results = await _serviceConsultantService.AddServiceConsultantAsync(dealershipId, dto);
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
        /// Update dealership.
        /// </summary>
        /// <remarks>User must be authorized as admin </remarks>
        /// <param name="dealershipId">Dealership identifier</param>
        /// <param name="dto">DealershipDTO</param>
        /// <response code="200">Dealership was updated</response>
        /// <response code="403">Not authorized as admin</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>

        [HttpPut]
        [Route("{dealershipId:int}")]
      //  [Authorize(Roles = UserRole.Admin)]
        public async Task<ActionResult> UpdateDealershipAsync([FromRoute] int dealershipId, [FromBody] DealershipDTO dto)
        {

            var results = await _dealershipService.UpdateDealershipAsync(dealershipId, dto);
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
        /// Delete dealership.
        /// </summary>
        /// <remarks>User must be authorized as admin </remarks>
        /// <param name="dealershipId">Dealership identifier</param>
        /// <response code="200">Dealership was deleted</response>
        /// <response code="403">Not authorized as admin</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>

        [HttpDelete]
        [Route("{dealershipId:int}")]
       // [Authorize(Roles = UserRole.Admin)]
        public async Task<ActionResult> DeleteDealershipAsync([FromRoute] int dealershipId)
        {

            var results = await _dealershipService.DeleteDealershipAsync(dealershipId);
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


        private readonly IDealershipService _dealershipService;
        private readonly IServiceConsultantService _serviceConsultantService;
        private readonly IServiceRequest _serviceRequest;

        #endregion private fields
    }
}
