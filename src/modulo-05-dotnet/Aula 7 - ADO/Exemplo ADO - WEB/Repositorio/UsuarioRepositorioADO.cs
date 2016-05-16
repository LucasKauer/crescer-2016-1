using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class UsuarioRepositorioADO : RepositorioBase, IUsuarioRepositorio
    {
        public Usuario BuscarUsuarioPorAutenticacao(string email, string senha)
        {
            using (var conexao = new SqlConnection(ConnectionString))
            {
                string sql = "SELECT TOP 1 * FROM Usuarios WHERE email = @p_email AND senha = @p_senha";

                var comando = new SqlCommand(sql, conexao);
                comando.Parameters.Add(new SqlParameter("p_email", email));
                comando.Parameters.Add(new SqlParameter("p_senha", senha));

                conexao.Open();

                SqlDataReader leitor = comando.ExecuteReader();

                Usuario usuarioEncontrado = null;

                if(leitor.Read())
                {
                    usuarioEncontrado = new Usuario();
                    usuarioEncontrado.Id = leitor.ReadInt("id");
                    usuarioEncontrado.Email = leitor["email"].ToString();
                    usuarioEncontrado.Nome = leitor["nome"].ToString();
                }

                return usuarioEncontrado;
            }
        }
    }
}
