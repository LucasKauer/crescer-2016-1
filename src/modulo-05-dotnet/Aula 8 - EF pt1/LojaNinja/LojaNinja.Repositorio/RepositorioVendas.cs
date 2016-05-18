using LojaNinja.Dominio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace LojaNinja.Repositorio
{
    public class RepositorioVendas
    {
        private readonly string pathArquivo;
        private static readonly object objetoLock = new object();

        public RepositorioVendas()
        {
            pathArquivo = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "bin", "vendas.txt");
        }

        public List<Pedido> ObterPedidos()
        {
            var linhasArquivo = File.ReadAllLines(pathArquivo, Encoding.UTF8).ToList();

            return ConverteLinhasEmPedidos(linhasArquivo);
        }

        public Pedido ObterPedidoPorId(int id)
        {
            return this.ObterPedidos().FirstOrDefault(x => x.Id == id);
        }

        public List<Pedido> ObterPedidoPorFiltro(string cliente, string produto)
        {
            return this.ObterPedidos()
                       .Where(x => (string.IsNullOrEmpty(cliente) || x.NomeCliente.ToLower().Contains(cliente.ToLower())) &&
                                   (string.IsNullOrEmpty(produto) || x.NomeProduto.ToLower() == produto.ToLower()))
                       .ToList();
        }

        public void IncluirPedido(Pedido pedido)
        {
            lock (objetoLock)
            {
                var utlimoId = this.ObterPedidos().Max(x => x.Id);
                var idGerado = utlimoId + 1;
                var novaLinha = Environment.NewLine + ConvertePedidoEmLinhaCSV(pedido, idGerado);

                File.AppendAllText(pathArquivo, novaLinha);

                pedido.AtualizarId(idGerado);
            }
        }

        public void AtualizarPedido(Pedido pedido)
        {
            var pedidos = this.ObterPedidos();

            var indiceASerSubstituido = pedidos.FindIndex(x => x.Id == pedido.Id);
            pedidos[indiceASerSubstituido] = pedido;

            ReescreverArquivo(pedidos);
        }

        public void ExcluirPedido(int id)
        {
            var pedidos = this.ObterPedidos();

            pedidos.RemoveAll(x => x.Id == id);

            ReescreverArquivo(pedidos);
        }

        private void ReescreverArquivo(List<Pedido> pedidos)
        {
            var pedidosConvertidosEmString = pedidos.Select(pedido => ConvertePedidoEmLinhaCSV(pedido));

            lock (objetoLock)
            {
                var stringsConcatenadas = string.Join(Environment.NewLine, pedidosConvertidosEmString);
                File.WriteAllText(pathArquivo, stringsConcatenadas);
            }
        }

        private List<Pedido> ConverteLinhasEmPedidos(List<string> linhasArquivo)
        {
            var listaPedidos = new List<Pedido>();

            //Retirei o cabeçalho do aqruivo para simplificar a lógica de tratamento
            //linhasArquivo.RemoveAt(0);

            foreach (var linha in linhasArquivo)
            {
                var id = Convert.ToInt32(linha.Split(';')[0]);
                var dataPedido = Convert.ToDateTime(linha.Split(';')[1]);
                var dataEntregaDesejada = Convert.ToDateTime(linha.Split(';')[2]);
                var nomeProduto = linha.Split(';')[3];
                var valorVenda = Convert.ToDecimal(linha.Split(';')[4]);
                TipoPagamento tipoPagamento;
                Enum.TryParse(linha.Split(';')[5], out tipoPagamento);
                var nomeCliente = linha.Split(';')[6];
                var cidade = linha.Split(';')[7];
                var estado = linha.Split(';')[8];
                var urgente = Convert.ToBoolean(linha.Split(';')[9]);

                var pedido = new Pedido(id, dataPedido, dataEntregaDesejada, nomeProduto, valorVenda, tipoPagamento, nomeCliente, cidade, estado, urgente);
                listaPedidos.Add(pedido);
            }

            return listaPedidos;
        }

        private string ConvertePedidoEmLinhaCSV(Pedido pedido, int? proximoId = null)
        {
            return string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9}",
                                proximoId.HasValue ? proximoId.Value : pedido.Id,
                                pedido.DataPedido.ToString("dd/MM/yyyy HH:mm"),
                                pedido.DataEntregaDesejada.ToString("dd/MM/yyyy HH:mm"),
                                pedido.NomeProduto,
                                pedido.Valor,
                                pedido.TipoPagamento,
                                pedido.NomeCliente,
                                pedido.Cidade,
                                pedido.Estado,
                                pedido.PedidoUrgente);
        }
    }
}
