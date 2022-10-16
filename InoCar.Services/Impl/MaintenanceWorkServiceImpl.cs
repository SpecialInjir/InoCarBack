using AutoMapper;
using InoCar.Api.Model;
using InoCar.Data.Entities;
using InoCar.Repositories.Interfaces;
using InoCar.Services.DTO;
using InoCar.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Services.Impl
{
    public class MaintenanceWorkServiceImpl : IMaintenanceWorkService
    {
        #region constructors
        public MaintenanceWorkServiceImpl(IMaintenanceWorkRepository maintenanceWorkRepository, IMapper mapper)
        {
            _maintenanceWorkRepository = maintenanceWorkRepository;
            _mapper = mapper;

        }
        #endregion constructors
        #region public methods

        
       
        public async Task<ApiResponseMessage<bool>> UpdateMaintenanceWorkAsync(int maintenanceWorkId, MaintenanceWorkDTO dto)
        {
            var result = new ApiResponseMessage<bool>();
            try
            {
                MaintenanceWork? maintenanceWork = await _maintenanceWorkRepository.GetMaintenanceWorkByIdAsync(maintenanceWorkId);
                if (maintenanceWork == null)
                {
                    result.IsSuccess = false;
                    result.Result = false;
                    result.Message = "Maintenance Work not found";
                    return result;
                }
                maintenanceWork.Description = dto.Description;
                maintenanceWork.ExploitationMonths = dto.ExploitationMonths;
                maintenanceWork.Price = dto.Price;
                await _maintenanceWorkRepository.UpdateMaintenanceWorkAsync(maintenanceWork);
                result.IsSuccess = true;
                result.Result = true;
                result.Message = "Maintenance Work updated";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(UpdateMaintenanceWorkAsync)} - {ex}";
            }
            return result;
        }
        public async Task<ApiResponseMessage<bool>> DeleteMaintenanceWorkAsync(int maintenanceWorkId)
        {
            var result = new ApiResponseMessage<bool>();
            try
            {
                MaintenanceWork? maintenanceWork = await _maintenanceWorkRepository.GetMaintenanceWorkByIdAsync(maintenanceWorkId);
                if (maintenanceWork == null)
                {
                    result.IsSuccess = false;
                    result.Result = false;
                    result.Message = "Maintenance Work not found";
                    return result;
                }
                maintenanceWork.IsDeleted = true ;
                await _maintenanceWorkRepository.UpdateMaintenanceWorkAsync(maintenanceWork);
                result.IsSuccess = true;
                result.Result = true;
                result.Message = "Maintenance Work deleted";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(DeleteMaintenanceWorkAsync)} - {ex}";
            }
            return result;
        }
        #endregion public methods

        #region private fields

        private readonly IMapper _mapper;
        private readonly IMaintenanceWorkRepository _maintenanceWorkRepository;

        #endregion private fields
    }
}
