using System.Collections.Generic;
using System.Threading.Tasks;
using api.Domain.Entities;

namespace api.Domain.Repositories
{
    public interface IOperacaoRepository
    {
        Task<IEnumerable<OperacaoEntity>> ListAsync();
    }
}