using Loja.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTest.Mocks
{
    public class ClienteRepositorioMock : IClienteRepositorio
    {
        private IList<Cliente> _clientes = new List<Cliente>();

        public ClienteRepositorioMock()
        {
            _clientes.Add(new Cliente(
                    id: 1,
                    email: "joao@gmail.com",
                    nome: "João Santos",
                    senha: "202cb962ac59075b964b07152d234b70" // 123
                ));
        }

        public Cliente BuscarClientePorId(int id)
        {
            return _clientes.FirstOrDefault(c => c.Id == id);
        }
    }
}
