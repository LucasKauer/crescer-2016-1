using Loja.Dominio;
using Loja.Infraestrutura;
using Loja.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.App
{
    class Program
    {
        static void Main(string[] args)
        {
            IPedidoRepositorio pedidoRepositorio = new PedidoRepositorio();
            IProdutoRepositorio produtoRepositorio = new ProdutoRepositorio();
            IClienteRepositorio clienteRepositorio = new ClienteRepositorio();

            Cliente cliente = clienteRepositorio.BuscarClientePorId(1);

            var pedido = new Pedido(cliente);
            Produto produtoParaAdicionar = produtoRepositorio.BuscarProdutoPorId(1);
            int quantidadeDesejada = 1;

            pedido.AdicionarProduto(produtoParaAdicionar, quantidadeDesejada);

            PedidoServico pedidoServico = 
                ServicoInjecaoDependencia.CriarServicoPedido();

            pedidoServico.FecharPedido(pedido);
        }
    }
}
