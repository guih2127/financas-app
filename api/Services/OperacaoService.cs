using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Domain.Entities;
using api.Domain.Repositories;
using api.Domain.Services;
using api.Domain.Services.Communication;
using api.Models.OperacaoModels;

namespace api.Services
{
    public class OperacaoService : IOperacaoService
    {
        private readonly IOperacaoRepository _operacaoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OperacaoService(IOperacaoRepository operacaoRepository, IUnitOfWork unitOfWork)
        {
            _operacaoRepository = operacaoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<OperacaoEntity>> ListAsync()
        {
            return await _operacaoRepository.ListAsync();
        }

        public async Task<OperacaoEntity> GetByIdAsync(int id)
        {
            return await _operacaoRepository.GetByIdAsync(id);
        }

        public async Task<SaveOperacaoResponse> SaveAsync(OperacaoEntity operacao)
        {
            try
            {
                operacao.DataCriacao = DateTime.Now;
                operacao.Status = StatusEnum.Ativo;

                await _operacaoRepository.AddAsync(operacao);
                await _unitOfWork.CompleteAsync();

                var entidadeOperacao = _operacaoRepository.GetByIdAsync(operacao.Id);
                
                return new SaveOperacaoResponse(entidadeOperacao.Result);
            }
            catch (Exception ex)
            {
                return new SaveOperacaoResponse($"An error occurred when saving the category: {ex.Message}");
            }
        }

        public async Task<OperacaoMensalEntity> ListDespesasAsync(int? mes = null)
        {
            var despesas = await _operacaoRepository.ListDespesasAsync(mes);
            var totalGastos = despesas.Select(d => d.Valor).Sum();

            return new OperacaoMensalEntity { Total = totalGastos, operacoes = despesas };
        }

        public async Task<OperacaoMensalEntity> ListReceitasAsync(int? mes = null)
        {
            var receitas = await _operacaoRepository.ListReceitasAsync(mes);
            var totalGastos = receitas.Select(d => d.Valor).Sum();

            return new OperacaoMensalEntity { Total = totalGastos, operacoes = receitas };
        }
    }
}