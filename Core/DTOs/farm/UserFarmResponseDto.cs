using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace Core.DTOs.farm
{
    public class UserFarmResponseDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Classifica { get; set; } = string.Empty;
        public DateTime DateCadastro { get; set; } = DateTime.UtcNow;
        public List<FarmModellDto> Fazendas { get; set; } = [];

        
    }
}