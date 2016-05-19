using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Dominio
{
    public interface IPedidoRepositorio
    {
        void SalvarPedido(Pedido pedido);
        Pedido BuscarPedidoPorId(int id);
        IList<Pedido> BuscarPedidosDoCliente(int idCliente);
        IList<Pedido> BuscarPedidosDoCliente(int idCliente, StatusPedido statusPedido);
    }
}
