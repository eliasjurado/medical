using Medical.App.Utils;
using Medical.Domain.Dto.Fiscal;
using Medical.Domain.Dto.Response.Concrete;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace Medical.App.Services.FiscalProductService;

public class FiscalProductService : IFiscalProductService
{
    private readonly HttpClient _http;
    private const string BaseURL = "api/FiscalProduct/";
    private readonly NavigationManager _navigationManager;
    private readonly NotificationService _notificationService;
    public FiscalProductService(HttpClient http, NavigationManager navigationManager, NotificationService notificationService)
    {
        _http = http;
        _navigationManager = navigationManager;
        _notificationService = notificationService;
    }

    public List<FiscalProductDto> FiscalProducts { get; set; } = new List<FiscalProductDto>();
    public List<FiscalProductDto> AdminFiscalProducts { get; set; } = new List<FiscalProductDto>();

    public event Action? OnChange;

    public async Task AddFiscalProduct(FiscalProductDto item)
    {
        try
        {
            var response = await _http.PostAsJsonAsync($"{BaseURL}admin", item);
            var result = (await response.Content
                .ReadFromJsonAsync<ApiResponse<List<FiscalProductDto>>>());

            if (result != null && result.Success)
            {
                AdminFiscalProducts = result.Data!;

                await GetFiscalProducts();
                OnChange?.Invoke();
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }

    public FiscalProductDto CreateNewFiscalProduct()
    {
        var newFiscalProductDto = new FiscalProductDto { IsNew = true, Editing = true };
        AdminFiscalProducts.Add(newFiscalProductDto);
        OnChange?.Invoke();
        return newFiscalProductDto;
    }

    public async Task DeleteFiscalProduct(int itemId)
    {
        try
        {
            var response = await _http.DeleteAsync($"{BaseURL}admin/{itemId}");

            var result = (await response.Content
               .ReadFromJsonAsync<ApiResponse<List<FiscalProductDto>>>());

            if (result != null && result.Success)
            {
                AdminFiscalProducts = result.Data!;

                await GetFiscalProducts();
                OnChange?.Invoke();
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }

    public async Task GetAdminFiscalProducts()
    {
        try
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<List<FiscalProductDto>>>($"{BaseURL}admin");
            if (response != null && response.Success)
            {
                AdminFiscalProducts = response.Data!;
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }

    public async Task GetFiscalProducts()
    {
        try
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<List<FiscalProductDto>>>($"{BaseURL}");

            if (response != null && response.Success)
            {
                FiscalProducts = response.Data!;
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }           
    }

    public async Task UpdateFiscalProduct(FiscalProductDto item)
    {
        try
        {
            var response = await _http.PutAsJsonAsync($"{BaseURL}admin", item);
            var result = (await response.Content
                .ReadFromJsonAsync<ApiResponse<List<FiscalProductDto>>>());

            if (result != null && result.Success)
            {
                AdminFiscalProducts = result.Data!;

                await GetFiscalProducts();
                OnChange?.Invoke();
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }
}
