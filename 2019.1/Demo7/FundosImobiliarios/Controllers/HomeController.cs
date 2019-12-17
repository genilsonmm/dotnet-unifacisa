using FundosImobiliarios.Models;
using FundosImobiliarios.Models.Corretoras;
using Microsoft.AspNetCore.Mvc;

namespace FundosImobiliarios.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Operacao([FromServices]ICorretora corretora, string id)
        {
            Ordem ordem1 = new Ordem(id, 20, 91.50, TipoOperacao.Compra);
            corretora.Operacao(ordem1);

            ViewData["resposta1"] = ProcessaOperacao(corretora);
            return View("Index");
        }

        private string ProcessaOperacao(ICorretora corretora)
        {
            BolsaDeValores bolsaDeValores = new BolsaDeValores(corretora);
            return bolsaDeValores.ProcessaSolicitacao();
        }
    }
}