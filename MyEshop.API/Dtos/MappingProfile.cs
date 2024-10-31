using AutoMapper;
using MyEshop.Core.Entities;

namespace MyEshop.API.Dtos;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
    }
}