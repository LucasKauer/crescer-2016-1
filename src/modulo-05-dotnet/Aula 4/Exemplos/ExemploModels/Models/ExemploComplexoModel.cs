using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExemploModels.Models
{
    public class ExemploComplexoModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(160)]
        public string Name { get; set; }

        [Required]
        [Range(1, 150, ErrorMessage = "Idade inválida")]
        public int? Idade { get; set; }

        [DisplayName("Data de nascimento")]
        public DateTime DataNascimento { get; set; }

        public decimal Peso { get; set; }

        [DisplayName("Aceita os termos de serviço?")]
        public bool AceitouTermosServico { get; set; }

        [Required(ErrorMessage = "Campo sexo deve ser selecionado")]
        public string Sexo { get; set; }

        [DisplayName("Personagem Favorito?")]
        public int IdPersonagemFavorito { get; set; }
    }
}