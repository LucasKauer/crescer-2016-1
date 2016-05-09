using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo
{
    public class Frase
    {
        public string Texto { get; set; }
        public string Autor { get; set; }

        public Frase(string texto, string autor)
        {
            if (texto.ToLower().Contains("potatoes"))
            {
                throw new ArgumentException("Nao pode conter \"potatoes\" na frase");
            }

            this.Texto = texto;
            this.Autor = autor;
        }

        public override string ToString()
        {
            return string.Format("{0}; ({1});\n", Texto, Autor);
        }
    }
}
