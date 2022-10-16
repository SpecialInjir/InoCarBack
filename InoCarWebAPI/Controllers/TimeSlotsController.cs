using InoCar.Services.DTO;
using InoCar.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RolesIdentityApp.Models;

namespace InoCarWebAPI.Controllers
{
    /// <summary>
    /// Time Slots controller
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TimeSlotsController : BaseController
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        #region constructors
        public TimeSlotsController(ITimeSlotService timeSlotService)
        {
            _timeSlotService = timeSlotService;
        }

        #endregion constructors

        #region public methods

        /// <summary>
        /// Update time-slot.
        /// </summary>
        /// <param name="timeSlotId">Time slot identifier</param>
        /// <param name="dto">TimeSlotDTO</param>
        /// <remarks>User must be authorized as admin </remarks>
        /// <response code="403">Not authorized as admin</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="200">Time slot was updated</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>

        [HttpPut]
        [Route("{timeSlotId:int}")]
        //[Authorize(Roles = UserRole.Admin)]
        public async Task<ActionResult> UpdateTimeSlotAsync([FromRoute] int timeSlotId, [FromBody] TimeSlotDTO dto)
        {

            var results = await _timeSlotService.UpdateTimeSlotAsync(timeSlotId, dto);
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
        /// Delete time-slot.
        /// </summary>
        /// <remarks>User must be authorized as admin </remarks>
        /// <param name="timeSlotId">Time slot identifier.</param>
        /// <response code="200">Time slot deleted</response>
        /// <response code="403">Not authorized as admin</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>

        [HttpDelete]
        [Route("{timeSlotId:int}")]
       // [Authorize(Roles = UserRole.Admin)]
        public async Task<ActionResult> DeleteTimeSlotAsync([FromRoute] int timeSlotId)
        {

            var results = await _timeSlotService.DeleteTimeSlotAsync(timeSlotId);
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
        private readonly ITimeSlotService _timeSlotService;
        #endregion private fields
    }
}
