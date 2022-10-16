using InoCar.Services.DTO;
using InoCar.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RolesIdentityApp.Models;

namespace InoCarWebAPI.Controllers
{

    /// <summary>
    /// MaintenanceWorks controller
    /// </summary>
    
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MaintenanceWorksController : BaseController
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        #region constructors
        public MaintenanceWorksController(IMaintenanceWorkService maintenanceWorkService)
        {
            _maintenanceWorkService = maintenanceWorkService;
        }

        #endregion constructors

        #region public methods

        /// <summary>
        /// Update maintenance work.
        /// </summary>
        /// <remarks>User must be authorized as admin </remarks>
        /// <param name="maintenanceWorkId">Maintenance work identifier.</param>
        /// <param name="dto">MaintenancWorkDTO</param>
        /// <response code="200">Maintenance work was updated</response>
        /// <response code="403">Not authorized as admin</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>


        [HttpPut]
        [Route("{maintenanceWorkId:int}")]
       // [Authorize(Roles = UserRole.Admin)]
        public async Task<ActionResult> UpdateMaintenanceWorkAsync([FromRoute] int maintenanceWorkId, [FromBody] MaintenanceWorkDTO dto)
        {

            var results = await _maintenanceWorkService.UpdateMaintenanceWorkAsync(maintenanceWorkId, dto);
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
        /// Delete maintenance work.
        /// </summary>
        /// <remarks>User must be authorized as admin </remarks>
        /// <param name="maintenanceWorkId">Maintenance work identifier.</param>
        /// <response code="200">Maintenance work was deleted</response>
        /// <response code="403">Not authorized as admin</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>

        [HttpDelete]
        [Route("{maintenanceWorkId:int}")]
        //[Authorize(Roles = UserRole.Admin)]
        public async Task<ActionResult> DeleteMaintenanceWorkAsync([FromRoute] int maintenanceWorkId)
        {

            var results = await _maintenanceWorkService.DeleteMaintenanceWorkAsync(maintenanceWorkId);
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
        private readonly IMaintenanceWorkService _maintenanceWorkService;
        #endregion private fields
    }
}
