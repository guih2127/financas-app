using System.Collections.Generic;
using System.Threading.Tasks;
using api.Domain.Entities;
using api.Domain.Services.Communication;

namespace api.Domain.Services
{
    public interface IOperacaoService
    {
        Task<IEnumerable<OperacaoEntity>> ListAsync();
        Task<IEnumerable<OperacaoEntity>> ListDespesasAsync();
        Task<IEnumerable<OperacaoEntity>> ListReceitasAsync();
        Task<OperacaoEntity> GetByIdAsync(int id);
        Task<SaveOperacaoResponse> SaveAsync(OperacaoEntity categoria);
    }
}