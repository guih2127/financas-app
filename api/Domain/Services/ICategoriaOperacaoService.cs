using System.Collections.Generic;
using System.Threading.Tasks;
using api.Domain.Entities;
using api.Domain.Services.Communication;

namespace api.Domain.Services
{
    public interface ICategoriaOperacaoService
    {
        Task<IEnumerable<CategoriaOperacaoEntity>> ListAsync();
        Task<SaveCategoriaOperacaoResponse> SaveAsync(CategoriaOperacaoEntity categoria);
        Task<IEnumerable<CategoriaOperacaoMensalEntity>> ListCategoriasGastosAsync(int? mes = null);
    }
}