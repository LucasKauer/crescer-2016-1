using CdZ.Dominio;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CdZ.Repositorio.EF
{
    /*
     * Criamos nosso repositório de pedidos aqui, implementando nossa
     * interface de regras de repositório de pedidos.
     */
    public class CavaleiroRepositorioEF : ICavaleiroRepositorio
    {
        public int Adicionar(Cavaleiro cavaleiro)
        {
            using (var db = new ContextoDeDados())
            {
                /*
                 * Para informarmos um INSERT, devemos setar o State como Added.
                 */
                db.Entry<Cavaleiro>(cavaleiro).State = EntityState.Added;
                db.SaveChanges();
                return cavaleiro.Id;
            }
        }

        public Cavaleiro Buscar(int id)
        {
            using (var db = new ContextoDeDados())
            {
                /*
                 * Estamos utilizando Include para fazer o "Eager Load"
                 * dos relacionamentos, e poder deletá-los em cascata.
                */
                return db.Cavaleiro
                    .Include(_ => _.LocalNascimento)
                    .Include(_ => _.LocalTreinamento)
                    .Include(_ => _.Golpes)
                    .Include(_ => _.Imagens)
                    .SingleOrDefault(_ => _.Id == id);
            }
        }

        public IEnumerable<Cavaleiro> Todos()
        {
            using (var db = new ContextoDeDados())
            {
                //TODO: paginar
                return db.Cavaleiro.ToList();
            }
        }

        public void Excluir(int id)
        {
            using (var db = new ContextoDeDados())
            {
                /*
                 * Para realizar um DELETE no banco de dados,
                 * infelizmente precisamos buscar o objeto no banco para então
                 * removê-lo.
                 */
                var cavaleiroASerExcluido = db.Cavaleiro.Find(id);
                var localNascimento = db.Cavaleiro.Include(_ => _.LocalNascimento).Single(_ => _.Id == id).LocalNascimento;
                var localTreinamento = db.Cavaleiro.Include(_ => _.LocalTreinamento).Single(_ => _.Id == id).LocalTreinamento;
                // devido à FK partindo de cavaleiro para local primeiro removemos cavaleiro
                db.Cavaleiro.Remove(cavaleiroASerExcluido);
                db.Local.Remove(localNascimento);
                db.Local.Remove(localTreinamento);
                db.SaveChanges();
            }
        }

        public void Atualizar(Cavaleiro cavaleiro)
        {
            /*
             * Para fazermos uma conexão com o banco via EF, precisamos
             * instanciar um objeto do mesmo tipo de nosso DbContext, que no nosso
             * caso é o ContextoDeDados.
             */
            using (var db = new ContextoDeDados())
            {
                // Atualizamos o estado de todos os objetos envolvidos em relacionamentos com Cavaleiro.
                // Caso Id seja diferente de 0, é atualizado. Caso seja 0, é inserido.
                db.Entry<Local>(cavaleiro.LocalNascimento).State = cavaleiro.LocalNascimento.Id == default(int) ? EntityState.Added : EntityState.Modified;
                db.Entry<Local>(cavaleiro.LocalTreinamento).State = cavaleiro.LocalTreinamento.Id == default(int) ? EntityState.Added : EntityState.Modified;

                foreach (var golpe in cavaleiro.Golpes)
                {
                    db.Entry<Golpe>(golpe).State = golpe.Id == default(int) ? EntityState.Added : EntityState.Modified;
                }

                foreach (var imagem in cavaleiro.Imagens)
                {
                    db.Entry<Imagem>(imagem).State = imagem.Id == default(int) ? EntityState.Added : EntityState.Modified;
                }

                db.Entry<Cavaleiro>(cavaleiro).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
