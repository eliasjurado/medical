using Medical.Domain.Dto.Fiscal;

namespace Medical.Application.MappingProfıles;

public class FiscalUnitProfile : Profile
{
    public FiscalUnitProfile()
    {
        CreateMap<FiscalUnit, FiscalUnitDto>().ReverseMap();
    }
}
