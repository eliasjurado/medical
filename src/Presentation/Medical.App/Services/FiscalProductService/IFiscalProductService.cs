using Medical.Domain.Dto.Fiscal;

namespace Medical.App.Services.FiscalProductService;

public interface IFiscalProductService
{
    event Action OnChange;
    List<FiscalProductDto> FiscalProducts { get; set; }
    List<FiscalProductDto> AdminFiscalProducts { get; set; }
    Task GetFiscalProducts();
    Task GetAdminFiscalProducts();
    Task AddFiscalProduct(FiscalProductDto item);
    Task UpdateFiscalProduct(FiscalProductDto item);
    Task DeleteFiscalProduct(int itemId);
    FiscalProductDto CreateNewFiscalProduct();
}
