using System.Collections.Generic;
using System.Threading.Tasks;
using api.Domain.Entities;
using api.Domain.Services;
using api.Extensions;
using api.Models;
using api.Models.OperacaoModels;
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

        [HttpGet("{id}")]
        public async Task<OperacaoModel> GetByIdAsync(int id)
        {
            var entidadeOperacao = await _operacaoService.GetByIdAsync(id);
            var operacao = _mapper.Map<OperacaoEntity, OperacaoModel>(entidadeOperacao);
            return operacao;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveOperacaoModel model)
        {
            if (!ModelState.IsValid)
		        return BadRequest(ModelState.GetErrorMessages());

            var categoria = _mapper.Map<SaveOperacaoModel, OperacaoEntity>(model);
            var result = await _operacaoService.SaveAsync(categoria);

            if (result == null)
                return BadRequest();
            
            var categoriaModel = _mapper.Map<OperacaoEntity, OperacaoModel>(categoria);
            return Ok(categoriaModel);
        }

        [HttpGet]
        [Route("despesas")]
        public async Task<OperacaoMensalModel> GetAllDespesasAsync()
        {
            var entidadesDespesa = await _operacaoService.ListDespesasAsync();
            var despesas = _mapper.Map<OperacaoMensalEntity, OperacaoMensalModel>(entidadesDespesa);

            return despesas;
        }

        [HttpGet]
        [Route("receitas")]
        public async Task<OperacaoMensalModel> GetAllReceitasAsync([FromQuery] int? mes = null)
        {
            var entidadesReceita = await _operacaoService.ListReceitasAsync(mes);
            var receitas = _mapper.Map<OperacaoMensalEntity, OperacaoMensalModel>(entidadesReceita);

            return receitas;
        }
    }
}