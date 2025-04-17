using Medical.App.Utils;
using Medical.Domain.Dto.Fiscal;
using Medical.Domain.Dto.Response.Concrete;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace Medical.App.Services.FiscalTaxService;

public class FiscalTaxService : IFiscalTaxService
{
    private readonly HttpClient _http;
    private const string BaseURL = "api/FiscalTax/";
    private readonly NavigationManager _navigationManager;
    private readonly NotificationService _notificationService;
    public FiscalTaxService(HttpClient http, NavigationManager navigationManager, NotificationService notificationService)
    {
        _http = http;
        _navigationManager = navigationManager;
        _notificationService = notificationService;
    }

    public List<FiscalTaxDto> FiscalTaxes { get; set; } = new List<FiscalTaxDto>();
    public List<FiscalTaxDto> AdminFiscalTaxes { get; set; } = new List<FiscalTaxDto>();

    public event Action? OnChange;

    public async Task AddFiscalTax(FiscalTaxDto item)
    {
        try
        {
            var response = await _http.PostAsJsonAsync($"{BaseURL}admin", item);
            var result = (await response.Content
                .ReadFromJsonAsync<ApiResponse<List<FiscalTaxDto>>>());

            if (result != null && result.Success)
            {
                AdminFiscalTaxes = result.Data!;

                await GetFiscalTaxes();
                OnChange?.Invoke();
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }

    public FiscalTaxDto CreateNewFiscalTax()
    {
        var newFiscalTaxDto = new FiscalTaxDto { IsNew = true, Editing = true };
        AdminFiscalTaxes.Add(newFiscalTaxDto);
        OnChange?.Invoke();
        return newFiscalTaxDto;
    }

    public async Task DeleteFiscalTax(int itemId)
    {
        try
        {
            var response = await _http.DeleteAsync($"{BaseURL}admin/{itemId}");

            var result = (await response.Content
               .ReadFromJsonAsync<ApiResponse<List<FiscalTaxDto>>>());

            if (result != null && result.Success)
            {
                AdminFiscalTaxes = result.Data!;

                await GetFiscalTaxes();
                OnChange?.Invoke();
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }

    public async Task GetAdminFiscalTaxes()
    {
        try
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<List<FiscalTaxDto>>>($"{BaseURL}admin");
            if (response != null && response.Success)
            {
                AdminFiscalTaxes = response.Data!;
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }

    public async Task GetFiscalTaxes()
    {
        try
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<List<FiscalTaxDto>>>($"{BaseURL}");

            if (response != null && response.Success)
            {
                FiscalTaxes = response.Data!;
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }

    public async Task<FiscalTaxDto?> GetFiscalTaxByYear(int year)
    {
        try
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<FiscalTaxDto>>($"{BaseURL}year?year={year}");

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


    public async Task UpdateFiscalTax(FiscalTaxDto item)
    {
        try
        {
            var response = await _http.PutAsJsonAsync($"{BaseURL}admin", item);
            var result = (await response.Content
                .ReadFromJsonAsync<ApiResponse<List<FiscalTaxDto>>>());

            if (result != null && result.Success)
            {
                AdminFiscalTaxes = result.Data!;

                await GetFiscalTaxes();
                OnChange?.Invoke();
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }
}
