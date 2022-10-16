using InoCar.Api.Model;
using InoCar.Services.DTO;
using InoCar.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RolesIdentityApp.Models;

namespace InoCarWebAPI.Controllers
{
    /// <summary>
    /// RemoveCarReasons controller
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RemoveCarReasonsController : BaseController
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();
        #region constructors
        public RemoveCarReasonsController(IRemoveCarReasonService removeCarReasonService)
        {
            _removeCarReasonService = removeCarReasonService;

        }

        #endregion constructors

        #region public methods
        /// <summary>
        /// Get all remove-car reasons.
        /// </summary>
        /// <remarks>User must be authorized </remarks>
        /// <response code="200">Remove-car reasons was received </response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetRemoveCarReasonsAsync()
        {

            var results = await _removeCarReasonService.GetRemoveCarReasonsAsync();

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
        /// Create remove-car reason.
        /// </summary>
        /// <remarks>User must be authorized </remarks>
        /// <response code="200"> Remove-car reason was added</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> AddRemoveCarReasonAsync([FromBody] AddRemoveCarReasonDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var results = await _removeCarReasonService.AddRemoveCarReasonAsync(dto);

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
        /// Update remove-car reason.
        /// </summary>
        /// <remarks>User must be authorized as admin</remarks>
        /// <param name="removeCarReasonId">RemoveCarReason  identifier.</param>
        /// <param name="dto">AddRemoveCarReasonDTO</param>
        /// <response code="200">Remove-car reason was updated</response>
        /// <response code="403">Not authorized as admin</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>

        [HttpPut]
        [Route("{removeCarReasonId:int}")]
        [Authorize(Roles = UserRole.Admin)]
        public async Task<ActionResult> UpdateRemoveCarReasonAsync([FromRoute] int removeCarReasonId, [FromBody] AddRemoveCarReasonDTO dto)
        {

            var results = await _removeCarReasonService.UpdateRemoveCarReasonAsync(removeCarReasonId, dto);
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
        /// Delete remove-car reason.
        /// </summary>
        /// <remarks>User must be authorized as admin </remarks>
        /// <param name="removeCarReasonId">RemoveCarReason  identifier.</param>
        /// <response code="403">Not authorized as admin</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="200"> Remove-car reason was deleted</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>

        [HttpDelete]
        [Route("{removeCarReasonId:int}")]
        [Authorize(Roles = UserRole.Admin)]
        public async Task<ActionResult> DeleteRemoveCarReasonAsync([FromRoute] int removeCarReasonId)
        {

            var results = await _removeCarReasonService.DeleteRemoveCarReasonAsync(removeCarReasonId);
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


        private readonly IRemoveCarReasonService _removeCarReasonService;


        #endregion private fields
    }
}
