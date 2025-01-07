using Medical.UI.Services.AppointmentService;
using Medical.UI.Services.CategoryService;
using Medical.UI.Services.PacientService;
using Medical.UI.Services.SpecialistService;
using Medical.UI.Services.TreatmentService;

namespace Medical.UI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceCollection(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IPacientService, PacientService>();
            services.AddScoped<ITreatmentService, TreatmentService>();
            services.AddScoped<ISpecialistService, SpecialistService>();
            services.AddScoped<IAppointmentService, AppointmentService>();

            return services;
        }
    }
}
