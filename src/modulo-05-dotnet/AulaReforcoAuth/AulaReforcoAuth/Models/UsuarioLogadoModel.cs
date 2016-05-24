using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AulaReforcoAuth.Models
{
    public class UsuarioLogadoModel
    {
        public UsuarioLogadoModel()
        {
            Permissoes = new string[0];
        }

        public string Nome { get; set; }

        public string[] Permissoes { get; set; }
    }
}