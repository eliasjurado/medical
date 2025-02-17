using Blazored.LocalStorage;
using Medical.App.Services;
using Medical.App.Services.AuthService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.WebUtilities;

namespace Medical.App.Components.Pages.Login
{
    public partial class Signout
    {
        [Inject]
        public AuthenticationStateProvider? AuthenticationStateProvider { get; set; }

        [Inject]
        public NavigationManager? NavigationManager { get; set; }
        [Inject]
        public ILocalStorageService? LocalStorage { get; set; }

        [Inject]
        public IAuthService? AuthService { get; set; }

        [Inject]
        public HttpInterceptorService? Interceptor { get; set; }

        private string returnUrl = string.Empty;

        protected async override void OnInitialized()
        {
            Interceptor!.RegisterEvent();
            var uri = NavigationManager!.ToAbsoluteUri(NavigationManager.Uri);
            if (QueryHelpers.ParseQuery(uri.Query).TryGetValue("returnUrl", out var url))
            {
                returnUrl = url!;
            }
            await HandleLogout();
        }

        private async Task HandleLogout()
        {
            await LocalStorage!.RemoveItemAsync("authToken");
            await AuthenticationStateProvider!.GetAuthenticationStateAsync();
            NavigationManager!.NavigateTo(returnUrl);
        }

    }
}
