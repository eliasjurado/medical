using Medical.App.Utils;
using Medical.Domain.Dto.Fiscal;
using Medical.Domain.Dto.Response.Concrete;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace Medical.App.Services.FiscalFamilyService;

public class FiscalFamilyService : IFiscalFamilyService
{
    private readonly HttpClient _http;
    private const string BaseURL = "api/FiscalFamily/";
    private readonly NavigationManager _navigationManager;
    private readonly NotificationService _notificationService;
    public FiscalFamilyService(HttpClient http, NavigationManager navigationManager, NotificationService notificationService)
    {
        _http = http;
        _navigationManager = navigationManager;
        _notificationService = notificationService;
    }

    public List<FiscalFamilyDto> FiscalFamilies { get; set; } = new List<FiscalFamilyDto>();
    public List<FiscalFamilyDto> AdminFiscalFamilies { get; set; } = new List<FiscalFamilyDto>();

    public event Action? OnChange;

    public async Task AddFiscalFamily(FiscalFamilyDto item)
    {
        try
        {
            var response = await _http.PostAsJsonAsync($"{BaseURL}admin", item);
            var result = (await response.Content
                .ReadFromJsonAsync<ApiResponse<List<FiscalFamilyDto>>>());

            if (result != null && result.Success)
            {
                AdminFiscalFamilies = result.Data!;

                await GetFiscalFamilies();
                OnChange?.Invoke();
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }

    public FiscalFamilyDto CreateNewFiscalFamily()
    {
        var newFiscalFamilyDto = new FiscalFamilyDto { IsNew = true, Editing = true };
        AdminFiscalFamilies.Add(newFiscalFamilyDto);
        OnChange?.Invoke();
        return newFiscalFamilyDto;
    }

    public async Task DeleteFiscalFamily(int itemId)
    {
        try
        {
            var response = await _http.DeleteAsync($"{BaseURL}admin/{itemId}");

            var result = (await response.Content
               .ReadFromJsonAsync<ApiResponse<List<FiscalFamilyDto>>>());

            if (result != null && result.Success)
            {
                AdminFiscalFamilies = result.Data!;

                await GetFiscalFamilies();
                OnChange?.Invoke();
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }

    public async Task GetAdminFiscalFamilies()
    {
        try
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<List<FiscalFamilyDto>>>($"{BaseURL}admin");
            if (response != null && response.Success)
            {
                AdminFiscalFamilies = response.Data!;
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }

    public async Task GetFiscalFamilies()
    {
        try
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<List<FiscalFamilyDto>>>($"{BaseURL}");

            if (response != null && response.Success)
            {
                FiscalFamilies = response.Data!;
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }           
    }

    public async Task UpdateFiscalFamily(FiscalFamilyDto item)
    {
        try
        {
            var response = await _http.PutAsJsonAsync($"{BaseURL}admin", item);
            var result = (await response.Content
                .ReadFromJsonAsync<ApiResponse<List<FiscalFamilyDto>>>());

            if (result != null && result.Success)
            {
                AdminFiscalFamilies = result.Data!;

                await GetFiscalFamilies();
                OnChange?.Invoke();
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }
}
