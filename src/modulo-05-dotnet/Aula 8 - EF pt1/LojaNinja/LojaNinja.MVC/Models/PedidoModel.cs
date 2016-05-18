using LojaNinja.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LojaNinja.MVC.Models
{
    public class PedidoModel
    {
        public int? Id { get; set; }
        [Required]
        public DateTime DataEntrega { get; set; }     
        [Required]
        [DisplayName("Nome do produto")]
        public string NomeProduto { get; set; }
        [Required]
        public decimal Valor { get; set; }
        [Required]
        public TipoPagamento TipoPagamento { get; set; }
        [Required]
        [DisplayName("Nome do cliente")]
        public string NomeCliente { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public string Estado { get; set; }      
    }
}