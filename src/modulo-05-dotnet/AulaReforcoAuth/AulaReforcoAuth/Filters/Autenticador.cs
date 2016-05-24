using AulaReforcoAuth.Models;
using AulaReforcoAuth.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AulaReforcoAuth.Filters
{
    public class Autenticador : AuthorizeAttribute
    {
        private string[] _permissoes = null;

        private string[] Permissoes
        {
            get
            {
                if(_permissoes == null)
                {
                    _permissoes = String.IsNullOrWhiteSpace(this.Roles) ?
                                new string[0] :
                                this.Roles.Split(',');
                }

                return _permissoes;
            }
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            UsuarioLogadoModel usuario = ServicoSessao.UsuarioLogado;

            bool usuarioEstaLogado = ServicoSessao.EstaLogado;
            bool usuarioPossuiPermissao = this.Permissoes.Length < 1;

            if(!usuarioPossuiPermissao)
            {
                usuarioPossuiPermissao = usuario.Permissoes.Any(u => this.Permissoes.Contains(u));
            }

            return usuarioEstaLogado && usuarioPossuiPermissao;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            bool estaAutorizado = AuthorizeCore(filterContext.HttpContext);

            if(!estaAutorizado)
            {
                filterContext.Result = new RedirectToRouteResult(
                                   new RouteValueDictionary
                                   {
                                       { "action", "Unauthorized" },
                                       { "controller", "Global" }
                                   });
            }

            //base.OnAuthorization(filterContext);
        }
    }
}