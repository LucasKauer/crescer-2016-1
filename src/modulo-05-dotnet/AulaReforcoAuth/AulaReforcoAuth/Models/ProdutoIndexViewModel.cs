using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AulaReforcoAuth.Models
{
    public class ProdutoIndexViewModel
    {
        public string Titulo { get; set; }
        public List<ProdutoModel> Produtos { get; set; }
    }
}