using AutoMapper;
using Medical.Domain.Dto.Treatment;
using Medical.Domain.Entities;

namespace Medical.Application.MappingProfıles;

public class TreatmentProfile : Profile
{
    public TreatmentProfile()
    {
        CreateMap<Treatment, TreatmentDto>().ReverseMap();
    }
}
