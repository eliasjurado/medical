using Medical.App.Utils;
using Medical.Domain.Dto.Fiscal;
using Medical.Domain.Dto.Response.Concrete;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace Medical.App.Services.FiscalClassService;

public class FiscalClassService : IFiscalClassService
{
    private readonly HttpClient _http;
    private const string BaseURL = "api/FiscalClass/";
    private readonly NavigationManager _navigationManager;
    private readonly NotificationService _notificationService;
    public FiscalClassService(HttpClient http, NavigationManager navigationManager, NotificationService notificationService)
    {
        _http = http;
        _navigationManager = navigationManager;
        _notificationService = notificationService;
    }

    public List<FiscalClassDto> FiscalClasses { get; set; } = new List<FiscalClassDto>();
    public List<FiscalClassDto> AdminFiscalClasses { get; set; } = new List<FiscalClassDto>();

    public event Action? OnChange;

    public async Task AddFiscalClass(FiscalClassDto item)
    {
        try
        {
            var response = await _http.PostAsJsonAsync($"{BaseURL}admin", item);
            var result = (await response.Content
                .ReadFromJsonAsync<ApiResponse<List<FiscalClassDto>>>());

            if (result != null && result.Success)
            {
                AdminFiscalClasses = result.Data!;

                await GetFiscalClasses();
                OnChange?.Invoke();
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }

    public FiscalClassDto CreateNewFiscalClass()
    {
        var newFiscalClassDto = new FiscalClassDto { IsNew = true, Editing = true };
        AdminFiscalClasses.Add(newFiscalClassDto);
        OnChange?.Invoke();
        return newFiscalClassDto;
    }

    public async Task DeleteFiscalClass(int itemId)
    {
        try
        {
            var response = await _http.DeleteAsync($"{BaseURL}admin/{itemId}");

            var result = (await response.Content
               .ReadFromJsonAsync<ApiResponse<List<FiscalClassDto>>>());

            if (result != null && result.Success)
            {
                AdminFiscalClasses = result.Data!;

                await GetFiscalClasses();
                OnChange?.Invoke();
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }

    public async Task GetAdminFiscalClasses()
    {
        try
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<List<FiscalClassDto>>>($"{BaseURL}admin");
            if (response != null && response.Success)
            {
                AdminFiscalClasses = response.Data!;
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }

    public async Task GetFiscalClasses()
    {
        try
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<List<FiscalClassDto>>>($"{BaseURL}");

            if (response != null && response.Success)
            {
                FiscalClasses = response.Data!;
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }           
    }

    public async Task UpdateFiscalClass(FiscalClassDto item)
    {
        try
        {
            var response = await _http.PutAsJsonAsync($"{BaseURL}admin", item);
            var result = (await response.Content
                .ReadFromJsonAsync<ApiResponse<List<FiscalClassDto>>>());

            if (result != null && result.Success)
            {
                AdminFiscalClasses = result.Data!;

                await GetFiscalClasses();
                OnChange?.Invoke();
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }
}
