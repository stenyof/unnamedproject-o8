using Microsoft.AspNetCore.Mvc.Rendering;

namespace myfinance_web_netcore.Domain
{
    public class TransacaoModel
    {
        public int? Id { get; set; }
        public string Historico { get; set; } = string.Empty;
        public DateTime DataTransacao { get; set; }
        public decimal Valor { get; set; }
        public int PlanoContaId { get; set; }
        public string PlanoContaNome { get; set; } = string.Empty;

        public SelectList PlanoContasSelectList { get; set; } = new SelectList(Enumerable.Empty<SelectListItem>());
    }
}
