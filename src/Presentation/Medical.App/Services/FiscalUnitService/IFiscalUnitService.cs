using Medical.Domain.Dto.Fiscal;

namespace Medical.App.Services.FiscalUnitService;

public interface IFiscalUnitService
{
    event Action OnChange;
    List<FiscalUnitDto> FiscalUnits { get; set; }
    List<FiscalUnitDto> AdminFiscalUnits { get; set; }
    Task GetFiscalUnits();
    Task GetAdminFiscalUnits();
    Task AddFiscalUnit(FiscalUnitDto item);
    Task UpdateFiscalUnit(FiscalUnitDto item);
    Task DeleteFiscalUnit(int itemId);
    FiscalUnitDto CreateNewFiscalUnit();
}
