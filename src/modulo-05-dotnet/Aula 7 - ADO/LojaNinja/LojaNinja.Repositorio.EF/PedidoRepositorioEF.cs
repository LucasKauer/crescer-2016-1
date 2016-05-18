using LojaNinja.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LojaNinja.Repositorio.EF
{
    /*
     * Criamos nosso repositório de pedidos aqui, implementando nossa
     * interface de regras de repositório de pedidos.
     */
    public class PedidoRepositorioEF : IPedidoRepositorio
    {
        public void AtualizarPedido(Pedido pedido)
        {
            /*
             * Para fazermos uma conexão com o banco via EF, precisamos
             * instanciar um objeto do mesmo tipo de nosso DbContext, que no nosso
             * caso é o ContextoDeDados.
             */
            using (var db = new ContextoDeDados())
            {
                /*
                 * Existem várias formas de fazer um Update de uma entidade.
                 * Um deles é utilizando o método Entry, na qual você informa o tipo
                 * de objeto que será feito o update (<Pedido>), passa o objeto
                 * como parâmetro em seguida seta o stado deste objeto no banco de dados.
                 * O EF irá saber que deve fazer um Update quando o estado for EntityState.Modified.
                 * 
                 * Em seguida chamaremos o método .SaveChanges(), que irá definitivamente
                 * executar a query no banco de dados.
                 */
                db.Entry<Pedido>(pedido).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void ExcluirPedido(int id)
        {
            using (var db = new ContextoDeDados())
            {
                /*
                 * Para realizar um DELETE no banco de dados,
                 * infelizmente precisamos buscar o objeto no banco para então
                 * removê-lo.
                 */
                Pedido pedidoASerExcluido = db.Pedido.Find(id);
                db.Entry<Pedido>(pedidoASerExcluido).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void IncluirPedido(Pedido pedido)
        {
            using (var db = new ContextoDeDados())
            {
                /*
                 * Para informarmos um INSERT, devemos setar o State como Added.
                 */
                db.Entry<Pedido>(pedido).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public List<Pedido> ObterPedidoPorFiltro(string cliente, string produto)
        {
            using (var db = new ContextoDeDados())
            {
                /*
                 * Cada propriedade DbSet de nosso contexto é um IQueryable.
                 * Um IQueryable é uma... query.
                 * Não indica que estamos indo à banco fazer a consta, estamos apenas
                 * montando nossa query, ok?
                 * 
                 * Neste caso, seria como se estivéssemos iniciando nossa query com
                 * um 'SELECT * FROM Pedido'
                 */
                IQueryable<Pedido> query = db.Pedido;

                if(!String.IsNullOrWhiteSpace(cliente))
                {
                    /*
                     * Aqui estamos concatenando nossa query,
                     * que agora não é só mais um 'SELECT * FROM Pedido', mas
                     * um 'SELECT * FROM Pedido WHERE NomeCliente = 'valor da variável cliente''
                     */
                    query = query.Where(p => p.NomeCliente.Equals(cliente));
                }

                if(!String.IsNullOrWhiteSpace(produto))
                {
                    query = query.Where(p => p.NomeProduto.Equals(produto));
                }

                /*
                 * Quando executamos métodos como ToList, ToArray, FirstOrDefault, First, Single,
                 * Any, entre outros (ou seja, que não retornam IQueryable ou IEnumerable),
                 * estamos, neste momento, EXECUTANDO a query montada anteriormente no banco 
                 * de dados, lendo seus dados, convertendo para objetos, e retornando uma lista deles.
                 */
                return query.ToList();
            }
        }

        public Pedido ObterPedidoPorId(int id)
        {
            using (var db = new ContextoDeDados())
            {
                return db.Pedido.Find(id);
            }
        }

        public List<Pedido> ObterPedidos()
        {
            using (var db = new ContextoDeDados())
            {
                //TODO: paginar
                return db.Pedido.ToList();
            }
        }
    }
}
