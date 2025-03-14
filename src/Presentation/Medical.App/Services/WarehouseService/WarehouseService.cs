using Medical.App.Utils;
using Medical.Domain.Dto.Response.Concrete;
using Medical.Domain.Dto.Sales;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace Medical.App.Services.WarehouseService
{
    public class WarehouseService : IWarehouseService
    {
        private readonly HttpClient _http;
        private const string BaseURL = "api/Warehouse/";
        private readonly NavigationManager _navigationManager;
        private readonly NotificationService _notificationService;
        public WarehouseService(HttpClient http, NavigationManager navigationManager, NotificationService notificationService)
        {
            _http = http;
            _navigationManager = navigationManager;
            _notificationService = notificationService;
        }

        public List<WarehouseDto> Warehouses { get; set; } = new List<WarehouseDto>();
        public List<WarehouseDto> AdminWarehouses { get; set; } = new List<WarehouseDto>();

        public event Action? OnChange;

        public async Task AddWarehouse(WarehouseDto item)
        {
            try
            {
                var response = await _http.PostAsJsonAsync($"{BaseURL}admin", item);
                var result = (await response.Content
                    .ReadFromJsonAsync<ApiResponse<List<WarehouseDto>>>());

                if (result != null && result.Success)
                {
                    AdminWarehouses = result.Data!;

                    await GetWarehouses();
                }
            }
            catch (HttpRequestException ex)
            {
                HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
            }
        }

        public WarehouseDto CreateNewWarehouse()
        {
            var itemDto = new WarehouseDto { IsNew = true, Editing = true };
            AdminWarehouses.Add(itemDto);
            OnChange!.Invoke();
            return itemDto;
        }

        public async Task DeleteWarehouse(int itemId)
        {
            try
            {
                var response = await _http.DeleteAsync($"{BaseURL}admin/{itemId}");

                var result = (await response.Content
                   .ReadFromJsonAsync<ApiResponse<List<WarehouseDto>>>());

                if (result != null && result.Success)
                {
                    AdminWarehouses = result.Data!;

                    await GetWarehouses();
                }
            }
            catch (HttpRequestException ex)
            {
                HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
            }
        }

        public async Task GetAdminWarehouses()
        {
            try
            {
                var response = await _http.GetFromJsonAsync<ApiResponse<List<WarehouseDto>>>($"{BaseURL}admin");
                if (response != null && response.Success)
                {
                    AdminWarehouses = response.Data!;
                }
            }
            catch (HttpRequestException ex)
            {
                HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
            }
        }

        public async Task GetWarehouses()
        {
            try
            {
                var response = await _http.GetFromJsonAsync<ApiResponse<List<WarehouseDto>>>($"{BaseURL}");

                if (response != null && response.Success)
                {
                    Warehouses = response.Data!;
                }
            }
            catch (HttpRequestException ex)
            {
                HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
            }            
        }

        public async Task<WarehouseDto?> GetWarehouseByName(string name)
        {
            try
            {
                var response = await _http.GetFromJsonAsync<ApiResponse<WarehouseDto>>($"{BaseURL}name?name={name}");

                if (response != null && response.Success)
                {
                    return response.Data!;
                }                
            }
            catch (HttpRequestException ex)
            {
                HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
            }
            return null;
        }

        public async Task UpdateWarehouse(WarehouseDto item)
        {
            try
            {
                var response = await _http.PutAsJsonAsync($"{BaseURL}admin", item);
                var result = (await response.Content
                    .ReadFromJsonAsync<ApiResponse<List<WarehouseDto>>>());

                if (result != null && result.Success)
                {
                    AdminWarehouses = result.Data!;

                    await GetWarehouses();
                }
            }
            catch (HttpRequestException ex)
            {
                HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
            }            
        }
    }
}
