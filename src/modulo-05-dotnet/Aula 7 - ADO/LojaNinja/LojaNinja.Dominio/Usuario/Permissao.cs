using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaNinja.Dominio
{
    public class Permissao
    {
        public Permissao(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
    }
}
