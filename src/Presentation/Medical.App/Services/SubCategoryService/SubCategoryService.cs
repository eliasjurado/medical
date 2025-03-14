using Medical.App.Services.SubCategoryService;
using Medical.App.Utils;
using Medical.Domain.Dto.Response.Concrete;
using Medical.Domain.Dto.Sales;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace Medical.App.Services.SubCategoryService
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly HttpClient _http;
        private const string BaseURL = "api/SubCategory/";
        private readonly NavigationManager _navigationManager;
        private readonly NotificationService _notificationService;
        public SubCategoryService(HttpClient http, NavigationManager navigationManager, NotificationService notificationService)
        {
            _http = http;
            _navigationManager = navigationManager;
            _notificationService = notificationService;
        }

        public List<SubCategoryDto> SubCategories { get; set; } = new List<SubCategoryDto>();
        public List<SubCategoryDto> AdminSubCategories { get; set; } = new List<SubCategoryDto>();

        public event Action? OnChange;

        public async Task AddSubCategory(SubCategoryDto item)
        {
            try
            {
                var response = await _http.PostAsJsonAsync($"{BaseURL}admin", item);
                var result = (await response.Content
                    .ReadFromJsonAsync<ApiResponse<List<SubCategoryDto>>>());

                if (result != null && result.Success)
                {
                    AdminSubCategories = result.Data!;

                    await GetSubCategories();
                    OnChange?.Invoke();
                }
            }
            catch (HttpRequestException ex)
            {
                HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
            }
        }

        public SubCategoryDto CreateNewSubCategory()
        {
            var item = new SubCategoryDto { IsNew = true, Editing = true };
            AdminSubCategories.Add(item);
            OnChange?.Invoke();
            return item;
        }

        public async Task DeleteSubCategory(int itemId)
        {
            try
            {
                var response = await _http.DeleteAsync($"{BaseURL}admin/{itemId}");

                var result = (await response.Content
                   .ReadFromJsonAsync<ApiResponse<List<SubCategoryDto>>>());

                if (result != null && result.Success)
                {
                    AdminSubCategories = result.Data!;

                    await GetSubCategories();
                    OnChange?.Invoke();
                }
            }
            catch (HttpRequestException ex)
            {
                HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
            }
        }

        public async Task GetAdminSubCategories()
        {
            try
            {
                var response = await _http.GetFromJsonAsync<ApiResponse<List<SubCategoryDto>>>($"{BaseURL}admin");
                if (response != null && response.Success)
                {
                    AdminSubCategories = response.Data!;
                }
            }
            catch (HttpRequestException ex)
            {
                HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
            }
        }

        public async Task GetSubCategories()
        {
            try
            {
                var response = await _http.GetFromJsonAsync<ApiResponse<List<SubCategoryDto>>>($"{BaseURL}");

                if (response != null && response.Success)
                {
                    SubCategories = response.Data!;
                }
            }
            catch (HttpRequestException ex)
            {
                HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
            }
        }

        public async Task<SubCategoryDto?> GetSubCategoryByName(string name)
        {
            try
            {
                var response = await _http.GetFromJsonAsync<ApiResponse<SubCategoryDto>>($"{BaseURL}name?name={name}");

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

        public async Task UpdateSubCategory(SubCategoryDto item)
        {
            try
            {
                var response = await _http.PutAsJsonAsync($"{BaseURL}admin", item);
                var result = (await response.Content
                    .ReadFromJsonAsync<ApiResponse<List<SubCategoryDto>>>());

                if (result != null && result.Success)
                {
                    AdminSubCategories = result.Data!;

                    await GetSubCategories();
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
