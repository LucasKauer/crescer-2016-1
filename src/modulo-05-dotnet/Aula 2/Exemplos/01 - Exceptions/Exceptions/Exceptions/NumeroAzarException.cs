using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class NumeroAzarException : ArgumentException
    {
        public NumeroAzarException(string mensagem) : base(mensagem)
        { }
    }
}
