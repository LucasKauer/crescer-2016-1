using Loja.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTest.Mocks
{
    public class ServicoEmailMock : IServicoEmail
    {
        public void Enviar(IList<Cliente> cliente, string emailRemetente, string titulo, string conteudoEmail)
        {
            // nao faz nada.
        }

        public void Enviar(Cliente cliente, string emailRemetente, string titulo, string conteudoEmail)
        {
            // nao faz nada.
        }
    }
}
