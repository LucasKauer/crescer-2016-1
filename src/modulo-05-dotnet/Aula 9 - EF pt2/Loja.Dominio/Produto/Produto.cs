using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Dominio
{
    public class Produto
    {
        private Produto()
        {

        }

        public Produto(string nome, decimal valor, int quantidadeEstoque)
        {
            this.Nome = nome;
            this.Valor = valor;
            this.QuantidadeEstoque = quantidadeEstoque;
        }

        public Produto(int id, string nome, decimal valor, int quantidadeEstoque) : this(nome, valor, quantidadeEstoque)
        {
            this.Id = id;
        }

        public int Id { get; private set; }

        public string Nome { get; private set; }

        public decimal Valor { get; private set; }

        public int QuantidadeEstoque { get; private set; }

        internal void AbaterEstoque(int quantidade)
        {
            this.QuantidadeEstoque -= quantidade;
        }
    }
}
