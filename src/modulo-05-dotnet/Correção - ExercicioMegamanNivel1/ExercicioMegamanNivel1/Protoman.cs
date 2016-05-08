using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioMegamanNivel1
{
    public class Protoman : Robo
    {
        private bool _morreuUmaVez;

        protected override int Ataque
        {
            get
            {
                return _morreuUmaVez ? 
                            7 : 
                            base.Ataque;
            }
        }

        protected override int Defesa
        {
            get
            {
                return 2;
            }
        }

        public override void ReceberAtaque(int ataque)
        {
            base.ReceberAtaque(ataque);
            bool podeReviver = this.Vida <= 0 && !_morreuUmaVez;

            if (podeReviver)
            {
                this.Vida = 20;
                _morreuUmaVez = true;
            }
        }
    }
}
