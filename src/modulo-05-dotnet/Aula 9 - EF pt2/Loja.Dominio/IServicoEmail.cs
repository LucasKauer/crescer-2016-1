using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Dominio
{
    public interface IServicoEmail
    {
        void Enviar(Cliente cliente, string emailRemetente, string titulo, string conteudoEmail);
        void Enviar(IList<Cliente> cliente, string emailRemetente, string titulo, string conteudoEmail);
    }
}
