using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Domain.Entities;
using api.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace api.Persistence.Repositories
{
    public class CategoriaOperacaoRepository : BaseRepository, ICategoriaOperacaoRepository
    {
        public CategoriaOperacaoRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<CategoriaOperacaoEntity>> ListAsync()
        {
            var categorias = await _context.OperacaoCategorias.ToListAsync();
            return categorias.Where(o => o.Status == StatusEnum.Ativo);
        }

        public async Task AddAsync(CategoriaOperacaoEntity categoria)
        {
            await _context.OperacaoCategorias.AddAsync(categoria);
        }
    }
}