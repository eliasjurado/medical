using Blazored.LocalStorage;
using Medical.Domain.Dto.Auth;
using Medical.Domain.Dto.Response.Concrete;
using Medical.Domain.Dto.User;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace Medical.App.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _http;
        private readonly AuthenticationStateProvider _authStateProvider;
        private const string AuthBaseURL = "api/auth/";
        private readonly ILocalStorageService _localStorage;
        private readonly NavigationManager _navigationManager;

        public AuthService(HttpClient http, AuthenticationStateProvider authStateProvider, ILocalStorageService localStorage, NavigationManager navigationManager, Application.Contracts.Identity.IAuthService authService)
        {
            _http = http;
            _authStateProvider = authStateProvider;
            _localStorage = localStorage;
            _navigationManager = navigationManager;

        }

        public async Task<bool> IsUserAuthenticated()
        {
            return (await _authStateProvider.GetAuthenticationStateAsync()).User.Identity!.IsAuthenticated;
        }

        public async Task<ApiResponse<AuthResponseDto>> Login(UserLogin request)
        {
            var result = await _http.PostAsJsonAsync($"{AuthBaseURL}login", request);
            return (await result.Content.ReadFromJsonAsync<ApiResponse<AuthResponseDto>>())!;
        }

        public async Task<ApiResponse<string>> Register(UserRegister request)
        {
            var result = await _http.PostAsJsonAsync($"{AuthBaseURL}register", request);
            return (await result.Content.ReadFromJsonAsync<ApiResponse<string>>())!;
        }

        public async Task<string> RefreshToken()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            var request = new RefreshTokenRequest() { CurrentToken = token };

            var result = await _http.PostAsJsonAsync($"{AuthBaseURL}refreshtoken", request);
            var response = await result.Content.ReadFromJsonAsync<ApiResponse<AuthResponseDto>>();

            if (response != null)
            {
                if (response.Success)
                {
                    await _localStorage.SetItemAsync("authToken", response.Data?.Token);
                    await _authStateProvider.GetAuthenticationStateAsync();
                    return response.Data!.Token;
                }
                else
                {
                    _navigationManager.NavigateTo("login");
                }
            }

            return string.Empty;
        }
    }
}
