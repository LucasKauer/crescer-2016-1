﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioMegamanNivel3.Upgrades
{
    public class EscudoDeEnergia : IUpgrade
    {
        public int BonusAtaque
        {
            get
            {
                return 0;
            }
        }

        public int BonusDefesa
        {
            get
            {
                return 2;
            }
        }
    }
}