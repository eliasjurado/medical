using Medical.Domain.Dto.User;

namespace Medical.Application.MappingProfıles;

public class AppUserProfile : Profile
{
    public AppUserProfile()
    {
        CreateMap<AppUser, AppUserDto>().ReverseMap();
    }
}
