using LojaNinja.Dominio;
using LojaNinja.Repositorio.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaNinja.MVC.Services
{
    public static class ServicoInjecaoDeDependecia
    {
        public static IUsuarioRepositorio CriarUsuarioRepositorio()
        {
            return new UsuarioRepositorioEF();
        }

        public static IPedidoRepositorio CriarPedidoRepositorio()
        {
            return new PedidoRepositorioEF();
        }
    }
}