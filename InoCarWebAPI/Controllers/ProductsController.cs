using InoCar.Data.Entities;
using InoCar.Services.DTO;
using InoCar.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RolesIdentityApp.Models;

namespace InoCarWebAPI.Controllers
{
    /// <summary>
    /// ProductsController controller
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        #region constructors
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        #endregion constructors

        #region public methods

        /// <summary>
        /// Create product.
        /// </summary>
        /// <remarks>User must be authorized as admin </remarks>
        /// <param name="dto">ProductDTO</param>
        /// <response code="200">Product was created</response>
        /// <response code="403">Not authorized as admin</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>

        [HttpPost]
       // [Authorize(Roles = UserRole.Admin)]
        public async Task<ActionResult<int>> AddProductAsync([FromBody] ProductDTO dto)
        {

            var results = await _productService.AddProductAsync(dto);
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
        /// Get all products.
        /// </summary>
        /// <remarks>User must be authorized as admin </remarks>
        /// <response code="200">Products received</response>
        /// <response code="403">Not authorized as admin</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>

        [HttpGet]
       // [Authorize(Roles = UserRole.Admin)]
        public ActionResult GetAllProducts()
        {

            var results = _productService.GetProducts();
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
        /// Update product.
        /// </summary>
        /// <remarks>User must be authorized as admin </remarks>
        /// <param name="productId">Product  identifier.</param>
        /// <param name="dto">ProductDTO</param>
        /// <response code="200">Product was updated</response>
        /// <response code="403">Not authorized as admin</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>

        [HttpPut]
        [Route("{productId:int}")]
      //  [Authorize(Roles = UserRole.Admin)]
        public async Task<ActionResult<int>> UpdateProductAsync([FromRoute] int productId, [FromBody] ProductDTO dto)
        {

            var results = await _productService.UpdateProductAsync(productId, dto);
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
        /// Delete product.
        /// </summary>
        /// <remarks>User must be authorized as admin </remarks>
        /// <param name="productId">Product identifier.</param>
        /// <response code="200">Product was deleted</response>
        /// <response code="403">Not authorized as admin</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>

        [HttpDelete]
        [Route("{productId:int}")]
      //  [Authorize(Roles = UserRole.Admin)]
        public async Task<ActionResult<int>> DeleteProductAsync([FromRoute] int productId)
        {

            var results = await _productService.DeleteProductAsync(productId);
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
        private readonly IProductService _productService;
        #endregion private fields
    }
}
