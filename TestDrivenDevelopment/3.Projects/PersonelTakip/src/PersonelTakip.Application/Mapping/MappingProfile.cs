using AutoMapper;
using PersonelTakip.Application.Features.Employees;
using PersonelTakip.Domain.Models;

namespace PersonelTakip.Application.Mapping;
public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateEmployeeCommand, Employee>();
        CreateMap<UpdateEmployeeCommand, Employee>();
    }
}