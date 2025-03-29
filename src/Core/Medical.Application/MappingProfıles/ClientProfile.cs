using Medical.Domain.Dto.Person;

namespace Medical.Application.MappingProfıles;

public class ClientProfile : Profile
{
    public ClientProfile()
    {
        CreateMap<Client, ClientDto>().ReverseMap();
    }
}
