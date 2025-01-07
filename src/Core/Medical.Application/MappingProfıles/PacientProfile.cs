using Medical.Domain.Dto.Pacient;

namespace Medical.Application.MappingProfıles;

public class PacientProfile : Profile
{
    public PacientProfile()
    {
        CreateMap<Pacient, PacientDto>().ReverseMap();
    }
}
