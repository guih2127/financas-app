using System.Collections.Generic;
using System.Threading.Tasks;
using api.Domain.Entities;

namespace api.Domain.Repositories
{
    public interface IOperacaoRepository
    {
        Task<IEnumerable<OperacaoEntity>> ListAsync(int? mes = null);
        Task<IEnumerable<OperacaoEntity>> ListReceitasAsync(int? mes = null);
        Task<IEnumerable<OperacaoEntity>> ListDespesasAsync(int? mes = null);
        Task<OperacaoEntity> GetByIdAsync(int id);
        Task AddAsync(OperacaoEntity operacao);
    }
}