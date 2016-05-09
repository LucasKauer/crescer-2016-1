using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioMegamanNivel3
{
    public class Protoman : Robo
    {
        private bool _morreuUmaVez;

        public Protoman()
        {
            Defesa = 2;
        }
        
        public override void ReceberAtaque(int ataque)
        {
            base.ReceberAtaque(ataque);
            bool podeReviver = this.Vida <= 0 && !_morreuUmaVez;

            if (podeReviver)
            {
                this.Vida = 20;
                this.Ataque = 7;
                _morreuUmaVez = true;
            }
        }
    }
}
