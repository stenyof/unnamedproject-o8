using System.ComponentModel.DataAnnotations.Schema;

namespace myfinance_web_netcore.Infrastructure.Entities
{
    [Table("PlanoConta")]
    public class PlanoConta
    {
        public int Id { get; set; }

        public required string Nome { get; set; }

        public required string Tipo { get; set; }

        public required string Descricao { get; set; }
        public ICollection<Transacao>? Transacoes { get; set; }
    }
}
