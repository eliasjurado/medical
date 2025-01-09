using Medical.Domain.Dto.Appointment;

namespace Medical.UI.Services.AppointmentService
{
    public class AppointmentService : IAppointmentService
    {
        private readonly HttpClient _http;
        private const string AppointmentBaseURL = "api/Appointment/";
        public AppointmentService(HttpClient http)
        {
            _http = http;
        }

        public List<AppointmentDto> Appointments { get; set; } = new List<AppointmentDto>();
        public List<AppointmentDto> AdminAppointments { get; set; } = new List<AppointmentDto>();

        public event Action? OnChange;

        public async Task AddAppointment(AppointmentDto appointment)
        {
            var response = await _http.PostAsJsonAsync($"{AppointmentBaseURL}admin", appointment);
            var result = (await response.Content
                .ReadFromJsonAsync<ApiResponse<List<AppointmentDto>>>());

            if (result != null && result.Success)
            {
                AdminAppointments = result.Data!;

                await GetAppointments();
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
            var response = await _http.DeleteAsync($"{AppointmentBaseURL}admin/{appointmentId}");

            var result = (await response.Content
               .ReadFromJsonAsync<ApiResponse<List<AppointmentDto>>>());

            if (result != null && result.Success)
            {
                AdminAppointments = result.Data!;

                await GetAppointments();
            }
        }

        public async Task GetAdminAppointments()
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<List<AppointmentDto>>>($"{AppointmentBaseURL}admin");
            if (response != null && response.Success)
            {
                AdminAppointments = response.Data!;
            }

        }

        public async Task GetAppointments()
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<List<AppointmentDto>>>($"{AppointmentBaseURL}");

            if (response != null && response.Success)
            {
                Appointments = response.Data!;
            }
        }

        public async Task UpdateAppointment(AppointmentDto appointment)
        {
            var response = await _http.PutAsJsonAsync($"{AppointmentBaseURL}admin", appointment);
            var result = (await response.Content
                .ReadFromJsonAsync<ApiResponse<List<AppointmentDto>>>());

            if (result != null && result.Success)
            {
                AdminAppointments = result.Data!;

                await GetAppointments();
            }
        }
    }
}
