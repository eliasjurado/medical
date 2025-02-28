using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using Radzen;

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

        private bool sidebarExpanded = true;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            if(!authState.User.Identity.IsAuthenticated)
            {
                await Login();
            }
        }

        void SidebarToggleClick()
        {
            sidebarExpanded = !sidebarExpanded;
        }

        private async Task Login() => await Task.Run(() => NavigationManager!.NavigateTo("/login"));
    }
}
