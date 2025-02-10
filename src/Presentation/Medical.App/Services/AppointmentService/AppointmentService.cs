using Medical.App.Utils;
using Medical.Domain.Dto.Appointment;
using Medical.Domain.Dto.Response.Concrete;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace Medical.App.Services.AppointmentService
{
    public class AppointmentService : IAppointmentService
    {
        private readonly HttpClient _http;
        private const string AppointmentBaseURL = "api/Appointment/";
        private readonly NavigationManager _navigationManager;
        private readonly NotificationService _notificationService;
        public AppointmentService(HttpClient http, NavigationManager navigationManager, NotificationService notificationService)
        {
            _http = http;
            _navigationManager = navigationManager;
            _notificationService = notificationService;
        }

        public List<AppointmentDto> Appointments { get; set; } = new List<AppointmentDto>();
        public List<AppointmentDto> AdminAppointments { get; set; } = new List<AppointmentDto>();

        public event Action? OnChange;

        public async Task AddAppointment(AppointmentDto appointment)
        {
            try
            {
                var response = await _http.PostAsJsonAsync($"{AppointmentBaseURL}admin", appointment);
                var result = (await response.Content
                    .ReadFromJsonAsync<ApiResponse<List<AppointmentDto>>>());

                if (result != null && result.Success)
                {
                    AdminAppointments = result.Data!;

                    await GetAppointments();
                    OnChange!.Invoke();
                }
            }
            catch (HttpRequestException ex)
            {
                HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
            }
        }

        public AppointmentDto CreateNewAppointment()
        {
            var newAppointmentDto = new AppointmentDto { IsNew = true, Editing = true };
            AdminAppointments.Add(newAppointmentDto);
            OnChange!.Invoke();
            return newAppointmentDto;
        }

        public async Task DeleteAppointment(int appointmentId)
        {
            try
            {
                var response = await _http.DeleteAsync($"{AppointmentBaseURL}admin/{appointmentId}");

                var result = (await response.Content
                   .ReadFromJsonAsync<ApiResponse<List<AppointmentDto>>>());

                if (result != null && result.Success)
                {
                    AdminAppointments = result.Data!;

                    await GetAppointments();
                    OnChange!.Invoke();
                }
            }
            catch (HttpRequestException ex)
            {
                HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
            }
        }

        public async Task GetAdminAppointments()
        {
            try
            {
                var response = await _http.GetFromJsonAsync<ApiResponse<List<AppointmentDto>>>($"{AppointmentBaseURL}admin");
                if (response != null && response.Success)
                {
                    AdminAppointments = response.Data!;
                }
            }
            catch (HttpRequestException ex)
            {
                HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
            }
        }

        public async Task GetAppointments()
        {
            try
            {
                var response = await _http.GetFromJsonAsync<ApiResponse<List<AppointmentDto>>>($"{AppointmentBaseURL}");
                if (response != null && response.Success)
                {
                    Appointments = response.Data!;
                }
            }
            catch (HttpRequestException ex)
            {
                HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
            }            
        }

        public async Task UpdateAppointment(AppointmentDto appointment)
        {
            try
            {
                var response = await _http.PutAsJsonAsync($"{AppointmentBaseURL}admin", appointment);
                var result = (await response.Content
                    .ReadFromJsonAsync<ApiResponse<List<AppointmentDto>>>());

                if (result != null && result.Success)
                {
                    AdminAppointments = result.Data!;

                    await GetAppointments();
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
