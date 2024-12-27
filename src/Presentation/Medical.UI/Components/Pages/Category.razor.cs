using Microsoft.AspNetCore.Components;

namespace Medical.UI.Components.Pages
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Category : ComponentBase
    {
        //[Inject]
        //[NotNull]
        //private IStringLocalizer<Foo>? Localizer { get; set; }

        //private readonly ConcurrentDictionary<Foo, IEnumerable<SelectedItem>> _cache = new();

        //private IEnumerable<SelectedItem> GetHobbys(Foo item) => _cache.GetOrAdd(item, f => Foo.GenerateHobbys(Localizer));

        /// <summary>
        /// 
        /// </summary>
        private static IEnumerable<int> PageItemsSource => new int[] { 20, 40 };
    }
}
