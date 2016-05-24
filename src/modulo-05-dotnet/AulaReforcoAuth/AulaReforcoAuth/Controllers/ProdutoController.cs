using AulaReforcoAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AulaReforcoAuth.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            var listaProduto = new List<ProdutoModel>();

            listaProduto.Add(new ProdutoModel()
            {
                Id = 1,
                Nome = "Camisa"
            });


            var model = new ProdutoIndexViewModel()
            {
                Titulo = "Ola INDEX",
                Produtos = listaProduto
            };

            return View(model);
        }

        public ActionResult About()
        {
            var listaProduto = new List<ProdutoModel>();

            listaProduto.Add(new ProdutoModel()
            {
                Id = 1,
                Nome = "Camisa"
            });

            return View(listaProduto);
        }

        public ActionResult Pesquisa()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult Buscar()
        {
            var listaProduto = new List<ProdutoModel>();

            listaProduto.Add(new ProdutoModel()
            {
                Id = 1,
                Nome = "Camisa"
            });

            return PartialView("_ListaDeProdutos", listaProduto);
        }
    }
    
}