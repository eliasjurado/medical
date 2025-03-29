using Medical.Domain.Dto.Person;

namespace Medical.Application.MappingProfıles;

public class PacientProfile : Profile
{
    public PacientProfile()
    {
        CreateMap<Pacient, PacientDto>().ReverseMap();
    }
}
