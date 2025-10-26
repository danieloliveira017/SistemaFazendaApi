using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;

namespace Core.DTOs.farm
{
    public interface IFarmRespository : IGenericRepositorie<FarmModell>
    {
        Task<bool> FarmExists(string name);
    }
}