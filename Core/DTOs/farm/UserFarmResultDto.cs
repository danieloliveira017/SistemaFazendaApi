using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.DTOs.farm
{
    public class UserFarmResultDto
    {
        public Guid Farmid { get; set; }
        public string NomeFazenda { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public string NomeUser { get; set; } = string.Empty;
        public string TipoAcessp { get; set; } = string.Empty;
        public DateTime DataVinculo { get; set; } = DateTime.UtcNow;
    }
}