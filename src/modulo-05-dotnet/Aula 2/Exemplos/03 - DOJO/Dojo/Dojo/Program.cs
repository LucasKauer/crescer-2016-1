using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace Dojo
{
    class Program
    {
        private const string PATH_ARQUIVO = @"C:\Users\fabriciosilva\Desktop\arquivos\frases.csv";

        static void Main(string[] args)
        {
            var arquivoFrases = new ArquivoFrases(PATH_ARQUIVO);

            PedeFraseParaOUsuario(arquivoFrases);
            var frasesEncontradas = PesquisaFrase(arquivoFrases);
            ImprimirFrases(frasesEncontradas);

            Console.ReadKey();
        }

        private static void ImprimirFrases(List<Frase> frasesEncontradas)
        {
            Console.WriteLine("\n\n");

            foreach (var frase in frasesEncontradas)
            {
                Console.WriteLine(frase);
            }
        }

        private static List<Frase> PesquisaFrase(ArquivoFrases arquivoFrases)
        {
            Console.WriteLine("Digite o termo a ser pesquisado: ");
            var termoPesquisa = Console.ReadLine();

            var frases = arquivoFrases.PesquisarPorFrase(termoPesquisa);

            return frases;
        }

        private static void PedeFraseParaOUsuario(ArquivoFrases arquivoFrases)
        {
            Console.WriteLine("Digite uma nova frase:");
            var textoEntrada = Console.ReadLine();
            Console.WriteLine("Digite o autor dessa frase:");
            var autorEntrada = Console.ReadLine();

            var frase = new Frase(textoEntrada, autorEntrada);
            arquivoFrases.AdicionarFrase(frase);
        }
    }
}
