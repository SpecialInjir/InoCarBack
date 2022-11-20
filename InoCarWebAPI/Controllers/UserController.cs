using AutoMapper;
using InoCar.Api.Model;
using InoCar.Data.Entities;
using InoCar.Repositories;
using InoCar.Services;
using InoCar.Services.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RolesIdentityApp.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace InoCarWebAPI.Controllers
{
    /// <summary>
    /// User controller
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
  
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
       
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();
        #region constructors

        public UserController(IUserService userService, ICarService carService, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _userService = userService;
            _carService = carService;
            this.roleManager = roleManager;
            this.userManager = userManager;

        }

        #endregion constructors

        #region public methods

        /// <summary>
        /// First step in user registation - send confirm-code to user email and get uset information.
        /// </summary>
        /// <param name="dto">CreateUserDTO</param>
        /// <response code="200">User was added and confirm code was sent</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>

        [HttpPost]
        [Route("registration")]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserDTO dto)
        {
            if (!ModelState.IsValid)  return BadRequest(ModelState);

            var emailValidate = await userManager.FindByEmailAsync(dto.Email);

            if (emailValidate!=null) return BadRequest("Email is already exist!");
            
            var results = await _userService.CreateUserAsync(dto);
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
        /// Second step in user registation  -  code confirmation.
        /// </summary>
        /// <param name="dto">AddUserCodeDTO</param>
        /// <response code="200">User was confirmed</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>

        [HttpPost]
        [Route("confirm")]
        public async Task<IActionResult> ConfirmUserAsync([FromBody] AddUserCodeDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var results = await _userService.ConfirmUserEmailAsync(dto);

            if (results.IsSuccess)
            {
                return Ok(results.IsSuccess);
            }
            else
            {
                return BadRequest(results.Message);
            }

        }
        /// <summary>
        /// Third step in user registation  -  add user password.
        /// </summary>
        /// <param name="dto">AddPasswordDTO</param>
        /// <response code="200">User password was added</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>

        [HttpPost]
        public async Task<IActionResult> AddUserPasswordAsync([FromBody] AddPasswordDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);


            var emailValidate = await userManager.FindByEmailAsync(dto.Email);

            if (emailValidate == null) return BadRequest("Email is not exist!");

            var results = await _userService.AddUserPasswordAsync(dto);
        
            if (results.IsSuccess)
            {
                return Ok(results);
            }
            else
            {
                Log.Debug(message:results.Message);
                return BadRequest(results.Message);
            }

        }

        /// <summary>
        /// Login user.
        /// </summary>
        /// <param name="dto">>LoginUserDTO</param>
        /// <remarks> Login as admin if you want use admin functions</remarks>
        /// <response code="200">User login</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>
        /// <returns>Access(bearer) and refresh tokens</returns>
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginUserDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var results = await _userService.LoginAsync(dto);

            if (results.IsSuccess)
            {
                return Ok(results);
            }
            else
            {
                return Unauthorized(results.Message);
            }
           

        }

        /// <summary>
        /// Send reset rassword link.
        /// </summary>
        /// <param name="dto">ForgotPasswordDTO</param>
        /// <remarks>Use token for reset code</remarks>
        /// <response code="200">Reset password link was sent</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>
       
        [HttpPost]
        [Route("reset-password-link")]
        public async Task<IActionResult> SendResetPasswordLinkAsync([FromBody] ForgotPasswordDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var emailValidate = await userManager.FindByEmailAsync(dto.Email);

            if (emailValidate == null) return BadRequest("Email not exist!");

            var results = await _userService.SendUrlAsync(dto.Email);

            if (results.IsSuccess)
            {
                return Ok(results.Message);
            }
            else
            {
                Log.Debug(message: results.Message);
                return BadRequest(results.Message);
            }
          

        }

        /// <summary>
        /// Add new rassword.
        /// </summary>
        /// <param name="dto">AddNewPasswordDTO</param>
        /// <remarks>Use token in reset link as reset code</remarks>
        /// <response code="200">Password was added</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>


        [HttpPut] 
        [Route("new-password")]
         public async Task<IActionResult> AddNewPasswordAsync([FromBody] AddNewPasswordDTO dto)
         {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var results = await _userService.ResetPasswordAsync(dto);

            if (results.IsSuccess)
            {
                return Ok(results.Message);
            }
            else
            {
                Log.Debug(message: results.Message);
                return BadRequest(results.Message);
            }


         }

        /// <summary>
        /// Refresh token.
        /// </summary>
        /// <param name="dto">RefreshTokenDTO</param>
        /// <response code="200">Token was refreshed</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>

        [HttpPost]
        [Route("refresh-token")]
        public async Task<IActionResult> RefreshAsync([FromBody] RefreshTokenDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var results = await _userService.RefreshAsync(dto);

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
        /// Update user profile.
        /// </summary>
        /// <param name="dto">UpdateProfileDTO</param>
        /// <remarks>User must be authorized </remarks>
        /// <response code="401">Unauthorized</response>
        /// <response code="200">User profile was updated</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information</response>


        [HttpPut]
        [Route("profile")]
        //[Authorize]
        public async Task<IActionResult> UpdateProfileAsync([FromBody] UpdateProfileDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            string userId = GetUserId();
         
            var results = await _userService.UpdateProfileAsync(dto, userId);

            if (results.IsSuccess)
            {
                return Ok(results.Message);
            }
            else
            {
                Log.Debug(message: results.Message);
                return BadRequest(results.Message);
            }

        }

        /// <summary>
        /// Get user city.
        /// </summary>
        /// <remarks>User must be authorized </remarks>
        /// <response code="401">Unauthorized</response>
        /// <response code="200">User city was received</response>
        /// <response code="404">Not  found </response>

        [HttpGet]
        [Route("city")]
       // [Authorize]
        public async Task<ActionResult<string>> GetUserCityAsync()
        {
            string userId = GetUserId();
            var results = await _userService.GetUserCityAsync(userId);

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
        /// Get user profile.
        /// </summary>
        /// <remarks>User must be authorized </remarks>
        /// <response code="401">Unauthorized</response>
        /// <response code="200">User profile was received</response>
        /// <response code="404">Not  found </response>

        [HttpGet]
        [Route("profile")]
        //[Authorize]
        public async Task<ActionResult<ApiUserProfile>> GetUserProfileAsync()
        {
            string userId = GetUserId();
            var results = await _userService.GetUserProfile(userId);
           
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
        /// Get user cars.
        /// </summary>
        /// <remarks>User must be authorized </remarks>
        /// <response code="401">Unauthorized</response>
        /// <response code="200">User cars was received</response>
        /// <response code="404">Not  found </response>


        [HttpGet]
        [Route("cars")]
        //[Authorize]
        public async Task<ActionResult<ApiResponse<ApiCarEntry>>> GetUserCarsAsync()
        {
            string userId = GetUserId();
            var cars = await _carService.GetUserCarsListAsync(userId);

            if (cars == null)
            {
                return NotFound();
            }

            return Ok(cars);
        }

        /// <summary>
        /// Add new admin. 
        /// </summary>
        /// <param name="email">User email</param>
        /// <remarks>User must be authorized as admin </remarks>
        /// <response code="200">User cars was received</response>
        /// <response code="403">Not authorized as admin</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Something went wrong. Please contact InoCar for more information </response>

        [HttpPost]
        [Route("admin")]
       // [Authorize(Roles = UserRole.Admin)]
        public async Task<IActionResult> CreateAdmin(string email)
        {

            var user = await userManager.FindByEmailAsync(email);
            if (user!=null)
            {
                IdentityResult result = await userManager.AddToRoleAsync(user, UserRole.Admin);
                if (result.Succeeded)
                {
                    return Ok(result);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return BadRequest();
        }
        #endregion public methods

        #region private fields

        private readonly IUserService _userService;
        private readonly ICarService _carService;

        #endregion private fields

    }
}
