using Medical.Domain.Dto.Specialist;

namespace Medical.Application.MappingProfıles;

public class SpecialistProfile : Profile
{
    public SpecialistProfile()
    {
        CreateMap<Specialist, SpecialistDto>().ReverseMap();
    }
}
