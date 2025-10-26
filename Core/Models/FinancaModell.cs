using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class FinancaModell
    {
        public Guid Id { get; set; }
        public string? Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string Tipo { get; set; } = "saida";

        public Guid? CustoPlantacaoId { get; set; }
        public CustoPlantacaoModell? CustoPlantacao { get; set; }

        public Guid? ManutencaoMaquinaId { get; set; }
        public ManutencaoMaquinaModell? Manutencao { get; set; }

        public Guid? FarmId { get; set; }
        public FarmModell? Farm { get; set; }
    }
}