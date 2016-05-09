using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioMegamanNivel4
{
    public interface IUpgrade
    {
        int BonusAtaque { get; }
        int BonusDefesa { get; }
    }
}
