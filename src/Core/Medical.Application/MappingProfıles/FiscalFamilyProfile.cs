using Medical.Domain.Dto.Fiscal;

namespace Medical.Application.MappingProfıles;

public class FiscalFamilyProfile : Profile
{
    public FiscalFamilyProfile()
    {
        CreateMap<FiscalFamily, FiscalFamilyDto>().ReverseMap();
    }
}
