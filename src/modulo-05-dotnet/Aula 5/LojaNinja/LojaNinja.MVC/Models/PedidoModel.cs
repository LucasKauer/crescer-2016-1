using LojaNinja.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LojaNinja.MVC.Models
{
    public class PedidoModel
    {
        public DateTime DataEntrega { get; set; }        
        public string NomeProduto { get; set; }
        public decimal Valor { get; set; }
        public TipoPagamento TipoPagamento { get; set; }
        public string NomeCliente { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }      
    }
}