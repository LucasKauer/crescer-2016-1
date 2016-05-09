using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioMegamanNivel2.Upgrades
{
    public class BotasSuperVelocidade : IUpgrade
    {
        public int BonusAtaque
        {
            get
            {
                return 1;
            }
        }

        public int BonusDefesa
        {
            get
            {
                return 1;
            }
        }
    }
}
