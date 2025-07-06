using Microsoft.AspNetCore.Mvc;
using myfinance_web_netcore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace myfinance_web_netcore.Controllers
{
    public class RelatorioController : Controller
    {
        private readonly MyFinanceDbContext _dbContext;

        public RelatorioController(MyFinanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var transacoes = _dbContext.Transacao
                .Include(t => t.PlanoConta)
                .ToList();

            var dadosPorMes = transacoes
                .GroupBy(t => t.DataTransacao.ToString("yyyy-MM"))
                .OrderBy(g => g.Key)
                .ToDictionary(
                    g => g.Key,
                    g => g.Sum(x => x.Valor)
                );

            var dadosPorPlanoConta = transacoes
                .GroupBy(t => t.PlanoConta.Nome)
                .OrderByDescending(g => g.Sum(x => x.Valor))
                .ToDictionary(
                    g => g.Key,
                    g => g.Sum(x => x.Valor)
                );

            ViewBag.Meses = dadosPorMes.Keys.ToList();
            ViewBag.ValoresMes = dadosPorMes.Values.ToList();

            ViewBag.Planos = dadosPorPlanoConta.Keys.ToList();
            ViewBag.ValoresPlano = dadosPorPlanoConta.Values.ToList();

            return View();
        }
    }
}
