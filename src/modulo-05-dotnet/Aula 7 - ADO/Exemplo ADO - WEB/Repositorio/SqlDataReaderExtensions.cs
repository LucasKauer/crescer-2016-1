using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public static class SqlDataReaderExtensions
    {
        public static int ReadInt(this SqlDataReader leitor, string nomeColuna)
        {
            return Convert.ToInt32(leitor[nomeColuna]);
        }
    }
}
