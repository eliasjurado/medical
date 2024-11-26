using BootstrapBlazor.Components;
using MediatR;
using Medical.Web.Client.Services;
using Medical.Web.Client.Services.UserService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medical.Web.Client.Shared
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class MainLayout
    {
        [Inject]
        NavigationManager NavigationManager { get; set; }

        [Inject]
        public HttpInterceptorService Interceptor { get; set; }

        private bool UseTabSet { get; set; } = true;

        private string Theme { get; set; } = "";

        private bool IsOpen { get; set; }

        private bool IsFixedHeader { get; set; } = true;

        private bool IsFixedFooter { get; set; } = true;

        private bool IsCollapsedSide { get; set; } = false;

        private bool IsFullSide { get; set; } = true;

        private bool ShowFooter { get; set; } = true;

        private List<MenuItem>? Menus { get; set; }

        /// <summary>
        /// OnInitialized 方法
        /// </summary>
        protected override void OnInitialized()
        {
            Interceptor.RegisterEvent();
            base.OnInitialized();                       
            Menus = GetIconSideMenuItems();
        }

        private List<MenuItem> GetIconSideMenuItems()
        {
            var menus = new List<MenuItem>
            {
                new MenuItem() { Text = "Index", Icon = "fa-solid fa-fw fa-home", Url = "/" , Match = NavLinkMatch.All},
                //new MenuItem() { Text = "Counter", Icon = "fa-solid fa-fw fa-check-square", Url = "/counter" },
                //new MenuItem() { Text = "FetchData", Icon = "fa-solid fa-fw fa-database", Url = "fetchdata" },
                //new MenuItem() { Text = "Artículos", Icon = "fa-solid fa-fw fa-table", Url = "table" },
                //new MenuItem() { Text = "Pacientes", Icon = "fa-solid fa-fw fa-users", Url = "users" }
            };
            return menus;
        }

        private async Task Login() => NavigationManager.NavigateTo("/login");

    }
}
