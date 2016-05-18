using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaNinja.Dominio
{
    public interface IPedidoRepositorio
    {
        List<Pedido> ObterPedidos();

        Pedido ObterPedidoPorId(int id);

        List<Pedido> ObterPedidoPorFiltro(string cliente, string produto);

        void IncluirPedido(Pedido pedido);

        void AtualizarPedido(Pedido pedido);

        void ExcluirPedido(int id);
    }
}
