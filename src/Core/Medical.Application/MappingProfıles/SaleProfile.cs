using Medical.Domain.Dto.Sales;

namespace Medical.Application.MappingProfıles;

public class SaleProfile : Profile
{
    public SaleProfile()
    {
        CreateMap<SaleDto, Sale>().ReverseMap()
            .ForMember(d => d.ClientFullName, o => o.MapFrom(src => src.Client != null ? src.Client.FullName : string.Empty))
            .ForMember(d => d.PacientFullName, o => o.MapFrom(src => src.Pacient != null ? src.Pacient.FullName : string.Empty));
    }
}
