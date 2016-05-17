using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaNinja.Dominio
{
    public class Usuario
    {
        public Usuario(int id, string email, string senha, string nome, IList<Permissao> permissoes)
        {
            this.Id = id;
            this.Email = email;
            this.Senha = senha;
            this.Nome = nome;
            this.Permissoes = permissoes;
        }

        public int Id { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }

        public string Nome { get; private set; }

        public IList<Permissao> Permissoes { get; private set; }
    }
}
