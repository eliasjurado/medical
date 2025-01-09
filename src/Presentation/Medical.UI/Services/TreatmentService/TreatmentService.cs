using Medical.Domain.Dto.Response.Concrete;
using Medical.Domain.Dto.Treatment;

namespace Medical.UI.Services.TreatmentService
{
    public class TreatmentService : ITreatmentService
    {
        private readonly HttpClient _http;
        private const string CategoryBaseURL = "api/Treatment/";
        public TreatmentService(HttpClient http)
        {
            _http = http;
        }

        public List<TreatmentDto> Treatments { get; set; } = new List<TreatmentDto>();
        public List<TreatmentDto> AdminTreatments { get; set; } = new List<TreatmentDto>();

        public event Action? OnChange;

        public async Task AddTreatment(TreatmentDto treatment)
        {
            var response = await _http.PostAsJsonAsync($"{CategoryBaseURL}admin", treatment);
            var result = (await response.Content
                .ReadFromJsonAsync<ApiResponse<List<TreatmentDto>>>());

            if (result != null && result.Success)
            {
                AdminTreatments = result.Data;

                await GetTreatments();
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
            var response = await _http.DeleteAsync($"{CategoryBaseURL}admin/{treatmentId}");

            var result = (await response.Content
               .ReadFromJsonAsync<ApiResponse<List<TreatmentDto>>>());

            if (result != null && result.Success)
            {
                AdminTreatments = result.Data;

                await GetTreatments();
            }
        }

        public async Task GetAdminTreatments()
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<List<TreatmentDto>>>($"{CategoryBaseURL}admin");
            if (response != null && response.Success)
            {
                AdminTreatments = response.Data;
            }

        }

        public async Task GetTreatments()
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<List<TreatmentDto>>>($"{CategoryBaseURL}");

            if (response != null && response.Success)
            {
                Treatments = response.Data;
            }
        }

        public async Task UpdateTreatment(TreatmentDto treatment)
        {
            var response = await _http.PutAsJsonAsync($"{CategoryBaseURL}admin", treatment);
            var result = (await response.Content
                .ReadFromJsonAsync<ApiResponse<List<TreatmentDto>>>());

            if (result != null && result.Success)
            {
                AdminTreatments = result.Data;

                await GetTreatments();
            }
        }
    }
}
