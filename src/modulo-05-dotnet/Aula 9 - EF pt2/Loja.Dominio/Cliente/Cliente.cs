using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Dominio
{
    public class Cliente
    {
        private Cliente() { }
        
        public Cliente(string email, string nome, string senha)
        {
            this.Email = email;
            this.Nome = nome;
            this.Senha = senha;
        }

        public Cliente(int id, string email, string nome, string senha) : this(email, nome, senha)
        {
            this.Id = id;
        }

        public int Id { get; private set; }
        public string Email { get; private set; }
        public string Nome { get; private set; }
        public string Senha { get; private set; }
    }
}
