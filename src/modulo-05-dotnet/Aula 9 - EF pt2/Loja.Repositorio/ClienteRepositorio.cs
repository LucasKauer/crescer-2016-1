using Loja.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        public Cliente BuscarClientePorId(int id)
        {
            using (var db = new ContextoDeDados())
            {
                return db.Cliente.Find(id);
            }
        }
    }
}
