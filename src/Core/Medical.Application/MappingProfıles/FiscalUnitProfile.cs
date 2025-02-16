using Medical.Domain.Dto.FiscalUnit;

namespace Medical.Application.MappingProfıles;

public class FiscalUnitProfile : Profile
{
    public FiscalUnitProfile()
    {
        CreateMap<FiscalUnit, FiscalUnitDto>().ReverseMap();
    }
}
