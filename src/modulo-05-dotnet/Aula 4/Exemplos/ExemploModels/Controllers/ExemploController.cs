using ExemploModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExemploModels.Controllers
{
    public class ExemploController : Controller
    {
        public ActionResult CadastroSimples()
        {
            return View();
        }

        public ActionResult SalvarCadastroSimples(ExemploSimplesModel model)
        {
            model.Nome = model.Nome + "da Silva";

            return View("Sucesso", model);
        }

        public ActionResult CadastroComplexo()
        {
            PopulaListaDePersonagens();

            return View();
        }

        public ActionResult SalvarCadastroComplexo(ExemploComplexoModel model)
        {
            PopulaListaDePersonagens();

            if (ModelState.IsValid)
            {
                ViewBag.Mensagem = "Item salvo com sucesso!";

                return View("CadastroComplexo", model);
            }
            else
            {
                ModelState.AddModelError("", "Existem erros na sua model. Por favor corrija.");
                return View("CadastroComplexo", model);
            }            
        }

        private void PopulaListaDePersonagens()
        {
            ViewBag.ListaPersonagens = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value = "1",
                    Text = "Vegeta"
                },
                new SelectListItem()
                {
                    Value = "2",
                    Text = "Wolverine"
                }
            };
        }
    }
}