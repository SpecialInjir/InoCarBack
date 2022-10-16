using InoCar.Services.DTO;
using InoCar.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RolesIdentityApp.Models;

namespace InoCarWebAPI.Controllers
{
    /// <summary>
    /// PersonalOffers controller
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PersonalOffersController : BaseController
    {

        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        #region constructors
        public PersonalOffersController(IPersonalOfferService personalOfferService)
        {
            _personalOfferService = personalOfferService;
        }

        #endregion constructors

        #region public methods

        /// <summary>
        /// Create personal offer.
        /// </summary>
        /// <remarks>User must be authorized as admin </remarks>
        /// <param name="dto">PersonalOfferDTO</param>
        /// <response code="200">Personal offer was created</response>
        /// <response code="403">Not authorized as admin</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>

        [HttpPost]
       // [Authorize(Roles = UserRole.Admin)]
        public async Task<ActionResult<int>> AddPersonalOfferAsync([FromBody] PersonalOfferDTO dto)
        {

            var results = await _personalOfferService.AddPersonalOfferAsync(dto);
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
        /// Get all personal offer.
        /// </summary>
        /// <remarks>User must be authorized as admin </remarks>
        /// <response code="200">Personal offers was received</response>
        /// <response code="403">Not authorized as admin</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>

        [HttpGet]
        [Authorize]
      //  [Authorize(Roles = UserRole.Admin)]
        public ActionResult GetAllPersonalOffer()
        {

            var results = _personalOfferService.GetAllPersonalOffers();

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
        /// Update personal offer.
        /// </summary>
        /// <remarks>User must be authorized as admin </remarks>
        /// <param name="personalOfferId">Personal offer  identifier.</param>
        /// <param name="dto">PersonalOfferDTO</param>
        /// <response code="200">Personal offer was updated</response>
        /// <response code="403">Not authorized as admin</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>

        [HttpPut]
        [Route("{personalOfferId:int}")]
        //[Authorize(Roles = UserRole.Admin)]
        public async Task<ActionResult> UpdatePersonalOfferAsync([FromRoute] int personalOfferId, [FromBody] PersonalOfferDTO dto)
        {

            var results = await _personalOfferService.UpdatePersonalOfferAsync(personalOfferId, dto);
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
        /// Delete personal offer.
        /// </summary>
        /// <remarks>User must be authorized as admin </remarks>
        /// <param name="personalOfferId">Personal offer  identifier.</param>
        /// <response code="200">Personal offer was deleted</response>
        /// <response code="403">Not authorized as admin</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>


        [HttpDelete]
        [Route("{personalOfferId:int}")]
        //[Authorize(Roles = UserRole.Admin)]
        public async Task<ActionResult> DeletePersonalOfferAsync([FromRoute] int personalOfferId)
        {

            var results = await _personalOfferService.DeletePersonalOfferAsync(personalOfferId);
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
        private readonly IPersonalOfferService _personalOfferService;
        #endregion private fields
    }
}
