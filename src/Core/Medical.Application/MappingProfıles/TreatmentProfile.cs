using Medical.Domain.Entities;
using Medical.Domain.Dto.Treatment;
using AutoMapper;

namespace Medical.Application.MappingProfıles;

public class TreatmentProfile : Profile
{
    public TreatmentProfile()
    {
        CreateMap<Treatment, TreatmentDto>().ReverseMap();
    }
}
