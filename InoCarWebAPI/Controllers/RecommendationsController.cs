using InoCar.Services.DTO;
using InoCar.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RolesIdentityApp.Models;

namespace InoCarWebAPI.Controllers
{
    /// <summary>
    /// RecommendationsController controller
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RecommendationsController : BaseController
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        #region constructors
        public RecommendationsController(IRecommendationService recommendationService)
        {
            _recommendationService = recommendationService;
        }

        #endregion constructors

        #region public methods
        /// <summary>
        /// Create recommendation.
        /// </summary>
        /// <param name="dto">RecommendationDTO</param>
        /// <remarks>User must be authorized as admin</remarks>
        /// <response code="200"> Recommendation was added</response>
        /// <response code="403">Not authorized as admin</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>

        [HttpPost]
       // [Authorize(Roles = UserRole.Admin)]
        public async Task<ActionResult> AddRecommendationAsync([FromBody] RecommendationDTO dto)
        {

            var results = await _recommendationService.AddRecommendationAsync(dto);
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
        /// Get all recommendations.
        /// </summary>
        /// <remarks>User must be authorized </remarks>
        /// <response code="200">Recommendation was received </response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>

        [HttpGet]
      //  [Authorize]
        public ActionResult GetAllRecommendations()
        {

            var results = _recommendationService.GetAllRecommendations();

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
        /// Update recommendation.
        /// </summary>
        /// <remarks>User must be authorized as admin </remarks>
        /// <param name="recommendationId">Recommendation  identifier.</param>
        /// <param name="dto">RecommendationDTO</param>
        /// <response code="200">Recommendation was updated</response>
        /// <response code="403">Not authorized as admin</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>

        [HttpPut]
        [Route("{recommendationId:int}")]
      //  [Authorize(Roles = UserRole.Admin)]
        public async Task<ActionResult> UpdateRemoveCarReasonAsync([FromRoute] int recommendationId, [FromBody] RecommendationDTO dto)
        {

            var results = await _recommendationService.UpdateRecommendationAsync(recommendationId, dto);
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
        /// Delete recommendation.
        /// </summary>
        /// <remarks>User must be authorized as admin </remarks>
        /// <param name="recommendationId">Recommendation  identifier.</param>
        /// <response code="200">Recommendation was deleted</response>
        /// <response code="403">Not authorized as admin</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>

        [HttpDelete]
        [Route("{recommendationId:int}")]
       // [Authorize(Roles = UserRole.Admin)]
        public async Task<ActionResult> DeleteRemoveCarReasonAsync([FromRoute] int recommendationId)
        {

            var results = await _recommendationService.DeleteRecommendationAsync(recommendationId);
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
        private readonly IRecommendationService _recommendationService;
        #endregion private fields

    }
}
