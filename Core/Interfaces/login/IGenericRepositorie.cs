using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGenericRepositorie<T> where T: class
    {
        Task<ServiceResponse<List<T>>> Getall();
        Task<ServiceResponse<T>> GetId(Guid id);
        Task<ServiceResponse<T>> AddData(T data);
        Task<ServiceResponse<List<T>>> UpdateData(T data);
        Task<ServiceResponse<List<T>>> DeletData(Guid id);
       
        
    }
}