using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class FarmModell
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string AreaHectares { get; set; } = string.Empty;
        public ICollection<UserFarmModell> UserFarms { get; set; } = new List<UserFarmModell>();
        public ICollection<MaquinaModell> Maquinas { get; set; } = new List<MaquinaModell>();
        public ICollection<PlantacaoModell> Plantacoes { get; set; } = new List<PlantacaoModell>();
        public ICollection<FinancaModell> Financas { get; set; } = new List<FinancaModell>();


    }

    public class UserFarmModell
    {
        public Guid UserId { get; set; }
        public UserModell? User { get; set; }
        public Guid FarmId { get; set; }
        public FarmModell? Farm { get; set; } 

        public string TipoAcesso { get; set; } = "Propetario";
        public DateTime DataVicuclo { get; set; } = DateTime.UtcNow; 
        
    }
}