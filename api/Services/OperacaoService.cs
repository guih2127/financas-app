using System.Collections.Generic;
using System.Threading.Tasks;
using api.Domain.Entities;
using api.Domain.Repositories;
using api.Domain.Services;

namespace api.Services
{
    public class OperacaoService : IOperacaoService
    {
        private readonly IOperacaoRepository _operacaoRepository;

        public OperacaoService(IOperacaoRepository operacaoRepository)
        {
            _operacaoRepository = operacaoRepository;
        }

        public async Task<IEnumerable<OperacaoEntity>> ListAsync()
        {
            return await _operacaoRepository.ListAsync();
        }
    }
}