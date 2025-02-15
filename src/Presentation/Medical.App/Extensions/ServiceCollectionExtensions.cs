using Medical.App.Services.AppointmentService;
using Medical.App.Services.CategoryService;
using Medical.App.Services.PacientService;
using Medical.App.Services.SpecialistService;
using Medical.App.Services;
using Medical.App.Services.TreatmentService;
using Medical.Application.Contracts.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using Medical.App.Services.AuthService;
using Medical.App.Services.UserService;
using Medical.App.Services.BrandService;

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
            services.AddScoped<IBrandService, BrandService>();

            services.AddScoped<ICurrentUser, CurrentUser>();
            services.AddScoped<Services.AuthService.IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<HttpInterceptorService>();
            services.AddScoped<RefreshTokenService>();
            
            services.AddOptions();
            services.AddAuthorizationCore();
            services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

            return services;
        }
    }
}
