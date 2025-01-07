using Medical.Domain.Dto.Treatment;

namespace Medical.Application.MappingProfıles;

public class TreatmentProfile : Profile
{
    public TreatmentProfile()
    {
        CreateMap<Treatment, TreatmentDto>().ReverseMap();
    }
}
