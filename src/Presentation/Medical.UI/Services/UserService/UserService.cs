using Medical.Domain.Dto.Response.Concrete;
using Medical.Domain.Dto.User;
using Medical.UI.Models;
using Microsoft.Extensions.Options;

namespace Medical.UI.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly HttpClient _http;
        private const string UserBaseURL = "api/user/";
        private readonly ApiSettings _apiSettings;

        public UserService(HttpClient http, IOptions<ApiSettings> apiSettings)
        {
            //_http = http;
            _apiSettings = apiSettings.Value;
            _http = new HttpClient() { BaseAddress = new Uri(_apiSettings.ApiHub.Auth) };
        }

        public async Task<ApiResponse<string>> ChangePassword(UserChangePassword request)
        {
            var result = await _http.PostAsJsonAsync($"{UserBaseURL}change-password", request);
            return await result.Content.ReadFromJsonAsync<ApiResponse<string>>();
        }
    }
}
