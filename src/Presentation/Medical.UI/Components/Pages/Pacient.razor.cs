using Microsoft.AspNetCore.Components;

namespace Medical.UI.Components.Pages
{
    public partial class Pacient : ComponentBase
    {
        private static IEnumerable<int> PageItemsSource => new int[] { 20, 40 };
    }
}
