using CdZ.Dominio;
using CdZ.MVC.Models;
using System.Collections.Generic;

namespace CdZ.MVC.Extensions
{
    public static class ImagemExtensions
    {
        /// <summary>
        /// Este método visa fazer o mapeamento dos objetos que estão no banco para aqueles que são enviados ou recebidos pelos AJAX.
        /// Colocamos este método de extensão aqui para não "corromper" a "camada" (sic) do domínio.
        /// </summary>
        public static ImagemViewModel FromModel(this Imagem imagem)
        {
            return new ImagemViewModel
            {
                Id = imagem.Id,
                Url = imagem.Url,
                IsThumb = imagem.IsThumb
            };
        }

        /// <summary>
        /// Este método visa fazer o mapeamento dos objetos que estão no banco para aqueles que são enviados ou recebidos pelos AJAX.
        /// Colocamos este método de extensão aqui para não "corromper" a "camada" (sic) do domínio.
        /// O objetivo é igual ao método de cima, mas para este método fazemos o mapeamento de uma lista de imagens vindas da tabela do banco para a lista retornada por JSON.
        /// </summary>
        public static IList<ImagemViewModel> FromModel(this IEnumerable<Imagem> imagens)
        {
            var imagensViewModel = new List<ImagemViewModel>();

            foreach (var imagem in imagens)
            {
                imagensViewModel.Add(imagem.FromModel());
            }

            return imagensViewModel;
        }
    }
}