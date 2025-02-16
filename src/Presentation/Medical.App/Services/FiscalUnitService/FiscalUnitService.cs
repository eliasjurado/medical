using Medical.App.Utils;
using Medical.Domain.Dto.FiscalUnit;
using Medical.Domain.Dto.Response.Concrete;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace Medical.App.Services.FiscalUnitService;

public class FiscalUnitService : IFiscalUnitService
{
    private readonly HttpClient _http;
    private const string BaseURL = "api/FiscalUnit/";
    private readonly NavigationManager _navigationManager;
    private readonly NotificationService _notificationService;
    public FiscalUnitService(HttpClient http, NavigationManager navigationManager, NotificationService notificationService)
    {
        _http = http;
        _navigationManager = navigationManager;
        _notificationService = notificationService;
    }

    public List<FiscalUnitDto> FiscalUnits { get; set; } = new List<FiscalUnitDto>();
    public List<FiscalUnitDto> AdminFiscalUnits { get; set; } = new List<FiscalUnitDto>();

    public event Action? OnChange;

    public async Task AddFiscalUnit(FiscalUnitDto item)
    {
        try
        {
            var response = await _http.PostAsJsonAsync($"{BaseURL}admin", item);
            var result = (await response.Content
                .ReadFromJsonAsync<ApiResponse<List<FiscalUnitDto>>>());

            if (result != null && result.Success)
            {
                AdminFiscalUnits = result.Data!;

                await GetFiscalUnits();
                OnChange?.Invoke();
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }

    public FiscalUnitDto CreateNewFiscalUnit()
    {
        var newFiscalUnitDto = new FiscalUnitDto { IsNew = true, Editing = true };
        AdminFiscalUnits.Add(newFiscalUnitDto);
        OnChange?.Invoke();
        return newFiscalUnitDto;
    }

    public async Task DeleteFiscalUnit(int itemId)
    {
        try
        {
            var response = await _http.DeleteAsync($"{BaseURL}admin/{itemId}");

            var result = (await response.Content
               .ReadFromJsonAsync<ApiResponse<List<FiscalUnitDto>>>());

            if (result != null && result.Success)
            {
                AdminFiscalUnits = result.Data!;

                await GetFiscalUnits();
                OnChange?.Invoke();
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }

    public async Task GetAdminFiscalUnits()
    {
        try
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<List<FiscalUnitDto>>>($"{BaseURL}admin");
            if (response != null && response.Success)
            {
                AdminFiscalUnits = response.Data!;
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }

    public async Task GetFiscalUnits()
    {
        try
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<List<FiscalUnitDto>>>($"{BaseURL}");

            if (response != null && response.Success)
            {
                FiscalUnits = response.Data!;
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }           
    }

    public async Task UpdateFiscalUnit(FiscalUnitDto item)
    {
        try
        {
            var response = await _http.PutAsJsonAsync($"{BaseURL}admin", item);
            var result = (await response.Content
                .ReadFromJsonAsync<ApiResponse<List<FiscalUnitDto>>>());

            if (result != null && result.Success)
            {
                AdminFiscalUnits = result.Data!;

                await GetFiscalUnits();
                OnChange?.Invoke();
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }
}
