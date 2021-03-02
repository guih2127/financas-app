using api.Domain.Entities;
using AutoMapper;

namespace api.Models
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