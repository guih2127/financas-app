using System.Collections.Generic;
using System.Threading.Tasks;
using api.Domain.Entities;

namespace api.Domain.Repositories
{
    public interface ICategoriaOperacaoRepository
    {
        Task<IEnumerable<CategoriaOperacaoEntity>> ListAsync();
        Task AddAsync(CategoriaOperacaoEntity categoria);
    }
}