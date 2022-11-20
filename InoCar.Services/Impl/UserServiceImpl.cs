using AutoMapper;
using InoCar.Data.Entities;
using InoCar.Data.Enums;
using InoCar.Repositories;
using InoCar.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using InoCar.Common;
using InoCar.Api.Model;
using Microsoft.AspNetCore.Identity;
using RolesIdentityApp.Models;

namespace InoCar.Services.Impl
{
    public class UserServiceImpl : IUserService
    {

        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<User> signInManager;
        #region constructors
        public UserServiceImpl(IUserRepository userRepository, IUserCodeService userCodeService, IMapper mapper,
            IConfiguration configuration, IRefreshTokenRepository refreshTokenRepository,
            RoleManager<IdentityRole> roleManager, UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _userRepository = userRepository;
            _userCodeService = userCodeService;
            _mapper = mapper;
            _configuration = configuration;
            _refreshTokenRepository = refreshTokenRepository;
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.signInManager = signInManager;

        }

        #endregion constructors

        #region public methods
     
   
        public async Task<ApiResponseMessage<String>> GetUserCityAsync(string userId)
        {

            var result = new ApiResponseMessage<String>();
            try
            {
                var user = await userManager.FindByIdAsync(userId);
                if (user != null && user.City != null)
                {

                    result.IsSuccess = true;
                    result.Result = user.City;
                    result.Message = "User city received";

                }
                else
                {
                    result.IsSuccess = false;
                    result.Message = "Not found";
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message =$"Something Went Wrong in the {nameof(GetUserCityAsync)} - {ex}";
                
                
            }
            return result;

           
        }
      
        public async Task<ApiResponseMessage<bool>> CreateUserAsync(CreateUserDTO dto)
        {
            var result = new ApiResponseMessage<bool>();
            try
            {
                string code = _userCodeService.CreateCode(4);
                User user = _mapper.Map<User>(dto);
                user.UserName = user.Email;

                user.RegistrationCode = code;


                string subject = "Код подтверждения InoCar:";

                _userCodeService.SendEmail(user.Email, code, subject);
                var registrationResult = await userManager.CreateAsync(user);

                if (registrationResult.Succeeded)
                {

                    result.IsSuccess = true;
                    result.Result = true;
                    result.Message = "User is registered and the code is sent";

                }
                else
                {
                    result.IsSuccess = false;
                    result.Message = "User is not registered or the code is not sent";
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(CreateUserAsync)} - {ex}";

            }
          
            return result;

           
        }

        public async Task<ApiResponseMessage<bool>> ConfirmUserEmailAsync(AddUserCodeDTO dto)
        {
            var result = new ApiResponseMessage<bool>();
            try
            {
                bool isConfirm = await _userCodeService.CompareCodeAsync(dto.Email, dto.Code);

                if (isConfirm)
                {

                    result.IsSuccess = true;
                    result.Message = "Confirmed";
                    result.Result = true;

                }
                else
                {
                    result.IsSuccess = false;
                    result.Message = "Not confirmed";
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(ConfirmUserEmailAsync)} - {ex}";
            }
            return result;
        }


        public async Task<ApiResponseMessage<TokensDTO>> AddUserPasswordAsync(AddPasswordDTO dto)
        {
            var result = new ApiResponseMessage<TokensDTO>();
            try
            {
                User? user = await userManager.FindByEmailAsync(dto.Email);

                if (user != null && user.EmailConfirmed)
                {
                    string PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);
                    user.PasswordHash = PasswordHash;
                    var identityResult = await userManager.UpdateAsync(user);
                    if (identityResult.Succeeded)
                    {
                        if (!await roleManager.RoleExistsAsync(UserRole.User)) await roleManager.CreateAsync(new IdentityRole(UserRole.User));
                        if (!await roleManager.RoleExistsAsync(UserRole.Admin)) await roleManager.CreateAsync(new IdentityRole(UserRole.Admin));
                          
                        await userManager.AddToRoleAsync(user, UserRole.User);
                        var tokens = await GetTokensAsync(user);
                        if (tokens != null)
                        {
                            result.IsSuccess = true;
                            result.Result = tokens;
                            result.Message = "Password added";

                        }
                        else
                        {
                            result.IsSuccess = false;
                            result.Message = "Tokens not generated";
                        }


                    }
                    else
                    {
                        result.IsSuccess = false;
                        result.Message = "Password not added";

                    }

                }
                else
                {
                    result.IsSuccess = false;
                    result.Message = "User not found";

                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(AddUserPasswordAsync)} - {ex}";
            }
            return result;
        }
        
        public async Task<ApiResponseMessage<TokensDTO>> LoginAsync(LoginUserDTO dto)
        {
            var result = new ApiResponseMessage<TokensDTO>();
            try
            {


                if (!await roleManager.RoleExistsAsync(UserRole.Admin)) await roleManager.CreateAsync(new IdentityRole(UserRole.Admin));
                var admin = await userManager.FindByEmailAsync("John-old@mail.ru");
                var existAdmin = await userManager.GetRolesAsync(admin);
                if (!existAdmin.Contains(UserRole.Admin)) await userManager.AddToRoleAsync(admin, UserRole.Admin);

                User? user = await userManager.FindByEmailAsync(dto.Email);

                if (user != null && user.EmailConfirmed)
                {

                    bool signInResult = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);

                    if (signInResult)
                    {

                        result.IsSuccess = true;
                        result.Result = await GetTokensAsync(user); ;
                        result.Message = "User login in";
                    }
                    else
                    {
                        result.IsSuccess = false;
                        result.Message = "Wrong login or password";
                    }
                }
                else
                {
                    result.IsSuccess = false;
                    result.Message = "User not found or not confirmed";
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(LoginAsync)} - {ex}";
            }
            return result; 
           
        }
        public async Task<ApiResponseMessage<bool>> SendUrlAsync(string email)
        {
            var result = new ApiResponseMessage<bool>();
            try
            {
                User? user = await userManager.FindByEmailAsync(email);

                if (user != null && user.EmailConfirmed)
                {
                    string code = Guid.NewGuid().ToString();

                    ResetPasswordCode? resetPasswordCode = await _userRepository.GetResetCodeAsync(user.Id);

                    if (resetPasswordCode != null) await SetNotActiveResetCodeAsync(resetPasswordCode);

                    _userCodeService.SendResetPasswordURL(email, code);

                    ResetPasswordCode passwordCode = new(user.Id, code);

                    await _userRepository.AddResetPasswordCodeAsync(passwordCode);

                    result.IsSuccess = true;
                    result.Message = "Reset password url sent";

                }
                else
                {
                    result.IsSuccess = false;
                    result.Message = "Sending URL for reset password not worked";
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(SendUrlAsync)} - {ex}";
            }


            return result;
        }


        public async Task<ApiResponseMessage<TokensDTO>> RefreshAsync(RefreshTokenDTO dto)
        {
            var result = new ApiResponseMessage<TokensDTO>();
            try
            {
                var refreshToken = await _refreshTokenRepository.SearchTokenAsync(dto.Token);

                if (refreshToken != null && refreshToken.IsActive != false)
                {

                    result.IsSuccess = true;
                    result.Result = await GenerateTokenAsync(refreshToken.User);
                    result.Message = "Tokens refreshed";
                    await _refreshTokenRepository.DeleteTokenAsync(refreshToken);
                }
                else
                {
                    result.IsSuccess = false;
                    result.Message = "Not found";
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(RefreshAsync)} - {ex}";
            }
            return result;
        }

      
        public async Task<ApiResponseMessage<bool>> ResetPasswordAsync(AddNewPasswordDTO dto)
        {

            var result = new ApiResponseMessage<bool>();
            try
            {
                User? user = await userManager.FindByEmailAsync(dto.Email);

                if (user != null && user.EmailConfirmed)
                {
                    ResetPasswordCode? resetPasswordCode = await _userRepository.GetResetCodeAsync(user.Id);

                    if (resetPasswordCode != null && (DateTime.Now - resetPasswordCode.CreatedDate).Days >= 1)
                    {
                        await SetNotActiveResetCodeAsync(resetPasswordCode);
                        result.IsSuccess = false;
                        result.Message = "Link to reset is already not active";
                        return result;

                    }
                    if (resetPasswordCode != null && resetPasswordCode.IsActive && !resetPasswordCode.IsDeleted && resetPasswordCode.Code == dto.Code)
                    {
                        string PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);
                        user.PasswordHash=PasswordHash;
                        await SetNotActiveResetCodeAsync(resetPasswordCode);
                        await userManager.UpdateAsync(user);
                        result.IsSuccess = true;
                        result.Message = "Password changed";
                    }

                }
                else
                {
                    result.IsSuccess = false;
                    result.Message = "User not found or not confirmed";
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(ResetPasswordAsync)} - {ex}";
            }

            return result;


        }

       public async Task<ApiResponseMessage<bool>> UpdateProfileAsync(UpdateProfileDTO dto, string userId)
        {
            var result = new ApiResponseMessage<bool>();
            try
            {
                User? user = await userManager.FindByIdAsync(userId);

                if (user == null)
                {
                    result.IsSuccess = false;
                    result.Message = "User not found";
                    return result;
                }

                if (!String.IsNullOrEmpty(dto.City)) user.City = dto.City;
                if (!String.IsNullOrEmpty(dto.LastName)) user.LastName = dto.LastName;
                if (!String.IsNullOrEmpty(dto.FirstName)) user.FirstName = dto.FirstName;
                if (!String.IsNullOrEmpty(dto.Patronymic)) user.Patronymic = dto.Patronymic;

                await _userRepository.UpdateUserAsync(user);
                result.IsSuccess = true;
                result.Message = "User Profile  updated";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(UpdateProfileAsync)} - {ex}";
            }
            return result;
        }



        public async Task<ApiResponseMessage<ApiUserProfile>> GetUserProfile(string userId)
        {
            var result = new ApiResponseMessage<ApiUserProfile>();
            try
            {
                User? user = await _userRepository.GetUserByIdAsync(userId);

                if (user == null)
                {
                    result.IsSuccess = false;
                    result.Message = "User not found or  email not confirmed";
                    return result;
                }
                
                ApiUserProfile apiUserProfile = _mapper.Map<ApiUserProfile>(user);
                result.IsSuccess = true;
                result.Result = apiUserProfile;
                result.Message = "User profile received";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(GetUserProfile)} - {ex}";
            }
            return result;

        }
        #endregion public methods

        #region private methods

        private async Task<TokensDTO?> GetTokensAsync(User user)
        {
            var tokens = await GenerateTokenAsync(user);

            RefreshToken token = new(user.Id, tokens.RefreshToken);

            await _refreshTokenRepository.AddTokenAsync(token);

            return tokens;
        }

        private async Task<bool> SetNotActiveResetCodeAsync(ResetPasswordCode resetPasswordCode)
        {

            resetPasswordCode.IsActive = false;
            resetPasswordCode.IsDeleted = true;
            await _userRepository.UpdateResetPasswordCodeAsync(resetPasswordCode);
            return true;
        }


        private async Task<TokensDTO> GenerateTokenAsync(User user)
        {

            
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new List<Claim>
                {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                      
                }),
                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var userRoles = await  userManager.GetRolesAsync(user);
            foreach (var userRole in userRoles)
            {
                tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, userRole)); 
            }
          
             var token = tokenHandler.CreateToken(tokenDescriptor);
           
            string code = _userCodeService.CreateCode(10);
            var rToken = BCrypt.Net.BCrypt.HashPassword(code);
            return new TokensDTO
            {
                AccessToken = tokenHandler.WriteToken(token),
                RefreshToken = rToken,

            };


        }

       #endregion private methods
        #region private fields

        private readonly IUserRepository _userRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IUserCodeService _userCodeService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
     
       


        #endregion private fields
    }
}
