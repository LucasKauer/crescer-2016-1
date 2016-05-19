using Loja.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Repositorio
{
    public class PedidoRepositorio : IPedidoRepositorio
    {
        public Pedido BuscarPedidoPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Pedido> BuscarPedidosDoCliente(int idCliente)
        {
            throw new NotImplementedException();
        }

        public IList<Pedido> BuscarPedidosDoCliente(int idCliente, StatusPedido statusPedido)
        {
            throw new NotImplementedException();
        }

        public void SalvarPedido(Pedido pedido)
        {
            using (var db = new ContextoDeDados())
            {
                db.Entry<Pedido>(pedido).State =
                    pedido.Id > 0 ?
                        System.Data.Entity.EntityState.Modified :
                        System.Data.Entity.EntityState.Added;

                db.Entry<Cliente>(pedido.Cliente).State = System.Data.Entity.EntityState.Unchanged;

                foreach (Produto produto in pedido.ItensDoPedido.Select(i => i.Produto))
                {
                    db.Entry<Produto>(produto).State = System.Data.Entity.EntityState.Modified;
                    db.Entry<Produto>(produto).Property(p => p.QuantidadeEstoque).IsModified = true;
                }
                
                db.SaveChanges();
            }
        }
    }
}
