using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4.Condecoracoes
{
    public interface IElite
    {
        int Medalha { get; }

        void Demitir(Personagem personagem);
    }
}
