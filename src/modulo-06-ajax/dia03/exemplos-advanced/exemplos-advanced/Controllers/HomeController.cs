using exemplos_advanced.Models;
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
            return PartialView("Detalhe", Cavaleiro.Obter(id));
        }
    }
}