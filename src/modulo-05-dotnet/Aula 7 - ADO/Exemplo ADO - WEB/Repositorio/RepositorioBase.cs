using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public abstract class RepositorioBase
    {
        public string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["Batata"].ConnectionString;
            }
        }
    }
}
