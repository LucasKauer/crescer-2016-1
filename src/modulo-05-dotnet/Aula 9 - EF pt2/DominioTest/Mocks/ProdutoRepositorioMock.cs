using Loja.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTest.Mocks
{
    class ProdutoRepositorioMock : IProdutoRepositorio
    {
        private IList<Produto> _produtos = new List<Produto>();

        public ProdutoRepositorioMock()
        {
            _produtos.Add(new Produto(
                    id: 1,
                    nome: "Espada Magica",
                    valor: 105.90m,
                    quantidadeEstoque: 5
                ));

            _produtos.Add(new Produto(
                    id: 1,
                    nome: "Escudo Magica",
                    valor: 80,
                    quantidadeEstoque: 2
                ));
        }

        public Produto BuscarProdutoPorId(int id)
        {
            return _produtos.FirstOrDefault(p => p.Id == id);
        }
    }
}
