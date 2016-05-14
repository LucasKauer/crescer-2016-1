using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioMegamanNivel1
{
    public abstract class Robo
    {
        public Robo()
        {
            Vida = 100;
        }

        public int Vida { get; protected set; }

        protected virtual int Ataque
        {
            get
            {
                return 5;
            }
        }

        protected virtual int Defesa
        {
            get
            {
                return 0;
            }
        }

        public virtual void Atacar(Robo robo)
        {
            robo.ReceberAtaque(this.Ataque);
        }

        public virtual void ReceberAtaque(int ataque)
        {
            int dano = ataque - this.Defesa;

            if(dano > 0)
            {
                this.Vida -= dano;
            }
        }

        public override string ToString()
        {
            return String.Format("Vida: {0}, Ataque: {1}, Defesa: {2}",
                this.Vida, this.Ataque, this.Defesa);
        }
    }
}
