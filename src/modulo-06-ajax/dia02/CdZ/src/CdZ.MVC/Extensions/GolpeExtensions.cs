using CdZ.Dominio;
using CdZ.MVC.Models.Cavaleiro;
using System.Collections.Generic;

namespace CdZ.MVC.Extensions
{
    public static class GolpeExtensions
    {
        /// <summary>
        /// Este método visa fazer o mapeamento dos objetos que estão no banco para aqueles que são enviados ou recebidos pelos AJAX.
        /// Colocamos este método de extensão aqui para não "corromper" a "camada" (sic) do domínio.
        /// </summary>
        public static GolpeViewModel FromModel(this Golpe golpe)
        {
            return new GolpeViewModel
            {
                Id = golpe.Id,
                Nome = golpe.Nome
            };
        }

        /// <summary>
        /// Este método visa fazer o mapeamento dos objetos que estão no banco para aqueles que são enviados ou recebidos pelos AJAX.
        /// Colocamos este método de extensão aqui para não "corromper" a "camada" (sic) do domínio.
        /// O objetivo é igual ao método de cima, mas para este método fazemos o mapeamento de uma lista de golpes vindos da tabela do banco para a lista retornada por JSON.
        /// </summary>
        public static IList<GolpeViewModel> FromModel(this IEnumerable<Golpe> golpes)
        {
            var golpesViewModels = new List<GolpeViewModel>();

            foreach (var golpe in golpes)
            {
                golpesViewModels.Add(golpe.FromModel());
            }

            return golpesViewModels;
        }
    }
}