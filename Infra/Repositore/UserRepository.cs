using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositore
{
    public class UserRepository : GenericRepositories<UserModell>, IUserRespository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
          public async Task<UserModell?> GetUserName(string userName)
        {
            var response = await _context.RegistroUsuario
            .Include(user => user.UserFarms)
            .ThenInclude(userFarm => userFarm.Farm)
            .FirstOrDefaultAsync(relacao => relacao.UserName == userName);
            return response;
        }

        public async Task<bool> UserExists(string name)
        {
            return await _context.RegistroUsuario.AnyAsync(u => u.UserName == name);
        }
    }
}