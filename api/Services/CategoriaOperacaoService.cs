using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Domain.Entities;
using api.Domain.Repositories;
using api.Domain.Services;
using api.Domain.Services.Communication;

namespace api.Services
{
    public class CategoriaOperacaoService : ICategoriaOperacaoService
    {
        private readonly ICategoriaOperacaoRepository _operacaoCategoriaRepository;
        private readonly IOperacaoRepository _operacaoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoriaOperacaoService(ICategoriaOperacaoRepository operacaoCategoriaRepository, IOperacaoRepository operacaoRepository, IUnitOfWork unitOfWork)
        {
            _operacaoCategoriaRepository = operacaoCategoriaRepository;
            _operacaoRepository = operacaoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CategoriaOperacaoEntity>> ListAsync()
        {
            return await _operacaoCategoriaRepository.ListAsync();
        }

        public async Task<IEnumerable<CategoriaOperacaoMensalEntity>> ListCategoriasGastosAsync(int? mes = null)
        {
            var despesas = await _operacaoRepository.ListDespesasAsync(mes);
            var categorias = from d in despesas
                        group d by d.CategoriaOperacao into c
                        select new CategoriaOperacaoMensalEntity { Categoria = c.Key, TotalGasto = c.Select(c => c.Valor).Sum()};

            return categorias;
        }

        public async Task<SaveCategoriaOperacaoResponse> SaveAsync(CategoriaOperacaoEntity categoria)
        {
            try
            {
                categoria.DataCriacao = DateTime.Now;
                categoria.Status = StatusEnum.Ativo;
                await _operacaoCategoriaRepository.AddAsync(categoria);
                await _unitOfWork.CompleteAsync();
                
                return new SaveCategoriaOperacaoResponse(categoria);
            }
            catch (Exception ex)
            {
                return new SaveCategoriaOperacaoResponse($"An error occurred when saving the category: {ex.Message}");
            }
        }
    }
}