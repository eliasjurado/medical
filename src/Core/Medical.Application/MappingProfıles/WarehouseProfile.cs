using Medical.Domain.Dto.Sales;

namespace Medical.Application.MappingProfıles;

public class WarehouseProfile : Profile
{
    public WarehouseProfile()
    {
        CreateMap<Warehouse, WarehouseDto>().ReverseMap();
    }
}
