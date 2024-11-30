using Medical.Domain.Dto.User;
using Medical.Web.Client.Services;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Linq;
using System;
using Medical.Domain.Dto.Auth;


//@inject AuthenticationStateProvider AuthenticationStateProvider

namespace Medical.Web.Client.Pages.Auth
{
    public partial class Login
    {
        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

        [Inject]
        public IAuthService AuthService { get; set; }

        [Inject]
        public HttpInterceptorService Interceptor { get; set; }

        [NotNull]
        private UserLogin user = new UserLogin();

        private string errorMessage = string.Empty;

        private string returnUrl = string.Empty;

        private string currentUrl = string.Empty;

        private ApiResponse<AuthResponseDto> response { get; set; } 

        protected override void OnInitialized()
        {
            Interceptor.RegisterEvent();
            var uri = NavigationManager.ToAbsoluteUri(NavigationManager.Uri);
            if (QueryHelpers.ParseQuery(uri.Query).TryGetValue("returnUrl", out var url))
            {
                returnUrl = url;
            }

            currentUrl = NavigationManager.ToBaseRelativePath(NavigationManager.Uri);
            //NavigationManager.LocationChanged += OnLocationChanged;
        }

        private async Task HandleLogin()
        {
            var result = await AuthService.Login(user);
            response = result;
            if (result != null)
            {
                if (result.Success)
                {
                    errorMessage = string.Empty;

                    await LocalStorage.SetItemAsync("authToken", result.Data.Token);
                    await AuthenticationStateProvider.GetAuthenticationStateAsync();
                    // await CartService.StoreCartItems(true);
                    // await CartService.GetCartItemsCount();
                    NavigationManager.NavigateTo(returnUrl);
                }
                else
                {
                    errorMessage = result.Messages.FirstOrDefault();
                }
            }
        }

        //private void OnLocationChanged(object? sender, LocationChangedEventArgs e)
        //{
        //    currentUrl = NavigationManager.ToBaseRelativePath(e.Location);
        //    StateHasChanged();
        //}

        //public void Dispose()
        //{
        //    Interceptor.DisposeEvent();
        //    NavigationManager.LocationChanged -= OnLocationChanged;
        //}
    }
}
