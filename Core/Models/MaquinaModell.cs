using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class MaquinaModell
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string TipoMaquina { get; set; } = string.Empty;

        public Guid? FarmId { get; set; }
        public FarmModell? Farm { get; set; }

        public ICollection<ManutencaoMaquinaModell> Manutencoes { get; set; } = new List<ManutencaoMaquinaModell>();

        public DateTime DateCadastro { get; set; } = DateTime.UtcNow;
    }

    public class ManutencaoMaquinaModell
    {
        public Guid Id { get; set; }
        public string TipoManutencao { get; set; } = string.Empty;
        public decimal ValorManutencao { get; set; }
        public string? Observacao { get; set; }

        public Guid? MaquinaId { get; set; }
        public MaquinaModell? Maquina { get; set; }

        public ICollection<FinancaModell> Financas { get; set; } = new List<FinancaModell>();

        public DateTime DateManutencao { get; set; } = DateTime.UtcNow;
    }

}