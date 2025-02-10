using Medical.App.Utils;
using Medical.Domain.Dto.Response.Concrete;
using Medical.Domain.Dto.User;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace Medical.App.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly HttpClient _http;
        private const string UserBaseURL = "api/user/";

        private readonly NavigationManager _navigationManager;
        private readonly NotificationService _notificationService;
        public UserService(HttpClient http, NavigationManager navigationManager, NotificationService notificationService)
        {
            _http = http;
            _navigationManager = navigationManager;
            _notificationService = notificationService;
        }

        public async Task<ApiResponse<string>> ChangePassword(UserChangePassword request)
        {
            var response = new ApiResponse<string>();
            try
            {
                var result = await _http.PostAsJsonAsync($"{UserBaseURL}change-password", request);
                response = await result.Content.ReadFromJsonAsync<ApiResponse<string>>();
            }
            catch (HttpRequestException ex)
            {
                HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
            }
            return response;
        }
    }
}
