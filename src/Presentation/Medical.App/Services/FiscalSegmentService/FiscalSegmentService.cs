using Medical.App.Utils;
using Medical.Domain.Dto.Fiscal;
using Medical.Domain.Dto.Response.Concrete;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace Medical.App.Services.FiscalSegmentService;

public class FiscalSegmentService : IFiscalSegmentService
{
    private readonly HttpClient _http;
    private const string BaseURL = "api/FiscalSegment/";
    private readonly NavigationManager _navigationManager;
    private readonly NotificationService _notificationService;
    public FiscalSegmentService(HttpClient http, NavigationManager navigationManager, NotificationService notificationService)
    {
        _http = http;
        _navigationManager = navigationManager;
        _notificationService = notificationService;
    }

    public List<FiscalSegmentDto> FiscalSegments { get; set; } = new List<FiscalSegmentDto>();
    public List<FiscalSegmentDto> AdminFiscalSegments { get; set; } = new List<FiscalSegmentDto>();

    public event Action? OnChange;

    public async Task AddFiscalSegment(FiscalSegmentDto item)
    {
        try
        {
            var response = await _http.PostAsJsonAsync($"{BaseURL}admin", item);
            var result = (await response.Content
                .ReadFromJsonAsync<ApiResponse<List<FiscalSegmentDto>>>());

            if (result != null && result.Success)
            {
                AdminFiscalSegments = result.Data!;

                await GetFiscalSegments();
                OnChange?.Invoke();
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }

    public FiscalSegmentDto CreateNewFiscalSegment()
    {
        var newFiscalSegmentDto = new FiscalSegmentDto { IsNew = true, Editing = true };
        AdminFiscalSegments.Add(newFiscalSegmentDto);
        OnChange?.Invoke();
        return newFiscalSegmentDto;
    }

    public async Task DeleteFiscalSegment(int itemId)
    {
        try
        {
            var response = await _http.DeleteAsync($"{BaseURL}admin/{itemId}");

            var result = (await response.Content
               .ReadFromJsonAsync<ApiResponse<List<FiscalSegmentDto>>>());

            if (result != null && result.Success)
            {
                AdminFiscalSegments = result.Data!;

                await GetFiscalSegments();
                OnChange?.Invoke();
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }

    public async Task GetAdminFiscalSegments()
    {
        try
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<List<FiscalSegmentDto>>>($"{BaseURL}admin");
            if (response != null && response.Success)
            {
                AdminFiscalSegments = response.Data!;
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }

    public async Task GetFiscalSegments()
    {
        try
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<List<FiscalSegmentDto>>>($"{BaseURL}");

            if (response != null && response.Success)
            {
                FiscalSegments = response.Data!;
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }           
    }

    public async Task UpdateFiscalSegment(FiscalSegmentDto item)
    {
        try
        {
            var response = await _http.PutAsJsonAsync($"{BaseURL}admin", item);
            var result = (await response.Content
                .ReadFromJsonAsync<ApiResponse<List<FiscalSegmentDto>>>());

            if (result != null && result.Success)
            {
                AdminFiscalSegments = result.Data!;

                await GetFiscalSegments();
                OnChange?.Invoke();
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }
}
