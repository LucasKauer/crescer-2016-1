using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Dominio
{
    public class ItemPedido
    {
        private ItemPedido() { }

        public ItemPedido(Produto produto, int quantidade)
        {
            this.QuantidadeDesejada = quantidade;
            this.Produto = produto;
            this.ValorDoProdutoNaVenda = produto.Valor;
        }

        public decimal ValorDoProdutoNaVenda { get; private set; }

        public int Id { get; private set; }

        public decimal ValorVenda
        {
            get
            {
                return ValorDoProdutoNaVenda * QuantidadeDesejada;
            }
        }
        
        public int QuantidadeDesejada { get; private set; }

        public Produto Produto { get; private set; }

        public bool TemEstoqueSuficiente
        {
            get
            {
                return this.QuantidadeDesejada <= Produto.QuantidadeEstoque;
            }
        }

        internal void AbaterDoEstoque()
        {
            this.Produto.AbaterEstoque(QuantidadeDesejada);
        }

        internal void IncrementarQuantidadeDesejada(int quantidadeDesejada)
        {
            this.QuantidadeDesejada += quantidadeDesejada;
        }
    }
}
