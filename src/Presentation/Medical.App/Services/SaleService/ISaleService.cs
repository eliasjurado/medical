using Medical.Domain.Dto.Sales;

namespace Medical.App.Services.SaleService;

public interface ISaleService
{
    event Action OnChange;
    //List<SaleDto> Sales { get; set; }
    //List<SaleDto> AdminSales { get; set; }
    //Task GetSales();
    //Task<List<SaleDto>> GetSalesByUserId(string user);
    //Task GetAdminSales();
    Task AddSale(SaleDto item);
    //Task UpdateSale(SaleDto item);
    //Task DeleteSale(int itemId);
    //SaleDto CreateNewSale();
}
