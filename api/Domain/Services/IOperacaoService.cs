using System.Collections.Generic;
using System.Threading.Tasks;
using api.Domain.Entities;

namespace api.Domain.Services
{
    public interface IOperacaoService
    {
         Task<IEnumerable<OperacaoEntity>> ListAsync();
    }
}