using BootstrapBlazor.Components;
using Medical.UI.Services.CategoryService;
using Medical.UI.Data;

namespace Medical.UI.Extensions
{
    public static class ServiceCollectionExtensions
    {
            public static IServiceCollection AddServiceCollection(this IServiceCollection services)
            {
                services.AddScoped<ICategoryService, CategoryService>();
                services.AddScoped(typeof(IDataService<>), typeof(CategoryDataService<>));
                return services;
            }        
    }
}
