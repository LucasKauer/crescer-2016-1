using LojaNinja.Dominio;
using LojaNinja.MVC.Filters;
using LojaNinja.MVC.Models.Login;
using LojaNinja.MVC.Services;
using LojaNinja.Repositorio.ADO;
using LojaNinja.Repositorio.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaNinja.MVC.Controllers
{
    public class LoginController : Controller
    {
        private UsuarioServico _usuarioServico;

        public LoginController()
        {
            _usuarioServico = new UsuarioServico(
                    ServicoInjecaoDeDependecia.CriarUsuarioRepositorio()
                );
        }

        [HttpGet]
        public ActionResult Index()
        {
            if (!ServicoDeSessao.EstaLogado)
            {
                return View();
            }

            return RedirectToAction("Listagem", "Pedido");
        }

        [HttpGet]
        public ActionResult Loggout()
        {
            ServicoDeSessao.Sair();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Entrar(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                Usuario usuarioEncontrado =
                    _usuarioServico.BuscarUsuarioPorAutenticacao(
                            loginViewModel.Email, loginViewModel.Senha
                        );

                if (usuarioEncontrado != null)
                {
                    var usuarioLogadoModel = new UsuarioLogadoModel(usuarioEncontrado);

                    ServicoDeSessao.CriarSessao(usuarioLogadoModel);
                    return RedirectToAction("Listagem", "Pedido");
                }
                else
                {
                    ModelState.AddModelError("INVALID_USER", "Usuário ou senha inválido.");
                }
            }

            return View("Index", loginViewModel);
        }
        
    }
}