using InoCar.Services;
using InoCar.Services.DTO;
using InoCar.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InoCar.Api.Model;

namespace InoCarWebAPI.Controllers
{
    /// <summary>
    /// ServiceRequests controller
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ServiceRequestsController : BaseController
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        #region constructors
        public ServiceRequestsController(IServiceRequest serviceRequest)
        {
          
            _serviceRequest = serviceRequest;
        }

        #endregion constructors

        #region public methods
        /// <summary>
        /// Create service-request.
        /// </summary>
        /// <param name="dto">ServiceRequestDTO</param>
        /// <remarks>User must be authorized</remarks>
        /// <response code="401">Unauthorized</response>
        /// <response code="200">Service request was addded</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> AddServiceRequestAsync([FromBody] ServiceRequestDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            string userId = GetUserId();

            var results = await _serviceRequest.AddServiceRequestAsync(dto, userId);


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
        /// Add offers to service-request.
        /// </summary>
        /// <param name="dto">AddOfferDTO</param>
        /// <remarks>User must be authorized</remarks>
        /// <response code="200">Offers was addded</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>


        [HttpPost]
        [Route("personal-offers")]
      //  [Authorize]

        public async Task<IActionResult> AddOffersAsync([FromBody] AddOffersDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var results = await _serviceRequest.AddOffersAsync(dto);


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
        /// Add recommendations to service-request.
        /// </summary>
        /// <param name="dto">AddRecommendationDTO</param>
        /// <remarks>User must be authorized</remarks>
        /// <response code="401">Unauthorized</response>
        /// <response code="200">Recommendations was addded</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>

         [HttpPost]
         [Route("recommendations")]
       //  [Authorize]

        public async Task<IActionResult> AddRecommendationsAsync([FromBody] AddRecommendationsDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var results = await _serviceRequest.AddRecommendationsAsync(dto);


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
        /// Get personal offers for service-request.
        /// </summary>
        /// <remarks>User must be authorized </remarks>
        /// <param name="serviceRequestId">Service request identifier.</param>
        /// <response code="401">Unauthorized</response>
        /// <response code="200">personal offers was received</response>
        /// <response code="404">Not found</response>

        [HttpGet]
        [Route("{serviceRequestId:int}/personal-offers")]
        //[Authorize]

        public async Task<ActionResult<ApiResponse<ApiPersonalOffer>>> GetPersonalOffersAsync(int serviceRequestId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            var results = await _serviceRequest.GetPersonalOffersAsync(serviceRequestId);


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
        /// Get recommendations for service-request.
        /// </summary>
        /// <remarks>User must be authorized </remarks>
        /// <param name="serviceRequestId">Service request identifier.</param>
        /// <response code="401">Unauthorized</response>
        /// <response code="200">Recommendations was received</response>
        /// <response code="404">Not found</response>

        [HttpGet]
        [Route("{serviceRequestId:int}/recommendations")]
       // [Authorize]

        public async Task<ActionResult<ApiResponse<ApiRecommendation>>> GetRecommendationsAsync(int serviceRequestId)
        {
         
           
            var results = await _serviceRequest.GetRecommendationsAsync(serviceRequestId);


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
        /// Get Service request.
        /// </summary>
        /// <remarks>User must be authorized </remarks>
        /// <param name="serviceRequestId">Service request identifier.</param>
        /// <response code="401">Unauthorized</response>
        /// <response code="200">Service request was received</response>
        /// <response code="404">Not found</response>

        [HttpGet]
        [Route("{serviceRequestId:int}")]
     //   [Authorize]

        public async Task<ActionResult<ApiServiceRequest>> GetServiceRequestAsync(int serviceRequestId)
        {


            var results = await _serviceRequest.GetServiceRequestAsync(serviceRequestId);

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

        #endregion public methods

        #region private fields



        private readonly IServiceRequest _serviceRequest;

        #endregion private fields
    }

}
