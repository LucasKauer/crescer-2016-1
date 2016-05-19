using Loja.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTest.Mocks
{
    public class PedidoRepositorioMock : IPedidoRepositorio
    {
        private IList<Pedido> _pedidos = new List<Pedido>();

        public Pedido BuscarPedidoPorId(int id)
        {
            return _pedidos.FirstOrDefault(p => p.Id == id);
        }

        public IList<Pedido> BuscarPedidosDoCliente(int idCliente)
        {
            return _pedidos.Where(p => p.Cliente.Id == idCliente).ToList();
        }

        public IList<Pedido> BuscarPedidosDoCliente(int idCliente, StatusPedido statusPedido)
        {
            return _pedidos.Where(p => p.Cliente.Id == idCliente && p.StatusPedido == statusPedido).ToList();
        }

        public void SalvarPedido(Pedido pedido)
        {
            if(pedido.Id > 0)
            {
                for (int i = 0; i < _pedidos.Count; i++)
                {
                    if(_pedidos[i].Id == pedido.Id)
                    {
                        _pedidos[i] = pedido;
                        break;
                    }
                }
            }
            else
            {
                _pedidos.Add(pedido);
            }
        }
    }
}
