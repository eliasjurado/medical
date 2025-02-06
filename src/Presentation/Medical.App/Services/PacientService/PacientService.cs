using Medical.Domain.Dto.Pacient;
using Medical.Domain.Dto.Response.Concrete;
using Medical.Domain.Dto.Specialist;

namespace Medical.App.Services.PacientService
{
    public class PacientService : IPacientService
    {
        private readonly HttpClient _http;
        private const string PacientBaseURL = "api/Pacient/";
        public PacientService(HttpClient http)
        {
            _http = http;
        }

        public List<PacientDto> Pacients { get; set; } = new List<PacientDto>();
        public List<PacientDto> AdminPacients { get; set; } = new List<PacientDto>();

        public event Action? OnChange;

        public async Task AddPacient(PacientDto pacient)
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

        public PacientDto CreateNewPacient()
        {
            var newPacientDto = new PacientDto { IsNew = true, Editing = true };
            AdminPacients.Add(newPacientDto);
            OnChange!.Invoke();
            return newPacientDto;
        }

        public async Task DeletePacient(int pacientId)
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

        public async Task GetAdminPacients()
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<List<PacientDto>>>($"{PacientBaseURL}admin");
            if (response != null && response.Success)
            {
                AdminPacients = response.Data!;
            }

        }

        public async Task GetPacients()
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<List<PacientDto>>>($"{PacientBaseURL}");

            if (response != null && response.Success)
            {
                Pacients = response.Data!;
            }
        }

        public async Task<PacientDto?> GetPacientByFullName(string fullName)
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<PacientDto>>($"{PacientBaseURL}name?name={fullName}");

            if (response != null && response.Success)
            {
                return response.Data!;
            }
            return null;
        }
        public async Task UpdatePacient(PacientDto pacient)
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
    }
}
