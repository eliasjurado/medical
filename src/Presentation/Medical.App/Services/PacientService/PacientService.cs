using Medical.App.Utils;
using Medical.Domain.Dto.Pacient;
using Medical.Domain.Dto.Response.Concrete;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace Medical.App.Services.PacientService
{
    public class PacientService : IPacientService
    {
        private readonly HttpClient _http;
        private const string PacientBaseURL = "api/Pacient/";
        private readonly NavigationManager _navigationManager;
        private readonly NotificationService _notificationService;
        public PacientService(HttpClient http, NavigationManager navigationManager, NotificationService notificationService)
        {
            _http = http;
            _navigationManager = navigationManager;
            _notificationService = notificationService;
        }

        public List<PacientDto> Pacients { get; set; } = new List<PacientDto>();
        public List<PacientDto> AdminPacients { get; set; } = new List<PacientDto>();

        public event Action? OnChange;

        public async Task AddPacient(PacientDto pacient)
        {
            try
            {
                var response = await _http.PostAsJsonAsync($"{PacientBaseURL}admin", pacient);
                var result = (await response.Content
                    .ReadFromJsonAsync<ApiResponse<List<PacientDto>>>());

                if (result != null && result.Success)
                {
                    AdminPacients = result.Data!;

                    await GetPacients();
                    OnChange!.Invoke();
                }
            }
            catch (HttpRequestException ex)
            {
                HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
            }
        }

        public PacientDto CreateNewPacient()
        {
            var newPacientDto = new PacientDto { IsNew = true, Editing = true };
            AdminPacients.Add(newPacientDto);
            OnChange!.Invoke();
            return newPacientDto;
        }

        public async Task DeletePacient(int pacientId)
        {
            try
            {
                var response = await _http.DeleteAsync($"{PacientBaseURL}admin/{pacientId}");

                var result = (await response.Content
                   .ReadFromJsonAsync<ApiResponse<List<PacientDto>>>());

                if (result != null && result.Success)
                {
                    AdminPacients = result.Data!;

                    await GetPacients();
                    OnChange!.Invoke();
                }
            }
            catch (HttpRequestException ex)
            {
                HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
            }
        }

        public async Task GetAdminPacients()
        {
            try
            {
                var response = await _http.GetFromJsonAsync<ApiResponse<List<PacientDto>>>($"{PacientBaseURL}admin");
                if (response != null && response.Success)
                {
                    AdminPacients = response.Data!;
                }
            }
            catch (HttpRequestException ex)
            {
                HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
            }
        }

        public async Task GetPacients()
        {
            try
            {
                var response = await _http.GetFromJsonAsync<ApiResponse<List<PacientDto>>>($"{PacientBaseURL}");

                if (response != null && response.Success)
                {
                    Pacients = response.Data!;
                }
            }
            catch (HttpRequestException ex)
            {
                HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
            }            
        }

        public async Task<PacientDto?> GetPacientByFullName(string fullName)
        {
            try
            {
                var response = await _http.GetFromJsonAsync<ApiResponse<PacientDto>>($"{PacientBaseURL}name?name={fullName}");

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
        public async Task UpdatePacient(PacientDto pacient)
        {
            try
            {
                var response = await _http.PutAsJsonAsync($"{PacientBaseURL}admin", pacient);
                var result = (await response.Content
                    .ReadFromJsonAsync<ApiResponse<List<PacientDto>>>());

                if (result != null && result.Success)
                {
                    AdminPacients = result.Data!;

                    await GetPacients();
                    OnChange!.Invoke();
                }
            }
            catch (HttpRequestException ex)
            {
                HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
            }
        }
    }
}
