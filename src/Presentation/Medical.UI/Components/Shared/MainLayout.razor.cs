using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace Medical.UI.Components.Shared
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class MainLayout
    {
        [Inject]
        NavigationManager? NavigationManager { get; set; }
        private bool UseTabSet { get; set; } = true;

        private string Theme { get; set; } = "";

        private bool IsCollapsedSide { get; set; } = false;

        private bool IsFixedHeader { get; set; } = true;

        private bool IsFixedFooter { get; set; } = true;

        private bool IsFullSide { get; set; } = true;

        private bool ShowFooter { get; set; } = true;

        private List<MenuItem>? Menus { get; set; }

        /// <summary>
        /// OnInitialized 方法
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();

            Menus = GetIconSideMenuItems();
        }

        private static List<MenuItem> GetIconSideMenuItems()
        {
            var menus = new List<MenuItem>
            {
                //new() { Text = "返回组件库", Icon = "fa-solid fa-fw fa-home", Url = "https://www.blazor.zone/components" },
                new() { Text = "Index", Icon = "fa-solid fa-fw fa-flag", Url = "/" , Match = NavLinkMatch.All},
                //new() { Text = "Counter", Icon = "fa-solid fa-fw fa-check-square", Url = "/counter" },
                //new() { Text = "Weather", Icon = "fa-solid fa-fw fa-database", Url = "/weather" },
                //new() { Text = "Table", Icon = "fa-solid fa-fw fa-table", Url = "/table" },                                
                //new() { Text = "花名册", Icon = "fa-solid fa-fw fa-users", Url = "/users" },
                new() { Text = "Pacientes", Icon = "fa-solid fa-fw fa-users", Items = new List<MenuItem>{
                    new() { Text = "Paciente", Icon = "fa-solid fa-fw fa-user", Url = "/paciente"  },
                    new() { Text = "Citas", Icon = "fa-solid fa-fw fa-calendar", Url = "/citas"  },
                }},
                new() { Text = "Sistema", Icon = "fa-solid fa-fw fa-gears", Items = new List<MenuItem>{
                    new() { Text = "Categoría", Icon = "fa-solid fa-fw fa-table", Url = "/categoria" },
                    new() { Text = "Consultorio", Icon = "fa-solid fa-fw fa-table", Url = "/consultorio" },
                    new() { Text = "Especialista", Icon = "fa-solid fa-fw fa-table", Url = "/especialista" },
                }}
            };

            return menus;
        }

        private async Task Login() => await Task.Run(() => NavigationManager!.NavigateTo("/login"));
    }
}
