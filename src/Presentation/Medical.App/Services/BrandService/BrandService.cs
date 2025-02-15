using Medical.App.Utils;
using Medical.Domain.Dto.Brand;
using Medical.Domain.Dto.Response.Concrete;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace Medical.App.Services.BrandService;

public class BrandService : IBrandService
{
    private readonly HttpClient _http;
    private const string BaseURL = "api/Brand/";
    private readonly NavigationManager _navigationManager;
    private readonly NotificationService _notificationService;
    public BrandService(HttpClient http, NavigationManager navigationManager, NotificationService notificationService)
    {
        _http = http;
        _navigationManager = navigationManager;
        _notificationService = notificationService;
    }

    public List<BrandDto> Brands { get; set; } = new List<BrandDto>();
    public List<BrandDto> AdminBrands { get; set; } = new List<BrandDto>();

    public event Action? OnChange;

    public async Task AddBrand(BrandDto item)
    {
        try
        {
            var response = await _http.PostAsJsonAsync($"{BaseURL}admin", item);
            var result = (await response.Content
                .ReadFromJsonAsync<ApiResponse<List<BrandDto>>>());

            if (result != null && result.Success)
            {
                AdminBrands = result.Data!;

                await GetBrands();
                OnChange?.Invoke();
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }

    public BrandDto CreateNewBrand()
    {
        var newBrandDto = new BrandDto { IsNew = true, Editing = true };
        AdminBrands.Add(newBrandDto);
        OnChange?.Invoke();
        return newBrandDto;
    }

    public async Task DeleteBrand(int itemId)
    {
        try
        {
            var response = await _http.DeleteAsync($"{BaseURL}admin/{itemId}");

            var result = (await response.Content
               .ReadFromJsonAsync<ApiResponse<List<BrandDto>>>());

            if (result != null && result.Success)
            {
                AdminBrands = result.Data!;

                await GetBrands();
                OnChange?.Invoke();
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }

    public async Task GetAdminBrands()
    {
        try
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<List<BrandDto>>>($"{BaseURL}admin");
            if (response != null && response.Success)
            {
                AdminBrands = response.Data!;
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }

    public async Task GetBrands()
    {
        try
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<List<BrandDto>>>($"{BaseURL}");

            if (response != null && response.Success)
            {
                Brands = response.Data!;
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }           
    }

    public async Task UpdateBrand(BrandDto Brand)
    {
        try
        {
            var response = await _http.PutAsJsonAsync($"{BaseURL}admin", Brand);
            var result = (await response.Content
                .ReadFromJsonAsync<ApiResponse<List<BrandDto>>>());

            if (result != null && result.Success)
            {
                AdminBrands = result.Data!;

                await GetBrands();
                OnChange?.Invoke();
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }
}
