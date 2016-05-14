using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioMegamanNivel4
{
    public class Megaman : Robo
    {
        public Megaman(Chip chip = CHIP_PADRAO) : base(chip)
        {
            Ataque = 6;
        }
        

        public override void Atacar(Robo robo)
        {
            int ataqueFinal = this.Vida < 30 ? 
                                this.Ataque + 3 : 
                                this.Ataque;

            ataqueFinal += BonusDeAtaquePorUpgrades;

            robo.ReceberAtaque(ataqueFinal);
        }
    }
}
