using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Domain.Entities;
using api.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace api.Persistence.Repositories
{
    public class OperacaoRepository : BaseRepository, IOperacaoRepository
    {
        public OperacaoRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<OperacaoEntity>> ListAsync()
        {
            var operacoes = await _context.Operacoes
                .Include(o => o.CategoriaOperacao)
                .ToListAsync();
            
            return operacoes.Where(o => o.Status == StatusEnum.Ativo);
        }
    }
}