
namespace myfinance_web_netcore.Models
{
    public class TransacaoModel
    {
        public int? Id { get; set; }
        public string Historico { get; set; } = string.Empty;
        public DateTime DataTransacao { get; set; }
        public int PlanoContaId { get; set; }
        public decimal Valor { get; set; }
    }
}
