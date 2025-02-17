using Medical.Domain.Dto.Fiscal;

namespace Medical.Application.MappingProfıles;

public class FiscalProductProfile : Profile
{
    public FiscalProductProfile()
    {
        CreateMap<FiscalProduct, FiscalProductDto>().ReverseMap();
    }
}
