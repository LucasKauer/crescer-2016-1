using Loja.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Infraestrutura
{
    public class ServicoEmail : IServicoEmail
    {
        public void Enviar(IList<Cliente> cliente, string emailRemetente, string titulo, string conteudoEmail)
        {
            throw new NotImplementedException();
        }

        public void Enviar(Cliente cliente, string emailRemetente, string titulo, string conteudoEmail)
        {
            throw new NotImplementedException();
        }
    }
}
