using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs;
using Core.Models;

namespace Core.Interfaces
{

     public interface IUserService
    {
        Task<ServiceResponse<List<RegistroDto>>> AddData(RegistroDto dto);
        Task<ServiceResponse<List<RegistroDto>>> GetAll();
        Task<ServiceResponse<RegistroDto>> GetById(int id);
        Task<ServiceResponse<List<RegistroDto>>> UpdateData(RegistroDto dto);
        Task<ServiceResponse<List<RegistroDto>>> Delete(int id);
     
        Task<ServiceResponse<LoginResponseDto>> Login(LoginDto dto);
    }
}