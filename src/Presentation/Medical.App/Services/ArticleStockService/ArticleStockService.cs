using Medical.App.Utils;
using Medical.Domain.Dto.Sales;
using Medical.Domain.Dto.Response.Concrete;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace Medical.App.Services.ArticleStockService;

public class ArticleStockService : IArticleStockService
{
    private readonly HttpClient _http;
    private const string BaseURL = "api/ArticleStock/";
    private readonly NavigationManager _navigationManager;
    private readonly NotificationService _notificationService;
    public ArticleStockService(HttpClient http, NavigationManager navigationManager, NotificationService notificationService)
    {
        _http = http;
        _navigationManager = navigationManager;
        _notificationService = notificationService;
    }

    public List<ArticleStockDto> ArticleStocks { get; set; } = new List<ArticleStockDto>();
    public List<ArticleStockDto> AdminArticleStocks { get; set; } = new List<ArticleStockDto>();

    public event Action? OnChange;

    public async Task AddArticleStock(ArticleStockDto item)
    {
        try
        {
            var response = await _http.PostAsJsonAsync($"{BaseURL}admin", item);
            var result = (await response.Content
                .ReadFromJsonAsync<ApiResponse<List<ArticleStockDto>>>());

            if (result != null && result.Success)
            {
                AdminArticleStocks = result.Data!;

                await GetArticleStocks();
                OnChange?.Invoke();
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }

    public ArticleStockDto CreateNewArticleStock()
    {
        var newArticleStockDto = new ArticleStockDto { IsNew = true, Editing = true };
        AdminArticleStocks.Add(newArticleStockDto);
        OnChange?.Invoke();
        return newArticleStockDto;
    }

    public async Task DeleteArticleStock(int itemId)
    {
        try
        {
            var response = await _http.DeleteAsync($"{BaseURL}admin/{itemId}");

            var result = (await response.Content
               .ReadFromJsonAsync<ApiResponse<List<ArticleStockDto>>>());

            if (result != null && result.Success)
            {
                AdminArticleStocks = result.Data!;

                await GetArticleStocks();
                OnChange?.Invoke();
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }

    public async Task GetAdminArticleStocks()
    {
        try
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<List<ArticleStockDto>>>($"{BaseURL}admin");
            if (response != null && response.Success)
            {
                AdminArticleStocks = response.Data!;
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }

    public async Task GetArticleStocks()
    {
        try
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<List<ArticleStockDto>>>($"{BaseURL}");

            if (response != null && response.Success)
            {
                ArticleStocks = response.Data!;
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }

    public async Task UpdateArticleStock(ArticleStockDto item)
    {
        try
        {
            var response = await _http.PutAsJsonAsync($"{BaseURL}admin", item);
            var result = (await response.Content
                .ReadFromJsonAsync<ApiResponse<List<ArticleStockDto>>>());

            if (result != null && result.Success)
            {
                AdminArticleStocks = result.Data!;

                await GetArticleStocks();
                OnChange?.Invoke();
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }

    public async Task<int> GetStockByArticleId(int itemId)
    {
        int quantity = 0;
        try
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<int>>($"{BaseURL}{itemId}");

            if (response != null && response.Success)
            {
                return response.Data!;
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
        return quantity;
    }
}
