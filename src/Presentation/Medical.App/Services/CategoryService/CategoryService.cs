using Medical.App.Utils;
using Medical.Domain.Dto.Fiscal;
using Medical.Domain.Dto.Response.Concrete;
using Medical.Domain.Dto.Sales;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace Medical.App.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _http;
        private const string CategoryBaseURL = "api/Category/";
        private readonly NavigationManager _navigationManager;
        private readonly NotificationService _notificationService;
        public CategoryService(HttpClient http, NavigationManager navigationManager, NotificationService notificationService)
        {
            _http = http;
            _navigationManager = navigationManager;
            _notificationService = notificationService;
        }

        public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
        public List<CategoryDto> AdminCategories { get; set; } = new List<CategoryDto>();

        public event Action? OnChange;

        public async Task AddCategory(CategoryDto category)
        {
            try
            {
                var response = await _http.PostAsJsonAsync($"{CategoryBaseURL}admin", category);
                var result = (await response.Content
                    .ReadFromJsonAsync<ApiResponse<List<CategoryDto>>>());

                if (result != null && result.Success)
                {
                    AdminCategories = result.Data!;

                    await GetCategories();
                    OnChange?.Invoke();
                }
            }
            catch (HttpRequestException ex)
            {
                HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
            }
        }

        public CategoryDto CreateNewCategory()
        {
            var newCategoryDto = new CategoryDto { IsNew = true, Editing = true };
            AdminCategories.Add(newCategoryDto);
            OnChange?.Invoke();
            return newCategoryDto;
        }

        public async Task DeleteCategory(int categoryId)
        {
            try
            {
                var response = await _http.DeleteAsync($"{CategoryBaseURL}admin/{categoryId}");

                var result = (await response.Content
                   .ReadFromJsonAsync<ApiResponse<List<CategoryDto>>>());

                if (result != null && result.Success)
                {
                    AdminCategories = result.Data!;

                    await GetCategories();
                    OnChange?.Invoke();
                }
            }
            catch (HttpRequestException ex)
            {
                HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
            }
        }

        public async Task GetAdminCategories()
        {
            try
            {
                var response = await _http.GetFromJsonAsync<ApiResponse<List<CategoryDto>>>($"{CategoryBaseURL}admin");
                if (response != null && response.Success)
                {
                    AdminCategories = response.Data!;
                }
            }
            catch (HttpRequestException ex)
            {
                HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
            }
        }

        public async Task GetCategories()
        {
            try
            {
                var response = await _http.GetFromJsonAsync<ApiResponse<List<CategoryDto>>>($"{CategoryBaseURL}");

                if (response != null && response.Success)
                {
                    Categories = response.Data!;
                }
            }
            catch (HttpRequestException ex)
            {
                HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
            }
        }

        public async Task<CategoryDto?> GetCategoryByName(string name)
        {
            try
            {
                var response = await _http.GetFromJsonAsync<ApiResponse<CategoryDto>>($"{CategoryBaseURL}name?name={name}");

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

        public async Task UpdateCategory(CategoryDto category)
        {
            try
            {
                var response = await _http.PutAsJsonAsync($"{CategoryBaseURL}admin", category);
                var result = (await response.Content
                    .ReadFromJsonAsync<ApiResponse<List<CategoryDto>>>());

                if (result != null && result.Success)
                {
                    AdminCategories = result.Data!;

                    await GetCategories();
                    OnChange?.Invoke();
                }
            }
            catch (HttpRequestException ex)
            {
                HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
            }
        }
    }
}
