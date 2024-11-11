using AutoMapper;
using StokTakip.WebAPI.Dtos;
using StokTakip.WebAPI.Models;

namespace StokTakip.WebAPI.Mapping;

public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateProductDto, Product>();
        CreateMap<UpdateProductDto, Product>();
    }
}
