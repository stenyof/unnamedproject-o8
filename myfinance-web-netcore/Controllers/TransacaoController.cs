using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Services;

namespace myfinance_web_netcore.Controllers
{
    public class TransacaoController : Controller
    {
        private readonly ITransacaoService _transacaoService;
        private readonly IPlanoContaService _planoContaService;

        public TransacaoController(ITransacaoService transacaoService, IPlanoContaService planoContaService)
        {
            _transacaoService = transacaoService;
            _planoContaService = planoContaService;
        }

        public IActionResult Index()
        {
            var lista = _transacaoService.ListarRegistros();
            return View(lista);
        }

        public IActionResult Cadastro(int? id)
        {
            var model = new TransacaoModel();

            if (id != null)
                model = _transacaoService.RetornarRegistro((int)id);

            var planosConta = _planoContaService.ListarRegistros();
            model.PlanoContasSelectList = new SelectList(planosConta, "Id", "Descricao");

            return View(model);
        }

        [HttpPost]
        public IActionResult Cadastro(TransacaoModel model)
        {
            _transacaoService.Salvar(model);
            return RedirectToAction("Index");
        }

        public IActionResult Excluir(int id)
        {
            _transacaoService.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}
