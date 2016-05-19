using Loja.Dominio;
using Loja.Infraestrutura;
using Loja.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.App
{
    public static class ServicoInjecaoDependencia
    {
        public static PedidoServico CriarServicoPedido()
        {
            return new PedidoServico(
                new PedidoRepositorio(),
                new ServicoEmail());
        }
    }
}
