using InoCar.Api.Model;
using InoCar.Data.Entities;
using InoCar.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Services
{
    public interface IUserService
    {

        Task<ApiResponseMessage<bool>> CreateUserAsync(CreateUserDTO dto);
        Task<ApiResponseMessage<bool>> ConfirmUserEmailAsync(AddUserCodeDTO dto);
        Task<ApiResponseMessage<TokensDTO>> AddUserPasswordAsync(AddPasswordDTO dto);
        Task<ApiResponseMessage<TokensDTO>> LoginAsync(LoginUserDTO dto);
        Task<ApiResponseMessage<TokensDTO>> RefreshAsync(RefreshTokenDTO dto);
        Task<ApiResponseMessage<bool>> SendUrlAsync(string email);
        Task<ApiResponseMessage<bool>> ResetPasswordAsync(AddNewPasswordDTO dto);
        Task<ApiResponseMessage<bool>> UpdateProfileAsync(UpdateProfileDTO dto, string userId);
        Task<ApiResponseMessage<string>> GetUserCityAsync(string userId);
        Task<ApiResponseMessage<ApiUserProfile>> GetUserProfile(string userId);

    }
}
