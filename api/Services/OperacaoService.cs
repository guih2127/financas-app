using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Domain.Entities;
using api.Domain.Repositories;
using api.Domain.Services;
using api.Domain.Services.Communication;

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

        public async Task<IEnumerable<OperacaoEntity>> ListDespesasAsync()
        {
            return await _operacaoRepository.ListDespesasAsync();
        }

        public async Task<IEnumerable<OperacaoEntity>> ListReceitasAsync()
        {
            return await _operacaoRepository.ListReceitasAsync();
        }
    }
}