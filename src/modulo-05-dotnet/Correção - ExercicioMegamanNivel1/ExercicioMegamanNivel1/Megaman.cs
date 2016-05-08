using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioMegamanNivel1
{
    public class Megaman : Robo
    {
        protected override int Ataque
        {
            get
            {
                return 6;
            }
        }

        public override void Atacar(Robo robo)
        {
            int ataqueFinal = this.Vida < 30 ? 
                                this.Ataque + 3 : 
                                this.Ataque;

            robo.ReceberAtaque(ataqueFinal);
        }
    }
}
