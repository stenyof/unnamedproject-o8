
namespace myfinance_web_netcore.Domain
{
    public class Transacao
    {
        public int Id { get; set; }
        public string Historico { get; set; } = string.Empty;
        public DateTime DataTransacao { get; set; }
        public int PlanoContaId { get; set; }
        public decimal Valor { get; set; }

        public PlanoConta? PlanoConta { get; set; }
    }
}
