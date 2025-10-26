using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class LoginResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Classifica { get; set; } = string.Empty;
        public DateTime DateCadastro { get; set; } = DateTime.UtcNow;
        public List<FarmModellDto> Fazendas { get; set; } =  new List<FarmModellDto>();
    }
}