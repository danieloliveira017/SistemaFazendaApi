using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Interfaces
{
    public interface IUserRespository : IGenericRepositorie<UserModell>
    {
        Task<bool> UserExists(string name);
        Task<UserModell?> GetUserName(string UserName);
       
    }
}