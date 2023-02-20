using API.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(dst => dst.ProductBrand,
                           opt => opt.MapFrom(src => src.ProductBrand.Name))
                .ForMember(dst => dst.ProductType,
                           opt => opt.MapFrom(src => src.ProductType.Name))
                .ForMember(dst => dst.PictureUrl,
                           opt => opt.MapFrom<ProductUrlResolver>());
        }
    }
}