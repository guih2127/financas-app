using api.Domain.Entities;

namespace api.Domain.Services.Communication
{
    public class SaveCategoriaOperacaoResponse : BaseResponse
    {
        public CategoriaOperacaoEntity Categoria { get; private set; }

        private SaveCategoriaOperacaoResponse(bool success, string message, CategoriaOperacaoEntity categoria) : base(success, message)
        {
            Categoria = categoria;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="category">Saved category.</param>
        /// <returns>Response.</returns>
        public SaveCategoriaOperacaoResponse(CategoriaOperacaoEntity category) : this(true, string.Empty, category)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SaveCategoriaOperacaoResponse(string message) : this(false, message, null)
        { }
    }
}