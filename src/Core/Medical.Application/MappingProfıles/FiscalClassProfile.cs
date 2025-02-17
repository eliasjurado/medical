using Medical.Domain.Dto.Fiscal;

namespace Medical.Application.MappingProfıles;

public class FiscalClassProfile : Profile
{
    public FiscalClassProfile()
    {
        CreateMap<FiscalClass, FiscalClassDto>().ReverseMap();
    }
}
