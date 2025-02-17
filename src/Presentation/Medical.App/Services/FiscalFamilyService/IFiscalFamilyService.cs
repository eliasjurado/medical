using Medical.Domain.Dto.Fiscal;

namespace Medical.App.Services.FiscalFamilyService;

public interface IFiscalFamilyService
{
    event Action OnChange;
    List<FiscalFamilyDto> FiscalFamilies { get; set; }
    List<FiscalFamilyDto> AdminFiscalFamilies { get; set; }
    Task GetFiscalFamilies();
    Task GetAdminFiscalFamilies();
    Task AddFiscalFamily(FiscalFamilyDto item);
    Task UpdateFiscalFamily(FiscalFamilyDto item);
    Task DeleteFiscalFamily(int itemId);
    FiscalFamilyDto CreateNewFiscalFamily();
}
