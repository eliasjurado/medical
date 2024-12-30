using AutoMapper;
using Medical.Domain.Dto.Pacient;
using Medical.Domain.Entities;

namespace Medical.Application.MappingProfıles;

public class PacientProfile : Profile
{
    public PacientProfile()
    {
        CreateMap<Pacient, PacientDto>().ReverseMap();
    }
}
