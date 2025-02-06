using Blazored.LocalStorage;
using Medical.App.Services;
using Medical.App.Services.AuthService;
using Medical.Domain.Dto.Auth;
using Medical.Domain.Dto.Response.Concrete;
using Medical.Domain.Dto.User;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.WebUtilities;
using Radzen;
using System.Diagnostics.CodeAnalysis;


//@inject AuthenticationStateProvider AuthenticationStateProvider

namespace Medical.App.Components.Pages
{
    public partial class Signin
    {
        [Inject]
        public AuthenticationStateProvider? AuthenticationStateProvider { get; set; }

        [Inject]
        public NotificationService NotificationService { get; set; }

        [Inject]
        public NavigationManager? NavigationManager { get; set; }

        [Inject]
        public ILocalStorageService? LocalStorage { get; set; }

        [Inject]
        public IAuthService? AuthService { get; set; }

        [Inject]
        public HttpInterceptorService? Interceptor { get; set; }

        [NotNull]
        private UserLogin user = new UserLogin();

        private string errorMessage = string.Empty;

        private string returnUrl = string.Empty;

        private string currentUrl = string.Empty;

        private ApiResponse<AuthResponseDto>? response { get; set; }

        protected override void OnInitialized()
        {
            Interceptor!.RegisterEvent();
            var uri = NavigationManager!.ToAbsoluteUri(NavigationManager.Uri);
            if (QueryHelpers.ParseQuery(uri.Query).TryGetValue("returnUrl", out var url))
            {
                returnUrl = url!;
            }

            currentUrl = NavigationManager.ToBaseRelativePath(NavigationManager.Uri);
        }

        private async Task HandleLogin(LoginArgs args)
        {
            user.Email = args.Username;
            user.Password = args.Password;
            var result = await AuthService!.Login(user);
            response = result;
            if (result != null)
            {
                if (result.Success)
                {
                    errorMessage = string.Empty;

                    await LocalStorage!.SetItemAsync("authToken", result.Data?.Token);
                    await AuthenticationStateProvider!.GetAuthenticationStateAsync();

                    NavigationManager!.NavigateTo(returnUrl);
                }
                else
                {
                    errorMessage = result.Messages.FirstOrDefault()!;
                    var message = new NotificationMessage
                    {
                        Severity = NotificationSeverity.Error,
                        Summary = Resource.Constants.LOGIN_FORM_TITLE,
                        Detail = errorMessage ?? Resource.Constants.LOGIN_FORM_ERROR,
                        Duration = 4000
                    };
                    NotificationService.Notify(message);
                }
            }
        }
    }
}
