using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioMegamanNivel4
{
    public class Rush : Robo, IUpgrade
    {
        public Rush(Chip chip = CHIP_PADRAO) : base(chip)
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

        public override void Atacar(Robo robo)
        {
            if(!(robo is Megaman))
            {
                base.Atacar(robo);
            }
        }
    }
}
