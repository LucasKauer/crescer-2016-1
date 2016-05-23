using exemplos_advanced.Models;
using System.Threading;
using System.Web.Mvc;

namespace exemplos_advanced.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detalhe(int id)
        {
            return PesquisarHtmlCavaleiro(id);
        }

        public ActionResult DetalheComLentidao(int id)
        {
            Thread.Sleep(5000);
            return PesquisarHtmlCavaleiro(id);
        }

        private ActionResult PesquisarHtmlCavaleiro(int id)
        {
            return PartialView("Detalhe", Cavaleiro.Obter(id));
        }
    }
}