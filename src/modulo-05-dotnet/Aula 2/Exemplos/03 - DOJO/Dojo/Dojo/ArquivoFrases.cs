using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo
{
    public class ArquivoFrases
    {
        private List<Frase> frases = new List<Frase>();
        private string pathArquivo;

        public ArquivoFrases(string pathArquivo)
        {
            this.pathArquivo = pathArquivo;
            var linhas = File.ReadAllLines(pathArquivo);

            foreach (var linha in linhas)
            {
                var texto = linha.Split(';').First();
                var autor = linha.Split(';').Last();

                frases.Add(new Frase(texto, autor));
            }
        }

        public void AdicionarFrase(Frase frase)
        {
            File.AppendAllText(pathArquivo, frase.ToString());
            frases.Add(frase);
        }

        public List<Frase> PesquisarPorFrase(string termoPesquisa)
        {
            return frases.Where(x => x.Texto.ToLower().Contains(termoPesquisa.ToLower()))
                         .ToList();            
        }
    }
}
