using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaNinja.Repositorio.ADO
{
    public abstract class RepositorioBase
    {
        protected string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["ConexaoLojaNinja"].ConnectionString;
            }
        }
    }
}
