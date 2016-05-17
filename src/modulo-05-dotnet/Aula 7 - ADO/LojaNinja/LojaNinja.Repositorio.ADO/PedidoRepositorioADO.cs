
using LojaNinja.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaNinja.Repositorio.ADO
{
    public class PedidoRepositorioADO : IPedidoRepositorio
    {
        public void AtualizarPedido(Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public void ExcluirPedido(int id)
        {
            throw new NotImplementedException();
        }

        public void IncluirPedido(Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public List<Pedido> ObterPedidoPorFiltro(string cliente, string produto)
        {
            throw new NotImplementedException();
        }

        public Pedido ObterPedidoPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Pedido> ObterPedidos()
        {
            throw new NotImplementedException();
        }
    }
}
