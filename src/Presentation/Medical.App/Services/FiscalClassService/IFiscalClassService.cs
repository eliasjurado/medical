using Medical.Domain.Dto.Fiscal;

namespace Medical.App.Services.FiscalClassService;

public interface IFiscalClassService
{
    event Action OnChange;
    List<FiscalClassDto> FiscalClasses { get; set; }
    List<FiscalClassDto> AdminFiscalClasses { get; set; }
    Task GetFiscalClasses();
    Task GetAdminFiscalClasses();
    Task AddFiscalClass(FiscalClassDto item);
    Task UpdateFiscalClass(FiscalClassDto item);
    Task DeleteFiscalClass(int itemId);
    FiscalClassDto CreateNewFiscalClass();
}
