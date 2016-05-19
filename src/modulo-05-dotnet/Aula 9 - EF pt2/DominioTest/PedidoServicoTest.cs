using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Loja.Dominio;
using DominioTest.Mocks;

namespace DominioTest
{
    [TestClass]
    public class PedidoServicoTest
    {
        [TestMethod]
        public void DeveFecharOPedidoEDebitarItensDoEstoque()
        {
            IClienteRepositorio clienteRepositorio = new ClienteRepositorioMock();
            IProdutoRepositorio produtoRepositorio = new ProdutoRepositorioMock();
            IPedidoRepositorio pedidoRepositorio = new PedidoRepositorioMock();
            IServicoEmail servicoEmail = new ServicoEmailMock();

            var pedidoServico = new PedidoServico(pedidoRepositorio,
                                                  servicoEmail);


            Cliente cliente = clienteRepositorio.BuscarClientePorId(1);
            Produto espadaMagica = produtoRepositorio.BuscarProdutoPorId(1);
            Pedido pedido = new Pedido(cliente);
            pedido.AdicionarProduto(espadaMagica, 1);

            int quantidadeAtualDeEstoque = espadaMagica.QuantidadeEstoque;

            pedidoServico.FecharPedido(pedido);

            Assert.AreEqual(4, espadaMagica.QuantidadeEstoque);
        }

        [TestMethod]
        public void AoAdicionarMesmoItemDuasVezesContaComoDoisDoMesmoItem()
        {
            IClienteRepositorio clienteRepositorio = new ClienteRepositorioMock();
            IProdutoRepositorio produtoRepositorio = new ProdutoRepositorioMock();
            IPedidoRepositorio pedidoRepositorio = new PedidoRepositorioMock();
            IServicoEmail servicoEmail = new ServicoEmailMock();

            var pedidoServico = new PedidoServico(pedidoRepositorio,
                                                  servicoEmail);

            Cliente cliente = clienteRepositorio.BuscarClientePorId(1);
            Produto espadaMagica = produtoRepositorio.BuscarProdutoPorId(1);
            Pedido pedido = new Pedido(cliente);

            pedido.AdicionarProduto(espadaMagica, 1);
            pedido.AdicionarProduto(espadaMagica, 1);

            Assert.AreEqual(1, pedido.ItensDoPedido.Count);
            Assert.AreEqual(1, pedido.ItensDoPedido[0].Produto.Id);
            Assert.AreEqual(211.80m, pedido.ValorTotal);
        }
    }
}
