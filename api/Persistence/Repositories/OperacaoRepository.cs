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

        public async Task<OperacaoEntity> GetByIdAsync(int id)
        {
            var operacao = await _context.Operacoes
                .Include(o => o.CategoriaOperacao)
                .OrderBy(o => o.Id)
                .FirstOrDefaultAsync();

            return operacao;
        }

        public async Task AddAsync(OperacaoEntity operacao)
        {
            await _context.Operacoes.AddAsync(operacao);
        }

        public async Task<IEnumerable<OperacaoEntity>> ListReceitasAsync()
        {
            var operacoes = await _context.Operacoes
                .Include(o => o.CategoriaOperacao)
                .ToListAsync();

            var receitas = operacoes.Where(o => o.TipoOperacao == TipoOperacaoEnum.Receita);
            return receitas.Where(o => o.Status == StatusEnum.Ativo);
        }

        public async Task<IEnumerable<OperacaoEntity>> ListDespesasAsync()
        {
            var operacoes = await _context.Operacoes
                .Include(o => o.CategoriaOperacao)
                .ToListAsync();
            
            var despesas = operacoes.Where(o => o.TipoOperacao == TipoOperacaoEnum.Despesa);
            return despesas.Where(o => o.Status == StatusEnum.Ativo);
        }
    }
}