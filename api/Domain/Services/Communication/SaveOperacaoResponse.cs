using api.Domain.Entities;

namespace api.Domain.Services.Communication
{
    public class SaveOperacaoResponse : BaseResponse
    {
        public OperacaoEntity Operacao { get; private set; }

        private SaveOperacaoResponse(bool success, string message, OperacaoEntity operacao) : base(success, message)
        {
            Operacao = operacao;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="category">Saved category.</param>
        /// <returns>Response.</returns>
        public SaveOperacaoResponse(OperacaoEntity operacao) : this(true, string.Empty, operacao)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SaveOperacaoResponse(string message) : this(false, message, null)
        { }
    }
}