using ConsoleApplication4.Equipamentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    public abstract class Personagem
    {
        public Personagem(int experiencia)
        {
            Exp = experiencia;

            var e = new Equipamento();
        }

        public Personagem(int experiencia, string nome)
        {
            Nivel = 1;
        }

        public virtual int PoderDeAtaque
        {
            get
            {
                return 2;
            }
        }

        public abstract string Nome { get; }

        public int Exp { get; protected set; }

        protected int Nivel { get; set; }

        public virtual string Falar()
        {
            return "Jiraia";
        }
    }
}
