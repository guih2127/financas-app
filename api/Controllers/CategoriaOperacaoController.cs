using System.Collections.Generic;
using System.Threading.Tasks;
using api.Domain.Entities;
using api.Domain.Services;
using api.Extensions;
using api.Models;
using api.Models.CategoriaOperacaoModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("/api/[controller]")]
    public class CategoriaOperacaoController : Controller
    {
        private readonly ICategoriaOperacaoService _categoriaOperacaoService;
        private readonly IMapper _mapper;
        
        public CategoriaOperacaoController(ICategoriaOperacaoService categoriaOperacaoService, IMapper mapper)
        {
            _categoriaOperacaoService = categoriaOperacaoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoriaOperacaoModel>> GetAllAsync()
        {
            var entidadesCategoria = await _categoriaOperacaoService.ListAsync();
            var categorias = _mapper.Map<IEnumerable<CategoriaOperacaoEntity>, IEnumerable<CategoriaOperacaoModel>>(entidadesCategoria);
            return categorias;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCategoriaOperacaoModel model)
        {
            if (!ModelState.IsValid)
		        return BadRequest(ModelState.GetErrorMessages());

            var categoria = _mapper.Map<SaveCategoriaOperacaoModel, CategoriaOperacaoEntity>(model);
            var result = await _categoriaOperacaoService.SaveAsync(categoria);

            if (result == null)
                return BadRequest();
            
            var categoriaModel = _mapper.Map<CategoriaOperacaoEntity, CategoriaOperacaoModel>(categoria);
            return Ok(categoriaModel);
        }
    }
}