using AutoMapper;
using Medical.Domain.Dto.Specialist;
using Medical.Domain.Entities;

namespace Medical.Application.MappingProfıles;

public class SpecialistProfile : Profile
{
    public SpecialistProfile()
    {
        CreateMap<Specialist, SpecialistDto>().ReverseMap();
    }
}
