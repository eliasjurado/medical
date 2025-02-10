using Medical.App.Utils;
using Medical.Domain.Dto.Response.Concrete;
using Medical.Domain.Dto.Treatment;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace Medical.App.Services.TreatmentService
{
    public class TreatmentService : ITreatmentService
    {
        private readonly HttpClient _http;
        private const string CategoryBaseURL = "api/Treatment/";
        private readonly NavigationManager _navigationManager;
        private readonly NotificationService _notificationService;
        public TreatmentService(HttpClient http, NavigationManager navigationManager, NotificationService notificationService)
        {
            _http = http;
            _navigationManager = navigationManager;
            _notificationService = notificationService;
        }

        public List<TreatmentDto> Treatments { get; set; } = new List<TreatmentDto>();
        public List<TreatmentDto> AdminTreatments { get; set; } = new List<TreatmentDto>();

        public event Action? OnChange;

        public async Task AddTreatment(TreatmentDto treatment)
        {
            try
            {
                var response = await _http.PostAsJsonAsync($"{CategoryBaseURL}admin", treatment);
                var result = (await response.Content
                    .ReadFromJsonAsync<ApiResponse<List<TreatmentDto>>>());

                if (result != null && result.Success)
                {
                    AdminTreatments = result.Data!;

                    await GetTreatments();
                }
            }
            catch (HttpRequestException ex)
            {
                HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
            }
        }

        public TreatmentDto CreateNewTreatment()
        {
            var newTreatmentDto = new TreatmentDto { IsNew = true, Editing = true };
            AdminTreatments.Add(newTreatmentDto);
            OnChange!.Invoke();
            return newTreatmentDto;
        }

        public async Task DeleteTreatment(int treatmentId)
        {
            try
            {
                var response = await _http.DeleteAsync($"{CategoryBaseURL}admin/{treatmentId}");

                var result = (await response.Content
                   .ReadFromJsonAsync<ApiResponse<List<TreatmentDto>>>());

                if (result != null && result.Success)
                {
                    AdminTreatments = result.Data!;

                    await GetTreatments();
                }
            }
            catch (HttpRequestException ex)
            {
                HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
            }
        }

        public async Task GetAdminTreatments()
        {
            try
            {
                var response = await _http.GetFromJsonAsync<ApiResponse<List<TreatmentDto>>>($"{CategoryBaseURL}admin");
                if (response != null && response.Success)
                {
                    AdminTreatments = response.Data!;
                }
            }
            catch (HttpRequestException ex)
            {
                HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
            }
        }

        public async Task GetTreatments()
        {
            try
            {
                var response = await _http.GetFromJsonAsync<ApiResponse<List<TreatmentDto>>>($"{CategoryBaseURL}");

                if (response != null && response.Success)
                {
                    Treatments = response.Data!;
                }
            }
            catch (HttpRequestException ex)
            {
                HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
            }            
        }

        public async Task<TreatmentDto?> GetTreatmentByName(string name)
        {
            try
            {
                var response = await _http.GetFromJsonAsync<ApiResponse<TreatmentDto>>($"{CategoryBaseURL}name?name={name}");

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

        public async Task UpdateTreatment(TreatmentDto treatment)
        {
            try
            {
                var response = await _http.PutAsJsonAsync($"{CategoryBaseURL}admin", treatment);
                var result = (await response.Content
                    .ReadFromJsonAsync<ApiResponse<List<TreatmentDto>>>());

                if (result != null && result.Success)
                {
                    AdminTreatments = result.Data!;

                    await GetTreatments();
                }
            }
            catch (HttpRequestException ex)
            {
                HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
            }            
        }
    }
}
