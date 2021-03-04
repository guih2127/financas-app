using System.Collections.Generic;
using System.Threading.Tasks;
using api.Domain.Entities;

namespace api.Domain.Repositories
{
    public interface IOperacaoRepository
    {
        Task<IEnumerable<OperacaoEntity>> ListAsync();
        Task<IEnumerable<OperacaoEntity>> ListReceitasAsync();
        Task<IEnumerable<OperacaoEntity>> ListDespesasAsync();
        Task<OperacaoEntity> GetByIdAsync(int id);
        Task AddAsync(OperacaoEntity operacao);
    }
}