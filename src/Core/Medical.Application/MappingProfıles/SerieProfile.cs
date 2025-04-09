using Medical.Domain.Dto.Sales;

namespace Medical.Application.MappingProfıles;

public class SerieProfile : Profile
{
    public SerieProfile()
    {
        /*
             public string? SysUserEmail { get; set; }
        public string? SysUserFirstName { get; set; }
        public string? SysUserLastName { get; set; }
         */
        CreateMap<SerieDto, Serie>().ReverseMap()
            .ForMember(d => d.AppUserUserId, o => o.MapFrom(src => src.AppUser != null ? src.AppUser.UserId : string.Empty))
            .ForMember(d => d.AppUserEmail, o => o.MapFrom(src => src.AppUser != null ? src.AppUser.Email : string.Empty))
            .ForMember(d => d.AppUserFirstName, o => o.MapFrom(src => src.AppUser != null ? src.AppUser.FirstName : string.Empty))
            .ForMember(d => d.AppUserLastName, o => o.MapFrom(src => src.AppUser != null ? src.AppUser.LastName : string.Empty))
            .ForMember(d => d.AppUserTypeDocumentId, o => o.MapFrom(src => src.AppUser != null ? src.AppUser.TypeDocumentId : 0))
            .ForMember(d => d.AppUserNumDocument, o => o.MapFrom(src => src.AppUser != null ? src.AppUser.NumDocument : string.Empty))
            .ForMember(d => d.AppUserIsTaxExempted, o => o.MapFrom(src => src.AppUser != null ? src.AppUser.IsTaxExempted : false));
    }
}
