using api.Domain.Entities;
using api.Models;
using api.Models.CategoriaOperacaoModels;
using api.Models.OperacaoModels;
using AutoMapper;

namespace api.Mapping
{
    public class EntityToModelProfile : Profile
    {
        public EntityToModelProfile()
        {
            CreateMap<OperacaoEntity, OperacaoModel>();
            CreateMap<CategoriaOperacaoEntity, CategoriaOperacaoModel>();
            CreateMap<OperacaoMensalEntity, OperacaoMensalModel>();
            CreateMap<CategoriaOperacaoMensalEntity, CategoriaOperacaoMensalModel>();
        }
    }
}