using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arquivos
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    var arquivo = @"C:\Users\fabriciosilva\Desktop\arquivos\arquivo.txt";

        //    StreamReader stream = null;
        //    //try
        //    //{
        //    //    stream = new StreamReader(arquivo);

        //    //    string linha;

        //    //    var str = new StringBuilder();
        //    //    do
        //    //    {
        //    //        linha = stream.ReadLine();

        //    //        if (linha != null)
        //    //        {
        //    //            str.Append(linha);
        //    //            str.Append("\n------");
        //    //        }
        //    //    }
        //    //    while (linha != null);

        //    //    Console.WriteLine(str.ToString());
        //    //}
        //    //finally
        //    //{
        //    //    stream.Dispose();
        //    //}

        //    try
        //    {
        //        stream = new StreamReader(arquivo);

        //        var textoCompleto = stream.ReadToEnd();
        //        Console.WriteLine(textoCompleto);
        //    }
        //    finally
        //    {
        //        stream.Dispose();
        //    }
        //}

        //static void Main(string[] args)
        //{
        //    var arquivo = @"C:\Users\fabriciosilva\Desktop\arquivos\arquivo.txt";

        //    //StreamWriter stream = null;
        //    //try {
        //    //    stream = new StreamWriter(arquivo, true);
        //    //    stream.WriteLine("Lorem ipsum dolore sit amet");
        //    //}
        //    //finally
        //    //{
        //    //    stream.Dispose();
        //    //}

        //    using (var stream = new StreamWriter(arquivo, true))
        //    {
        //        stream.WriteLine("Lorem ipsum dolore sit amet");
        //    }
        //}

        static void Main(string[] args)
        {
            var arquivo = @"C:\Users\fabriciosilva\Desktop\arquivos\arquivo.txt";

            var linhas = File.ReadAllLines(arquivo);
            
            File.AppendAllText(arquivo, "TEXTO\nTEXTOOOO\n");

            var texto = File.ReadAllText(arquivo);
        }
    }
}
