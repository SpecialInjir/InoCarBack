using InoCar.Api.Model;
using InoCar.Services;
using InoCar.Services.DTO;
using InoCar.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RolesIdentityApp.Models;

namespace InoCarWebAPI.Controllers
{
    /// <summary>
    /// VisitReasons controller
    /// </summary>
    
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VisitReasonsController : BaseController
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        #region constructors
        public VisitReasonsController(IVisitReasonService visitReasonService)
        {
            _visitReasonService = visitReasonService;
        }

        #endregion constructors

        #region public methods
        /// <summary>
        /// Returns visit reasons list.
        /// </summary>
        /// <remarks>User must be authorized </remarks>
        /// <response code="200">Visit reasons found or list is empty</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>

        [HttpGet]
       // [Authorize]
        public async Task<ActionResult<ApiResponseMessage<ApiVisitReason>>> GetVisitReasonAsync()
        {

            var results = await _visitReasonService.GetVisitReasonAsync();

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
        /// Create new visit reason.
        /// </summary>
        /// <param name="dto">VisitReasonDTO</param>
        /// <remarks><br>User must be authorized as admin</br><br>VisitReasonTypes - BodyRepair = 0, TechnicalWorkReason=1</br></remarks>
        /// <response code="200">Visit reason added</response>
        /// <response code="403">Not authorized as admin</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>

        [HttpPost]
       // [Authorize(Roles = UserRole.Admin)]
        public async Task<ActionResult> AddVisitReasonAsync([FromBody] VisitReasonDTO dto)
        {

            var results = await _visitReasonService.AddVisitReasonAsync(dto);
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
        /// Update  visit reason.
        /// </summary>
        /// <remarks>User must be authorized as admin </remarks>
        /// <param name="visitReasonId">Visit reason identifier</param>
        /// <param name="dto">VisitReasonDTO</param>
        /// <response code="200">Visit reason updated</response>
        /// <response code="403">Not authorized as admin</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>

        [HttpPut]
        [Route("{visitReasonId:int}")]
       // [Authorize(Roles = UserRole.Admin)]
        public async Task<ActionResult> UpdateVisitReasonAsync([FromRoute] int visitReasonId, [FromBody] VisitReasonDTO dto)
        {

            var results = await _visitReasonService.UpdateVisitReasonAsync(visitReasonId, dto);
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
        /// Update  visit reason.
        /// </summary>
        /// <remarks>User must be authorized as admin </remarks>
        /// <param name="visitReasonId">Visit reason identifier.</param>
        /// <response code="200">Visit reason deleted</response>
        /// <response code="403">Not authorized as admin</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>

        [HttpDelete]
        [Route("{visitReasonId:int}")]
       // [Authorize(Roles = UserRole.Admin)]
        public async Task<ActionResult> DeleteVisitReasonAsync([FromRoute] int visitReasonId)
        {

            var results = await _visitReasonService.DeleteVisitReasonAsync(visitReasonId);
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
        /// Create maintenance work to visit reason.
        /// </summary>
        /// <remarks>User must be authorized as admin </remarks>
        /// <param name="visitReasonId">Visit reason identifier.</param>
        /// <param name="dto">MaintenanceWorkDTO</param>
        /// <response code="200">Maintenance work added</response>
        /// <response code="403">Not authorized as admin</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>
        [HttpPost]
        [Route("{visitReasonId:int}/maintenanceWork")]
       // [Authorize(Roles = UserRole.Admin)]
        public async Task<ActionResult> AddMaintenanceWorkAsync([FromRoute] int visitReasonId, [FromBody] MaintenanceWorkDTO dto)
        {

            var results = await _visitReasonService.AddMaintenanceWorkAsync(visitReasonId, dto);
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
        private readonly IVisitReasonService _visitReasonService;
        #endregion private fields
    }
}
