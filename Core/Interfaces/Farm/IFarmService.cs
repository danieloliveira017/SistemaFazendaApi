using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs;
using Core.DTOs.farm;
using Core.Models;

namespace Core.Interfaces
{
    public interface IFarmService
    {
        Task<ServiceResponse<UserFarmResultDto>> AddData(FarmModellDto dto);
        Task<ServiceResponse<UserFarmResponseDto>> GetAll();
        Task<ServiceResponse<FarmModellDto>> GetById(int id);
        Task<ServiceResponse<List<FarmModellDto>>> UpadateData(FarmModellDto dto);
        Task<ServiceResponse<List<FarmModellDto>>> Delete(int id);
        
    }
}