using Medical.App.Utils;
using Medical.Domain.Dto.Response.Concrete;
using Medical.Domain.Dto.Sales;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace Medical.App.Services.SerieService;

public class SerieService : ISerieService
{
    private readonly HttpClient _http;
    private const string BaseURL = "api/Serie/";
    private readonly NavigationManager _navigationManager;
    private readonly NotificationService _notificationService;
    public SerieService(HttpClient http, NavigationManager navigationManager, NotificationService notificationService)
    {
        _http = http;
        _navigationManager = navigationManager;
        _notificationService = notificationService;
    }

    public List<SerieDto> Series { get; set; } = new List<SerieDto>();
    public List<SerieDto> AdminSeries { get; set; } = new List<SerieDto>();

    public event Action? OnChange;

    public async Task AddSerie(SerieDto item)
    {
        try
        {
            var response = await _http.PostAsJsonAsync($"{BaseURL}admin", item);
            var result = (await response.Content
                .ReadFromJsonAsync<ApiResponse<List<SerieDto>>>());

            if (result != null && result.Success)
            {
                AdminSeries = result.Data!;

                await GetSeries();
                OnChange?.Invoke();
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }

    public SerieDto CreateNewSerie()
    {
        var newSerieDto = new SerieDto { IsNew = true, Editing = true };
        AdminSeries.Add(newSerieDto);
        OnChange?.Invoke();
        return newSerieDto;
    }

    public async Task DeleteSerie(int itemId)
    {
        try
        {
            var response = await _http.DeleteAsync($"{BaseURL}admin/{itemId}");

            var result = (await response.Content
               .ReadFromJsonAsync<ApiResponse<List<SerieDto>>>());

            if (result != null && result.Success)
            {
                AdminSeries = result.Data!;

                await GetSeries();
                OnChange?.Invoke();
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }

    public async Task GetAdminSeries()
    {
        try
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<List<SerieDto>>>($"{BaseURL}admin");
            if (response != null && response.Success)
            {
                AdminSeries = response.Data!;
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }

    public async Task GetSeries()
    {
        try
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<List<SerieDto>>>($"{BaseURL}");

            if (response != null && response.Success)
            {
                Series = response.Data!;
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }

    public async Task<List<SerieDto>> GetSeriesByUserId(string user)
    {
        var list = new List<SerieDto>();
        try
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<List<SerieDto>>>($"{BaseURL}user?user={user}");

            if (response != null && response.Success && response.Data != null)
            {
                list = response.Data!;
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
        return list;
    }

    public async Task UpdateSerie(SerieDto item)
    {
        try
        {
            var response = await _http.PutAsJsonAsync($"{BaseURL}admin", item);
            var result = (await response.Content
                .ReadFromJsonAsync<ApiResponse<List<SerieDto>>>());

            if (result != null && result.Success)
            {
                AdminSeries = result.Data!;

                await GetSeries();
                OnChange?.Invoke();
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }
}
