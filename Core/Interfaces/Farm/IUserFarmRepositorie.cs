using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs;
using Core.DTOs.farm;
using Core.Models;

namespace Core.Interfaces
{
    public interface IUserFarmRepositorie : IGenericRepositorie<UserFarmModell>
    {

        Task<bool> ExisteVinculoUserFarm(Guid userId, Guid farmId);
        Task<UserModell?> GetFarmsByIdUser(Guid userId);

    }
}