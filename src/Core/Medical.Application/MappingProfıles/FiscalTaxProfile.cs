using Medical.Domain.Dto.Fiscal;

namespace Medical.Application.MappingProfıles;

public class FiscalTaxProfile : Profile
{
    public FiscalTaxProfile()
    {
        CreateMap<FiscalTaxDto, FiscalTax>().ReverseMap();
    }
}
