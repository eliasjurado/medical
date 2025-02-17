using Medical.Domain.Dto.Fiscal;

namespace Medical.Application.MappingProfıles;

public class FiscalSegmentProfile : Profile
{
    public FiscalSegmentProfile()
    {
        CreateMap<FiscalSegment, FiscalSegmentDto>().ReverseMap();
    }
}
