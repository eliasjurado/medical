using Medical.App.Services.AppUserService;
using Medical.Domain.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using Radzen;
using System.Security.Claims;

namespace Medical.App.Components.Layout
{
    public partial class MainLayout
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [Inject]
        private AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        private IAppUserService appUserService { get; set; }

        private bool sidebarExpanded = true;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            if (!authState.User.Identity.IsAuthenticated)
            {
                await Login();
            }
            else
            {
                var userId = authState.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
                var appUser = await appUserService.GetAppUserByUserId(userId);
                if (appUser == null)
                {
                    await Profile();
                }
            }
        }

        void SidebarToggleClick()
        {
            sidebarExpanded = !sidebarExpanded;
        }

        private async Task Login() => await Task.Run(() => NavigationManager!.NavigateTo("/login"));

        private async Task Profile() => await Task.Run(() => NavigationManager!.NavigateTo("/perfil"));
    }
}
