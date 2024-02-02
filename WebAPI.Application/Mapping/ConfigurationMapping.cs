using AutoMapper;
using WebAPI.Application.Entities.DTO;
using WebAPI.Domain.Entities;

namespace WebAPI.Application.Mapping
{
    public class ConfigurationMapping : Profile
    {
        public ConfigurationMapping()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Provider, ProviderDTO>().ReverseMap();
        }
    }
}
