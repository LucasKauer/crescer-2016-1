using LojaNinja.Dominio;
using LojaNinja.MVC.Models;
using LojaNinja.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaNinja.MVC.Controllers
{
    public class PedidoController : Controller
    {
        private RepositorioVendas repositorio = new RepositorioVendas();

        public ActionResult Manter(int? id)
        {
            if (id.HasValue)
            {
                var pedido = repositorio.ObterPedidoPorId(id.Value);

                var model = new PedidoModel()
                {
                    Id = pedido.Id,
                    DataEntrega = pedido.DataEntregaDesejada,
                    NomeCliente = pedido.NomeCliente,
                    Cidade = pedido.Cidade,
                    Estado = pedido.Estado,
                    TipoPagamento = pedido.TipoPagamento,
                    NomeProduto = pedido.NomeProduto,
                    Valor = pedido.Valor
                };

                return View("Manter", model);
            }
            else
            {
                return View("Manter");
            }
        }

        public ActionResult Salvar(PedidoModel model)
        {
            if (model.Estado == "RS" && model.Cidade == "SL")
                ModelState.AddModelError("", "Cidade e Estado inválidos");

            if (ModelState.IsValid)
            {
                try
                {
                    Pedido pedido;
                    if (model.Id.HasValue)
                    {
                        pedido = new Pedido(model.Id.Value, model.DataEntrega, model.NomeProduto, model.Valor, model.TipoPagamento, model.NomeCliente, model.Cidade, model.Estado);
                        repositorio.AtualizarPedido(pedido);
                    }
                    else
                    {
                        pedido = new Pedido(model.DataEntrega, model.NomeProduto, model.Valor, model.TipoPagamento, model.NomeCliente, model.Cidade, model.Estado);
                        repositorio.IncluirPedido(pedido);
                    }

                    ViewBag.MensagemSucesso = "Pedido salvo com sucesso!";
                    return View("Detalhes", pedido);
                }
                catch (ArgumentException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }

            return View("Manter", model);
        }

        public ActionResult Detalhes(int id)
        {
            var pedido = repositorio.ObterPedidoPorId(id);

            return View(pedido);
        }

        public ActionResult Listagem(string cliente, string produto)
        {
            var pedidos = repositorio.ObterPedidoPorFiltro(cliente, produto);

            return View(pedidos);
        }

        public ActionResult Excluir(int id)
        {
            repositorio.ExcluirPedido(id);

            ViewBag.Mensagem = "Pedido excluído!";

            return View("Mensagem");
        }
    }
}