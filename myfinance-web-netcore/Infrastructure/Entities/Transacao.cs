using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myfinance_web_netcore.Infrastructure.Entities
{
    [Table("Transacao")]
    public class Transacao
    {
        [Key]
        public int Id { get; set; }

        public string Historico { get; set; } = string.Empty;

        public DateTime DataTransacao { get; set; }

        public int PlanoContaId { get; set; }

        public decimal Valor { get; set; }
        public PlanoConta PlanoConta { get; set; } = null!;
    }
}
