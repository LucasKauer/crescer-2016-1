using CdZ.Dominio;
using CdZ.MVC.Models.Cavaleiro;

namespace CdZ.MVC.Extensions
{
    public static class LocalExtensions
    {
        /// <summary>
        /// Este método visa fazer o mapeamento dos objetos que estão no banco para aqueles que são enviados ou recebidos pelos AJAX.
        /// Colocamos este método de extensão aqui para não "corromper" a "camada" (sic) do domínio.
        /// </summary>
        public static LocalViewModel FromModel(this Local local)
        {
            return new LocalViewModel
            {
                Id = local.Id,
                Texto = local.Texto
            };
        }
    }
}