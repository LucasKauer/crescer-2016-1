using AulaReforcoAuth.Filters;
using AulaReforcoAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AulaReforcoAuth.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            // verifiquei no banco
            // esta ok

            var usuario = new UsuarioLogadoModel()
            {
                Nome = "Batman",
                Permissoes = new string[1] { "ADMIN" }
            };

            Session["USUARIO_LOGADO"] = usuario;

            return RedirectToAction("Secret");
        }

        [Autenticador]
        public ActionResult Secret()
        {
            UsuarioLogadoModel usuario = (UsuarioLogadoModel)Session["USUARIO_LOGADO"];
            return View(usuario);
        }

        [Autenticador(Roles = "ADMIN")]
        public ActionResult SuperSecret()
        {
            UsuarioLogadoModel usuario = (UsuarioLogadoModel)Session["USUARIO_LOGADO"];
            return View(usuario);
        }
    }
}