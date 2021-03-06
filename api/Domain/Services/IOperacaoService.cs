using System.Collections.Generic;
using System.Threading.Tasks;
using api.Domain.Entities;
using api.Domain.Services.Communication;
using api.Models.OperacaoModels;

namespace api.Domain.Services
{
    public interface IOperacaoService
    {
        Task<IEnumerable<OperacaoEntity>> ListAsync();
        Task<OperacaoMensalEntity> ListDespesasAsync(int? mes = null);
        Task<OperacaoMensalEntity> ListReceitasAsync(int? mes = null);
        Task<OperacaoEntity> GetByIdAsync(int id);
        Task<SaveOperacaoResponse> SaveAsync(OperacaoEntity categoria);
    }
}