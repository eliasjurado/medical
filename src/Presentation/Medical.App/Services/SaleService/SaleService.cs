using Medical.App.Utils;
using Medical.Domain.Dto.Response.Concrete;
using Medical.Domain.Dto.Sales;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace Medical.App.Services.SaleService;

public class SaleService : ISaleService
{
    private readonly HttpClient _http;
    private const string BaseURL = "api/Sale/";
    private readonly NavigationManager _navigationManager;
    private readonly NotificationService _notificationService;
    public SaleService(HttpClient http, NavigationManager navigationManager, NotificationService notificationService)
    {
        _http = http;
        _navigationManager = navigationManager;
        _notificationService = notificationService;
    }

    public List<SaleDto> Sales { get; set; } = new List<SaleDto>();
    public List<SaleDto> AdminSales { get; set; } = new List<SaleDto>();

    public event Action? OnChange;

    public async Task AddSale(SaleDto item)
    {
        try
        {
            var response = await _http.PostAsJsonAsync($"{BaseURL}admin", item);
            var result = (await response.Content
                .ReadFromJsonAsync<ApiResponse<List<SaleDto>>>());

            if (result != null && result.Success)
            {
                AdminSales = result.Data!;

                await GetSales();
                OnChange?.Invoke();
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }

    //public SaleDto CreateNewSale()
    //{
    //    var newSaleDto = new SaleDto { IsNew = true, Editing = true };
    //    AdminSales.Add(newSaleDto);
    //    OnChange?.Invoke();
    //    return newSaleDto;
    //}

    //public async Task DeleteSale(int itemId)
    //{
    //    try
    //    {
    //        var response = await _http.DeleteAsync($"{BaseURL}admin/{itemId}");

    //        var result = (await response.Content
    //           .ReadFromJsonAsync<ApiResponse<List<SaleDto>>>());

    //        if (result != null && result.Success)
    //        {
    //            AdminSales = result.Data!;

    //            await GetSales();
    //            OnChange?.Invoke();
    //        }
    //    }
    //    catch (HttpRequestException ex)
    //    {
    //        HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
    //    }
    //}

    public async Task GetAdminSales()
    {
        try
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<List<SaleDto>>>($"{BaseURL}admin");
            if (response != null && response.Success)
            {
                AdminSales = response.Data!;
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }

    public async Task GetSales()
    {
        try
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<List<SaleDto>>>($"{BaseURL}");

            if (response != null && response.Success)
            {
                Sales = response.Data!;
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }

    //public async Task<List<SaleDto>> GetSalesByUserId(string user)
    //{
    //    var list = new List<SaleDto>();
    //    try
    //    {
    //        var response = await _http.GetFromJsonAsync<ApiResponse<List<SaleDto>>>($"{BaseURL}user?user={user}");

    //        if (response != null && response.Success && response.Data != null)
    //        {
    //            list = response.Data!;
    //        }
    //    }
    //    catch (HttpRequestException ex)
    //    {
    //        HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
    //    }
    //    return list;
    //}

    //public async Task UpdateSale(SaleDto item)
    //{
    //    try
    //    {
    //        var response = await _http.PutAsJsonAsync($"{BaseURL}admin", item);
    //        var result = (await response.Content
    //            .ReadFromJsonAsync<ApiResponse<List<SaleDto>>>());

    //        if (result != null && result.Success)
    //        {
    //            AdminSales = result.Data!;

    //            await GetSales();
    //            OnChange?.Invoke();
    //        }
    //    }
    //    catch (HttpRequestException ex)
    //    {
    //        HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
    //    }
    //}
}
