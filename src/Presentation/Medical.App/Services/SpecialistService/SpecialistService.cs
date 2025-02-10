using Medical.App.Utils;
using Medical.Domain.Dto.Response.Concrete;
using Medical.Domain.Dto.Specialist;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace Medical.App.Services.SpecialistService
{
    public class SpecialistService : ISpecialistService
    {
        private readonly HttpClient _http;
        private const string CategoryBaseURL = "api/Specialist/";
        private readonly NavigationManager _navigationManager;
        private readonly NotificationService _notificationService;
        public SpecialistService(HttpClient http, NavigationManager navigationManager, NotificationService notificationService)
        {
            _http = http;
            _navigationManager = navigationManager;
            _notificationService = notificationService;
        }

        public List<SpecialistDto> Specialists { get; set; } = new List<SpecialistDto>();
        public List<SpecialistDto> AdminSpecialists { get; set; } = new List<SpecialistDto>();

        public event Action? OnChange;

        public async Task AddSpecialist(SpecialistDto specialist)
        {
            try
            {
                var response = await _http.PostAsJsonAsync($"{CategoryBaseURL}admin", specialist);
                var result = (await response.Content
                    .ReadFromJsonAsync<ApiResponse<List<SpecialistDto>>>());

                if (result != null && result.Success)
                {
                    AdminSpecialists = result.Data!;

                    await GetSpecialists();
                }
            }
            catch (HttpRequestException ex)
            {
                HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
            }
        }

        public SpecialistDto CreateNewSpecialist()
        {
            var newSpecialistDto = new SpecialistDto { IsNew = true, Editing = true };
            AdminSpecialists.Add(newSpecialistDto);
            OnChange!.Invoke();
            return newSpecialistDto;
        }

        public async Task DeleteSpecialist(int specialistId)
        {
            try
            {
                var response = await _http.DeleteAsync($"{CategoryBaseURL}admin/{specialistId}");

                var result = (await response.Content
                   .ReadFromJsonAsync<ApiResponse<List<SpecialistDto>>>());

                if (result != null && result.Success)
                {
                    AdminSpecialists = result.Data!;

                    await GetSpecialists();
                }
            }
            catch (HttpRequestException ex)
            {
                HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
            }
        }

        public async Task GetAdminSpecialists()
        {
            try
            {
                var response = await _http.GetFromJsonAsync<ApiResponse<List<SpecialistDto>>>($"{CategoryBaseURL}admin");
                if (response != null && response.Success)
                {
                    AdminSpecialists = response.Data!;
                }
            }
            catch (HttpRequestException ex)
            {
                HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
            }
        }

        public async Task GetSpecialists()
        {
            try
            {
                var response = await _http.GetFromJsonAsync<ApiResponse<List<SpecialistDto>>>($"{CategoryBaseURL}");

                if (response != null && response.Success)
                {
                    Specialists = response.Data!;
                }
            }
            catch (HttpRequestException ex)
            {
                HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
            }           
        }

        public async Task<SpecialistDto?> GetSpecialistByFullName(string fullName)
        {
            try
            {
                var response = await _http.GetFromJsonAsync<ApiResponse<SpecialistDto>>($"{CategoryBaseURL}name?name={fullName}");

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

        public async Task UpdateSpecialist(SpecialistDto specialist)
        {
            try
            {
                var response = await _http.PutAsJsonAsync($"{CategoryBaseURL}admin", specialist);
                var result = (await response.Content
                    .ReadFromJsonAsync<ApiResponse<List<SpecialistDto>>>());

                if (result != null && result.Success)
                {
                    AdminSpecialists = result.Data!;

                    await GetSpecialists();
                }
            }
            catch (HttpRequestException ex)
            {
                HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
            }
        }

    }
}
