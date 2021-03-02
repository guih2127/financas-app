using System.Collections.Generic;
using System.Threading.Tasks;
using api.Domain.Entities;
using api.Domain.Services;
using api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("/api/[controller]")]
    public class OperacoesController : Controller
    {
        private readonly IOperacaoService _operacaoService;
        private readonly IMapper _mapper;
        
        public OperacoesController(IOperacaoService operacaoService, IMapper mapper)
        {
            _operacaoService = operacaoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<OperacaoModel>> GetAllAsync()
        {
            var entidadesOperacao = await _operacaoService.ListAsync();
            var operacoes = _mapper.Map<IEnumerable<OperacaoEntity>, IEnumerable<OperacaoModel>>(entidadesOperacao);
            return operacoes;
        }
    }
}