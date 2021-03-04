using api.Domain.Entities;
using api.Models;
using AutoMapper;

namespace api.Mapping
{
    public class EntityToModelProfile : Profile
    {
        public EntityToModelProfile()
        {
            CreateMap<OperacaoEntity, OperacaoModel>();
            CreateMap<CategoriaOperacaoEntity, CategoriaOperacaoModel>();
        }
    }
}