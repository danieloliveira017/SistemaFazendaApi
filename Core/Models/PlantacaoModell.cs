using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class PlantacaoModell
    {
       public Guid Id { get; set; }
        public string TipoPlantio { get; set; } = string.Empty;
        public double QuantidadeHectares { get; set; }

        public Guid? FarmId { get; set; }
        public FarmModell? Farm { get; set; }

        public ICollection<CustoPlantacaoModell> Custos { get; set; } = new List<CustoPlantacaoModell>();

        public DateTime DateCadastro { get; set; } = DateTime.UtcNow;
    }

    public class CustoPlantacaoModell
    {
        public Guid Id { get; set; }
        public string NomeCusto { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public string? Observacao { get; set; }

        public Guid? PlantacaoId { get; set; }
        public PlantacaoModell? Plantacao { get; set; }

        public ICollection<FinancaModell> Financas { get; set; } = new List<FinancaModell>();

        public DateTime DateCusto { get; set; } = DateTime.UtcNow;
    }

}