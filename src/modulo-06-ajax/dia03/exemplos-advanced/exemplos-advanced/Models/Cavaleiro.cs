using System.Collections.Generic;

namespace exemplos_advanced.Models
{
    public class Cavaleiro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string[] Golpes { get; set; }

        public static Cavaleiro Obter(int id)
        {
            var cavaleiros = new Dictionary<int, Cavaleiro>()
            {
                { 1,  new Cavaleiro { Id = id, Nome = "Seiya", Golpes = new[] { "Metoro de Pegasus", "Centelha de Pegasus" } } },
                { 2,  new Cavaleiro { Id = id, Nome = "Shiryu", Golpes = new[] { "Cólera do Dragão", "Cólera dos 100 dragões" } } },
            };

            return cavaleiros[id];
        }
    }
}