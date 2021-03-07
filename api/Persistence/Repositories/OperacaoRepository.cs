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

        public async Task<IEnumerable<OperacaoEntity>> ListAsync(int? mes = null)
        {
            var operacoes = await _context.Operacoes
                .Include(o => o.CategoriaOperacao)
                .ToListAsync();

            if (mes != null)
                operacoes = operacoes.Where(r => r.DataCriacao.Month == mes).ToList();
            
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

        public async Task<IEnumerable<OperacaoEntity>> ListReceitasAsync(int? mes = null)
        {
            var operacoes = await _context.Operacoes
                .Include(o => o.CategoriaOperacao)
                .ToListAsync();

            var receitas = operacoes.Where(o => o.TipoOperacao == TipoOperacaoEnum.Receita);

            if (mes != null)
                receitas = receitas.Where(r => r.DataCriacao.Month == mes);

            return receitas.Where(o => o.Status == StatusEnum.Ativo);
        }

        public async Task<IEnumerable<OperacaoEntity>> ListDespesasAsync(int? mes = null)
        {
            var operacoes = await _context.Operacoes
                .Include(o => o.CategoriaOperacao)
                .ToListAsync();
            
            var despesas = operacoes.Where(o => o.TipoOperacao == TipoOperacaoEnum.Despesa);

            if (mes != null)
                despesas = despesas.Where(r => r.DataCriacao.Month == mes);

            return despesas.Where(o => o.Status == StatusEnum.Ativo);
        }
    }
}