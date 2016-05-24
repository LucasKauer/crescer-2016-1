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
            using (var db = new ContextoDeDados())
            {
                return db.Pedido.FirstOrDefault(p => p.Id == id);
            }
        }

        public IList<Pedido> BuscarPedidosDoCliente(int idCliente)
        {
            using (var db = new ContextoDeDados())
            {
                return db.Pedido.Where(p => p.Cliente.Id == idCliente)
                                .ToList();
            }
        }

        public IList<Pedido> BuscarPedidosDoCliente(int idCliente, StatusPedido statusPedido)
        {
            using (var db = new ContextoDeDados())
            {
                return db.Pedido.Where(p => p.Cliente.Id == idCliente && p.StatusPedido == statusPedido)
                                .ToList();
            }
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
