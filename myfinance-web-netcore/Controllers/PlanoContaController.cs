using Microsoft.AspNetCore.Mvc;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Services;

namespace myfinance_web_netcore.Controllers
{
    public class PlanoContaController : Controller
    {
        private readonly IPlanoContaService _planoContaService;

        public PlanoContaController(IPlanoContaService planoContaService)
        {
            _planoContaService = planoContaService;
        }

        public IActionResult Index()
        {
            var lista = _planoContaService.ListarRegistros();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            if (id != null)
            {
                var registro = _planoContaService.RetornarRegistro((int)id);
                return View(registro);
            }

            return View(new PlanoContaModel());
        }

        [HttpPost]
        public IActionResult Cadastro(PlanoContaModel model)
        {
            _planoContaService.Salvar(model);
            return RedirectToAction("Index");
        }

        public IActionResult Excluir(int id)
        {
            _planoContaService.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}