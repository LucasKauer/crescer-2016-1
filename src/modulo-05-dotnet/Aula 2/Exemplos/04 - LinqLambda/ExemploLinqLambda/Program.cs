using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploLinqLambda
{
    class Program
    {
        static void Main(string[] args)
        {
            var alunos = new List<string>()
            {
                "gustavomelloti",
                 "SadPandaBear",
                 "marcelowarth",
                 "MauricioScherer",
                 "gerlingCalvin",
                 "arthurtcabral",
                 "mpeteffi",
                 "ViniciusAmbrosi",
                 "douglasballester",
                 "hedojunior",
                 "michelfernandes",
                 "LeonMenger",
                 "DaviSpindola",
                 "amatheuslc",
                 "amatheuslc",
                 "amatheuslc",
                 "amatheuslc",
                 "ericoloewe",
                 "DiulyBarreto",
                 "alanastank",
                 "Comette",
                 "AndrewsK30",
                 "FernadoSL",
                 "AliiceAbreu",
                 "ViniciusAudibert",
                 "alycioneto"
            };

            ExemplosLambda(alunos);            
            //ExemplosLinq(alunos);

            var alunosComplexos = new List<Aluno>()
            {
                new Aluno() { Nome = "gustavomelloti", Id = 1 },
                new Aluno() { Nome = "SadPandaBear", Id = 2 },
                new Aluno() { Nome = "marcelowarth", Id = 3 },
                new Aluno() { Nome = "MauricioScherer", Id = 4 },
                new Aluno() { Nome = "gerlingCalvin", Id = 5 },
                new Aluno() { Nome = "arthurtcabral", Id = 6 },
                new Aluno() { Nome = "mpeteffi", Id = 8 },
                new Aluno() { Nome = "ViniciusAmbrosi", Id = 5 },
                new Aluno() { Nome = "douglasballester", Id = 1 },
                new Aluno() { Nome = "hedojunior", Id = 1 },
                new Aluno() { Nome = "michelfernandes", Id = 1 },
                new Aluno() { Nome = "LeonMenger", Id = 80 },
                new Aluno() { Nome = "DaviSpindola", Id = 1 },
                new Aluno() { Nome = "amatheuslc", Id = 1 },
                new Aluno() { Nome = "ericoloewe", Id = 1 },
                new Aluno() { Nome = "DiulyBarreto", Id = 60 },
                new Aluno() { Nome = "alanastank", Id = 1 },
                new Aluno() { Nome = "Comette", Id = 1 },
                new Aluno() { Nome = "AndrewsK30", Id = 2 },
                new Aluno() { Nome = "FernadoSL", Id = 1 },
                new Aluno() { Nome = "AliiceAbreu", Id = 7 },
                new Aluno() { Nome = "ViniciusAudibert", Id = 1 },
                new Aluno() { Nome = "alycioneto", Id = 1 }
            };

            ExemplosLambda(alunosComplexos);

            Console.ReadKey();
        }        

        private static bool VerificaSeTemTNoNome(string nome)
        {
            return nome.Contains("t");
        }

        private static void ExemplosLambda(List<string> alunos)
        {
            //var alunosFiltrados = alunos.Where(VerificaSeTemTNoNome).ToList();
            //ImprimeResultados(alunosFiltrados);

            var alunosFiltrados = alunos.Where(num => num.Contains("ii"));
            ImprimeResultados(alunosFiltrados);

            Console.WriteLine("\n\n");

            var alunosOrdenados = alunos.OrderBy(aluno => aluno);
            ImprimeResultados(alunosOrdenados);

            Console.WriteLine("\n\n");

            var a = alunos.Select(aluno => aluno + " da Silva");
            ImprimeResultados(a);

            
            var anonimo = alunos.Select(aluno => new
            {
                Id = 1,
                NomeDoAluno = aluno
            });

            foreach (var anon in anonimo)
            {
                Console.WriteLine(anon.Id + "   " + anon.NomeDoAluno);
            }

            



            Console.WriteLine("\n\n");

            var agrupados = alunos.GroupBy(aluno => aluno)
                          .Select(g => new { Nome = g.Key, Qtd = g.Count() })
                          .ToList();

            foreach (var agrupado in agrupados)
            {
                Console.WriteLine("Nome: " + agrupado.Nome + " Quantidade: " + agrupado.Qtd);
            }

            Console.WriteLine("\n\n");

            alunos.Reverse(0, alunos.Count); //Void
            alunos.ForEach(aluno => Console.WriteLine(aluno));

            Console.WriteLine("\n\n");

            var c = alunos.ElementAt(2);
            Console.WriteLine(c);

            Console.WriteLine("\n\n");

            Console.WriteLine("Primeiro aluno: " + alunos.FirstOrDefault(x => x == "alycioneto"));
        }

        private static void ExemplosLinq(List<string> alunos)
        {
            //var alunosFiltrados = alunos.Where(aluno => aluno.Contains("ii"));
            var alunosFiltrados = from aluno in alunos
                                  where aluno.Contains("ii")
                                  select aluno;
            ImprimeResultados(alunosFiltrados);

            Console.WriteLine("\n\n");

            //var alunosOrdenados = alunos.OrderBy(aluno => aluno);
            var alunosOrdenados = from aluno in alunos
                                  orderby aluno
                                  select aluno;

            ImprimeResultados(alunosOrdenados);

            //var agrupados = alunos.GroupBy(aluno => aluno)
            //             .Select(g => new { Nome = g.Key, Qtd = g.Count() })
            //             .ToList();

            var agrupados = from aluno in alunos
                            group aluno by aluno into g
                            select new { Nome = g.Key, Qtd = g.Count() };

            foreach (var agrupado in agrupados)
            {
                Console.WriteLine("Nome: " + agrupado.Nome + " Quantidade: " + agrupado.Qtd);
            }
        }

        private static void ExemplosLambda(List<Aluno> alunos)
        {
            var alunosFiltrados = alunos.Where(aluno => aluno.Nome.Contains("ii"));
            ImprimeResultados(alunosFiltrados);

            Console.WriteLine("\n\n");

            var alunosOrdenados = alunos.OrderBy(aluno => aluno.Nome).ThenBy(aluno => aluno.Id);
            ImprimeResultados(alunosOrdenados);

            Console.WriteLine("\n\n");

            var alunosOrdenadosPorId = alunos.OrderBy(aluno => aluno.Id);
            ImprimeResultados(alunosOrdenadosPorId);

            Console.WriteLine("\n\n");

            var anonimo = alunos.Select(aluno => new
            {
                NomeDoAluno = aluno.Nome + " da Silva",
                Idade = aluno.Id + 200
            }).ToList();

            foreach (var anon in anonimo)
            {
                Console.WriteLine(anon.NomeDoAluno + " " + anon.Idade);
            }
        }

        public static void ImprimeResultados(IEnumerable<string> lista)
        {
            foreach (var item in lista)
            {
                Console.WriteLine(item);
            }
        }

        public static void ImprimeResultados(IEnumerable<Aluno> lista)
        {
            foreach (var item in lista)
            {
                Console.WriteLine(item.Nome);
            }
        }
    }
}
