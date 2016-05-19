using Loja.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        public Produto BuscarProdutoPorId(int id)
        {
            using (var db = new ContextoDeDados())
            {
                return db.Produto.Find(id);
            }
        }
    }
}
