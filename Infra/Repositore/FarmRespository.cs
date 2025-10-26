using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs.farm;
using Core.Models;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositore
{
    public class FarmRespository : GenericRepositories<FarmModell>, IFarmRespository
    {
        private readonly AppDbContext _context;
        public FarmRespository(AppDbContext context): base(context)
        {
            _context = context;
        }

        public async Task<bool> FarmExists(string name)
        {
            return await _context.RegistroFazenda.AnyAsync(f => f.Nome == name);
        }
        
    }
}