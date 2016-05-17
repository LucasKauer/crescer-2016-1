
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CrescerADO
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = "' or 1=1 --";
            string senha = "";

            string connectionString = ConfigurationManager.ConnectionStrings["Batata"].ConnectionString;

            using (var conexao = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Usuarios WHERE email=@p_email and senha=@p_senha";

                var comando = new SqlCommand(sql, conexao);
                comando.Parameters.Add(new SqlParameter("p_email", email));
                comando.Parameters.Add(new SqlParameter("p_senha", senha));

                conexao.Open();

                SqlDataReader leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    Console.WriteLine(leitor["email"]);
                }

                //conexao.Close();
            }

            using (TransactionScope scope = new TransactionScope())
            {
                int linhasAfetadas = 0;

                using (var conexao = new SqlConnection(connectionString))
                {
                    try
                    {
                        string sql = "UPDATE Usuarios SET email = @p_email";

                        var comando = new SqlCommand(sql, conexao);
                        comando.Parameters.Add(new SqlParameter("p_email", email));
                        comando.Parameters.Add(new SqlParameter("p_senha", senha));

                        conexao.Open();

                        linhasAfetadas = comando.ExecuteNonQuery();

                        if(linhasAfetadas != 1)
                        {
                            throw new Exception("O update ferrou...");
                        }

                        scope.Complete();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
            



        }
    }
}
