using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Dominio
{
    public enum StatusPedido
    {
        Aberto = 1,
        Processando = 2,
        Fechado = 3,
        Cancelado = 4
    }

    public class Pedido
    {
        private Pedido() : this(null)
        {

        }

        public Pedido(Cliente cliente)
        {
            ItensDoPedido = new List<ItemPedido>();
            DataAbertura = DateTime.Now;
            StatusPedido = StatusPedido.Aberto;
            this.Cliente = cliente;
        }
        
        public int Id { get; private set; }

        public Cliente Cliente { get; private set; }

        public DateTime DataAbertura { get; private set; }

        public DateTime? DataFechamento { get; private set; }

        public StatusPedido StatusPedido { get; private set; }

        public IList<ItemPedido> ItensDoPedido { get; private set; }

        public decimal ValorTotal
        {
            get
            {
                return ItensDoPedido.Sum(i => i.ValorVenda);
            }
        }
        

        public void AdicionarProduto(Produto produto, int quantidadeDesejada)
        {
            if(quantidadeDesejada < 1)
            {
                throw new ArgumentException("Valor inválido para a quantidade.", "quantidadeDesejada");
            }

            var itemPedido = new ItemPedido(produto, quantidadeDesejada);

            AdicionarItemPedido(itemPedido);
        }

        private void AdicionarItemPedido(ItemPedido itemPedido)
        {
            ItemPedido itemDoPedidoComMesmoProduto = PegarItemPedidoJaExisteNosItensAdicionados(itemPedido);

            if(itemDoPedidoComMesmoProduto != null)
            {
                itemDoPedidoComMesmoProduto.IncrementarQuantidadeDesejada(itemPedido.QuantidadeDesejada);
            }
            else
            {
                this.ItensDoPedido.Add(itemPedido);
            }

            if(!itemPedido.TemEstoqueSuficiente)
            {
                throw new ArgumentException("Não há estoque o suficiente para adicionar ao pedido.", "quantidadeDesejada");
            }
        }
        
        internal void FecharPedido()
        {
            DataFechamento = DateTime.Now;
            StatusPedido = StatusPedido.Fechado;

            foreach (ItemPedido item in ItensDoPedido)
            {
                item.AbaterDoEstoque();
            }
        }

        internal void CancelarPedido()
        {
            this.DataFechamento = DateTime.Now;
            this.StatusPedido = StatusPedido.Cancelado;
        }

        private ItemPedido PegarItemPedidoJaExisteNosItensAdicionados(ItemPedido itemPedido)
        {
            return this.ItensDoPedido.FirstOrDefault(i => i.Produto.Id == itemPedido.Produto.Id);
        }
        
    }
}
