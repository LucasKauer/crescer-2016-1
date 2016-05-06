using ConsoleApplication4.Condecoracoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    public class Elfo : Personagem, IElite
    {
        // JAVA
        //private int flechas;

        //public int getFlechas()
        //{
        //    return flechas;
        //}

        

        public Elfo() : base(10)
        {
            Flechas = 42;
        }
        
        public Elfo(int flechas, int exp, string nomeQueNunca) : base(exp, nomeQueNunca)
        {
            Flechas = flechas;
        }

        public override string Falar()
        {
            return base.Falar();
        }

        public override int PoderDeAtaque
        {
            get
            {
                return base.PoderDeAtaque;
            }
        }


        //public int Flechas
        //{
        //    get;
        //    private set;
        //}

        private int flechas;
        public int Flechas
        {
            get
            {
                if(flechas <= 10)
                {
                    return 20;
                }
                else
                {
                    return flechas;
                }
            }

            private set
            {
                flechas = value;
            }
        }

        public override string Nome
        {
            get
            {
                return "Legolas";
            }
        }

        public int Medalha
        {
            get
            {
                return 1;
            }
        }

        public void AtirarFlecha()
        {
            flechas--;
        }

        public void Demitir(Personagem personagem)
        {
            //...
        }
    }
}
