using Medical.App.Utils;
using Medical.Domain.Dto.Sales;
using Medical.Domain.Dto.Response.Concrete;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace Medical.App.Services.ArticleService;

public class ArticleService : IArticleService
{
    private readonly HttpClient _http;
    private const string BaseURL = "api/Article/";
    private readonly NavigationManager _navigationManager;
    private readonly NotificationService _notificationService;
    public ArticleService(HttpClient http, NavigationManager navigationManager, NotificationService notificationService)
    {
        _http = http;
        _navigationManager = navigationManager;
        _notificationService = notificationService;
    }

    public List<ArticleDto> Articles { get; set; } = new List<ArticleDto>();
    public List<ArticleDto> AdminArticles { get; set; } = new List<ArticleDto>();

    public event Action? OnChange;

    public async Task AddArticle(ArticleDto item)
    {
        try
        {
            var response = await _http.PostAsJsonAsync($"{BaseURL}admin", item);
            var result = (await response.Content
                .ReadFromJsonAsync<ApiResponse<List<ArticleDto>>>());

            if (result != null && result.Success)
            {
                AdminArticles = result.Data!;

                await GetArticles();
                OnChange?.Invoke();
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }

    public ArticleDto CreateNewArticle()
    {
        var newArticleDto = new ArticleDto { IsNew = true, Editing = true };
        AdminArticles.Add(newArticleDto);
        OnChange?.Invoke();
        return newArticleDto;
    }

    public async Task DeleteArticle(int itemId)
    {
        try
        {
            var response = await _http.DeleteAsync($"{BaseURL}admin/{itemId}");

            var result = (await response.Content
               .ReadFromJsonAsync<ApiResponse<List<ArticleDto>>>());

            if (result != null && result.Success)
            {
                AdminArticles = result.Data!;

                await GetArticles();
                OnChange?.Invoke();
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }

    public async Task GetAdminArticles()
    {
        try
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<List<ArticleDto>>>($"{BaseURL}admin");
            if (response != null && response.Success)
            {
                AdminArticles = response.Data!;
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }

    public async Task GetArticles()
    {
        try
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<List<ArticleDto>>>($"{BaseURL}");

            if (response != null && response.Success)
            {
                Articles = response.Data!;
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }           
    }

    public async Task UpdateArticle(ArticleDto item)
    {
        try
        {
            var response = await _http.PutAsJsonAsync($"{BaseURL}admin", item);
            var result = (await response.Content
                .ReadFromJsonAsync<ApiResponse<List<ArticleDto>>>());

            if (result != null && result.Success)
            {
                AdminArticles = result.Data!;

                await GetArticles();
                OnChange?.Invoke();
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }
}
