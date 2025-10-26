using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class UserModell
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserName { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Classifica { get; set; } = "Admin";
        public DateTime DateCadastro { get; set; } = DateTime.UtcNow;

        public ICollection<UserFarmModell> UserFarms { get; set; } = new List<UserFarmModell>();

     
    }
}