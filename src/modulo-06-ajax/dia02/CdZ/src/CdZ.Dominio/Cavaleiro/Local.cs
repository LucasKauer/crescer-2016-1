using System;

namespace CdZ.Dominio
{
    public class Local
    {
        public int Id { get; private set; }
        public string Texto { get; set; }

        /*
         * Precisamos deste construtor vazio por causa do Entity Framework.
         */
        private Local() { }

        /// <summary>
        /// Usado na criação.
        /// </summary>
        public Local(string texto)
        {
            Texto = texto;
        }

        /// <summary>
        /// Usado para recuperar do repositório
        /// </summary>
        public Local(int id, string texto)
            : this(texto)
        {
            Id = id;
        }
    }
}
