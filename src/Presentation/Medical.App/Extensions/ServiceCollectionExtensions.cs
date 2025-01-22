using Medical.App.Services.AppointmentService;
using Medical.App.Services.CategoryService;
using Medical.App.Services.PacientService;
using Medical.App.Services.SpecialistService;
using Medical.App.Services;
using Medical.App.Services.TreatmentService;
using Medical.Application.Contracts.Identity;

namespace Medical.App.Extensions
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

            services.AddScoped<ICurrentUser, CurrentUser>();

            return services;
        }
    }
}
