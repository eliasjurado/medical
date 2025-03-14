using Medical.Domain.Dto.Sales;

namespace Medical.App.Services.WarehouseService
{
    public interface IWarehouseService
    {
        event Action OnChange;
        List<WarehouseDto> Warehouses { get; set; }
        List<WarehouseDto> AdminWarehouses { get; set; }
        Task GetWarehouses();
        Task<WarehouseDto?> GetWarehouseByName(string name);
        Task GetAdminWarehouses();
        Task AddWarehouse(WarehouseDto item);
        Task UpdateWarehouse(WarehouseDto item);
        Task DeleteWarehouse(int itemId);
        WarehouseDto CreateNewWarehouse();
    }
}
