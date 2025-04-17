using Medical.Domain.Dto.Fiscal;

namespace Medical.App.Services.FiscalTaxService;

public interface IFiscalTaxService
{
    event Action OnChange;
    List<FiscalTaxDto> FiscalTaxes { get; set; }
    List<FiscalTaxDto> AdminFiscalTaxes { get; set; }
    Task GetFiscalTaxes();
    Task<FiscalTaxDto?> GetFiscalTaxByYear(int year);
    Task GetAdminFiscalTaxes();
    Task AddFiscalTax(FiscalTaxDto item);
    Task UpdateFiscalTax(FiscalTaxDto item);
    Task DeleteFiscalTax(int itemId);
    FiscalTaxDto CreateNewFiscalTax();
}
