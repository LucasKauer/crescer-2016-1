
using LojaNinja.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaNinja.Repositorio.ADO
{
    public class PedidoRepositorioADO : RepositorioBase, IPedidoRepositorio
    {
        public void AtualizarPedido(Pedido pedido)
        {
            using (var conexao = new SqlConnection(ConnectionString))
            {
                string sql =
                    @"UPDATE [dbo].[Pedido]
                           SET [DataPedido] = @p_dataPedido
                              ,[DataEntregaDesejada] = @p_dataEntregaDesejada
                              ,[NomeProduto] = @p_nomeProduto
                              ,[Valor] = @p_valor
                              ,[TipoPagamento] = @p_tipoPagamento
                              ,[NomeCliente] = @p_nomeCliente
                              ,[Cidade] = @p_cidade
                              ,[Estado] = @p_estado
                              ,[PedidoUrgente] = @p_pedidoUrgente
                         WHERE Id = @p_id";

                var comando = new SqlCommand(sql, conexao);
                comando.Parameters.Add(new SqlParameter("p_dataPedido", pedido.DataPedido));
                comando.Parameters.Add(new SqlParameter("p_dataEntregaDesejada", pedido.DataEntregaDesejada));
                comando.Parameters.Add(new SqlParameter("p_nomeProduto", pedido.NomeProduto));
                comando.Parameters.Add(new SqlParameter("p_valor", pedido.Valor));
                comando.Parameters.Add(new SqlParameter("p_tipoPagamento", pedido.TipoPagamento));
                comando.Parameters.Add(new SqlParameter("p_nomeCliente", pedido.NomeCliente));
                comando.Parameters.Add(new SqlParameter("p_cidade", pedido.Cidade));
                comando.Parameters.Add(new SqlParameter("p_estado", pedido.Estado));
                comando.Parameters.Add(new SqlParameter("p_pedidoUrgente", pedido.PedidoUrgente));
                comando.Parameters.Add(new SqlParameter("p_id", pedido.Id));
                
                conexao.Open();
                comando.ExecuteNonQuery();
            }
        }

        public void ExcluirPedido(int id)
        {
            using (var conexao = new SqlConnection(ConnectionString))
            {
                string sql = "DELETE FROM Pedido WHERE Id = @p_id";
                var comando = new SqlCommand(sql, conexao);
                comando.Parameters.Add(new SqlParameter("p_id", id));

                conexao.Open();
                comando.ExecuteNonQuery();
            }
        }

        public void IncluirPedido(Pedido pedido)
        {
            using (var conexao = new SqlConnection(ConnectionString))
            {
                string sql =
                    @"INSERT INTO [dbo].[Pedido]
                            ([DataPedido]
                            ,[DataEntregaDesejada]
                            ,[NomeProduto]
                            ,[Valor]
                            ,[TipoPagamento]
                            ,[NomeCliente]
                            ,[Cidade]
                            ,[Estado]
                            ,[PedidoUrgente])
                        VALUES
                            (@p_dataPedido
                            ,@p_dataEntregaDesejada
                            ,@p_nomeProduto
                            ,@p_valor
                            ,@p_tipoPagamento
                            ,@p_nomeCliente
                            ,@p_cidade
                            ,@p_estado
                            ,@p_pedidoUrgente)";

                var comando = new SqlCommand(sql, conexao);
                comando.Parameters.Add(new SqlParameter("p_dataPedido", pedido.DataPedido));
                comando.Parameters.Add(new SqlParameter("p_dataEntregaDesejada", pedido.DataEntregaDesejada));
                comando.Parameters.Add(new SqlParameter("p_nomeProduto", pedido.NomeProduto));
                comando.Parameters.Add(new SqlParameter("p_valor", pedido.Valor));
                comando.Parameters.Add(new SqlParameter("p_tipoPagamento", pedido.TipoPagamento));
                comando.Parameters.Add(new SqlParameter("p_nomeCliente", pedido.NomeCliente));
                comando.Parameters.Add(new SqlParameter("p_cidade", pedido.Cidade));
                comando.Parameters.Add(new SqlParameter("p_estado", pedido.Estado));
                comando.Parameters.Add(new SqlParameter("p_pedidoUrgente", pedido.PedidoUrgente));

                conexao.Open();
                comando.ExecuteNonQuery();
            }
        }

        public List<Pedido> ObterPedidoPorFiltro(string cliente, string produto)
        {
            using (var conexao = new SqlConnection(ConnectionString))
            {
                SqlCommand comando = conexao.CreateCommand(); // <-- cria um SqlCommand usando a conexao.

                /*
                 * Utilizamos este 1 = 1 quando vamos concatenar
                 * parâmetros de forma condicional.
                 */
                string sql = " SELECT * FROM Pedido WHERE 1 = 1 ";

                if (!String.IsNullOrWhiteSpace(cliente))
                {
                    sql += " AND NomeCliente = @p_nomeCliente ";
                    comando.Parameters.Add(new SqlParameter("p_nomeCliente", cliente));
                }

                if (!String.IsNullOrWhiteSpace(cliente))
                {
                    sql += " AND NomeProduto = @p_nomeProduto ";
                    comando.Parameters.Add(new SqlParameter("p_nomeProduto", produto));
                }

                comando.CommandText = sql;

                conexao.Open();

                return LerPedidosDoBanco(comando);
            }
        }

        public Pedido ObterPedidoPorId(int id)
        {
            using (var conexao = new SqlConnection(ConnectionString))
            {
                string sql = "SELECT * FROM Pedido WHERE Id = @p_id";
                var comando = new SqlCommand(sql, conexao);
                comando.Parameters.Add(new SqlParameter("p_id", id));

                conexao.Open();

                return LerPedidosDoBanco(comando).FirstOrDefault();
            }
        }

        public List<Pedido> ObterPedidos()
        {
            using (var conexao = new SqlConnection(ConnectionString))
            {
                string sql = "SELECT * FROM Pedido";
                var comando = new SqlCommand(sql, conexao);

                conexao.Open();

                return LerPedidosDoBanco(comando);
            }
        }

        private List<Pedido> LerPedidosDoBanco(SqlCommand comando)
        {
            SqlDataReader leitor = comando.ExecuteReader();

            var pedidos = new List<Pedido>();

            while (leitor.Read())
            {
                Pedido pedido = LerPedidoDoBanco(leitor);
                pedidos.Add(pedido);
            }

            leitor.Close();

            return pedidos;
        }

        private Pedido LerPedidoDoBanco(SqlDataReader leitor)
        {
            return new Pedido(
                    id: Convert.ToInt32(leitor["Id"]),
                    dataEntregaDesejada: Convert.ToDateTime(leitor["DataEntregaDesejada"]),
                    cidade: leitor["Cidade"].ToString(),
                    dataPedido: Convert.ToDateTime(leitor["DataPedido"]),
                    estado: leitor["Estado"].ToString(),
                    nomeCliente: leitor["NomeCliente"].ToString(),
                    nomeProduto: leitor["NomeProduto"].ToString(),
                    pedidoUrgente: Convert.ToBoolean(leitor["PedidoUrgente"]),
                    tipoPagamento: (TipoPagamento)Convert.ToInt32(leitor["TipoPagamento"]),
                    valor: Convert.ToDecimal(leitor["Valor"]));
        }
    }
}
