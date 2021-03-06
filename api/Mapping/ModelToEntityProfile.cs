using api.Domain.Entities;
using api.Models.CategoriaOperacaoModels;
using api.Models.OperacaoModels;
using AutoMapper;

namespace api.Models
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<SaveCategoriaOperacaoModel, CategoriaOperacaoEntity>();
            CreateMap<SaveOperacaoModel, OperacaoEntity>();
            CreateMap<OperacaoMensalModel, OperacaoMensalEntity>();
        }
    }
}