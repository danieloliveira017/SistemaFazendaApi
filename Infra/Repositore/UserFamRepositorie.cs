using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.DTOs;
using Core.DTOs.farm;
using Core.Interfaces;
using Core.Models;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositore
{
    public class UserFamRepositorie : GenericRepositories<UserFarmModell>, IUserFarmRepositorie
    {
        private readonly AppDbContext _context;

        public UserFamRepositorie(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> ExisteVinculoUserFarm(Guid userId, Guid farmId)
        {
            return await _context.UserFarm.AnyAsync(uf => uf.UserId == userId && uf.FarmId == farmId);
        }

        async Task<UserModell?> IUserFarmRepositorie.GetFarmsByIdUser(Guid userId)
        {
            var result = await _context.RegistroUsuario
            .Include(u => u.UserFarms)
            .ThenInclude(uf => uf.Farm)
            .FirstOrDefaultAsync(u => u.Id == userId);


            return result;
            

        }
    }


    }
