using Medical.Domain.Dto.Response.Concrete;
using Medical.Domain.Dto.Specialist;

namespace Medical.UI.Services.SpecialistService
{
    public class SpecialistService : ISpecialistService
    {
        private readonly HttpClient _http;
        private const string CategoryBaseURL = "api/Specialist/";
        public SpecialistService(HttpClient http)
        {
            _http = http;
        }

        public List<SpecialistDto> Specialists { get; set; } = new List<SpecialistDto>();
        public List<SpecialistDto> AdminSpecialists { get; set; } = new List<SpecialistDto>();

        public event Action OnChange;

        public async Task AddSpecialist(SpecialistDto SpecialistDto)
        {
            var response = await _http.PostAsJsonAsync($"{CategoryBaseURL}admin", SpecialistDto);
            var result = (await response.Content
                .ReadFromJsonAsync<ApiResponse<List<SpecialistDto>>>());

            if (result != null && result.Success)
            {
                AdminSpecialists = result.Data;

                await GetSpecialists();

                //OnChange.Invoke();
            }
        }

        public SpecialistDto CreateNewSpecialist()
        {
            var newSpecialistDto = new SpecialistDto { IsNew = true, Editing = true };
            AdminSpecialists.Add(newSpecialistDto);
            OnChange.Invoke();
            return newSpecialistDto;
        }

        public async Task DeleteSpecialist(int SpecialistDtoId)
        {
            var response = await _http.DeleteAsync($"{CategoryBaseURL}admin/{SpecialistDtoId}");

            var result = (await response.Content
               .ReadFromJsonAsync<ApiResponse<List<SpecialistDto>>>());

            if (result != null && result.Success)
            {
                AdminSpecialists = result.Data;

                await GetSpecialists();

                //OnChange.Invoke();
            }
        }

        public async Task GetAdminSpecialists()
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<List<SpecialistDto>>>($"{CategoryBaseURL}admin");
            if (response != null && response.Success)
            {
                AdminSpecialists = response.Data;
            }

        }

        public async Task GetSpecialists()
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<List<SpecialistDto>>>($"{CategoryBaseURL}");

            if (response != null && response.Success)
            {
                Specialists = response.Data;
            }
        }

        public async Task UpdateSpecialist(SpecialistDto SpecialistDto)
        {
            var response = await _http.PutAsJsonAsync($"{CategoryBaseURL}admin", SpecialistDto);
            var result = (await response.Content
                .ReadFromJsonAsync<ApiResponse<List<SpecialistDto>>>());

            if (result != null && result.Success)
            {
                AdminSpecialists = result.Data;

                await GetSpecialists();

                //OnChange.Invoke();
            }
        }

    }
}
