using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioMegamanNivel3
{
    public class Rush : Robo, IUpgrade
    {
        public Rush()
        {
            Ataque = 4;
            Defesa = 3;
        }

        public int BonusAtaque
        {
            get
            {
                return this.Ataque + BonusDeAtaquePorUpgrades;
            }
        }

        public int BonusDefesa
        {
            get
            {
                return this.Defesa;
            }
        }

        protected override bool PodeEquiparNovosUpgrades
        {
            get
            {
                return Upgrades.Count < 2;
            }
        }
    }
}
