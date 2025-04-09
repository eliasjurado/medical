using Medical.App.Services;
using Medical.App.Services.AppointmentService;
using Medical.App.Services.AppUserService;
using Medical.App.Services.ArticleService;
using Medical.App.Services.ArticleStockService;
using Medical.App.Services.AuthService;
using Medical.App.Services.BrandService;
using Medical.App.Services.CategoryService;
using Medical.App.Services.ClientService;
using Medical.App.Services.FiscalClassService;
using Medical.App.Services.FiscalFamilyService;
using Medical.App.Services.FiscalProductService;
using Medical.App.Services.FiscalSegmentService;
using Medical.App.Services.FiscalUnitService;
using Medical.App.Services.PacientService;
using Medical.App.Services.SerieService;
using Medical.App.Services.SpecialistService;
using Medical.App.Services.SubCategoryService;
using Medical.App.Services.TreatmentService;
using Medical.App.Services.UserService;
using Medical.App.Services.WarehouseService;
using Medical.Application.Contracts.Identity;
using Microsoft.AspNetCore.Components.Authorization;

namespace Medical.App.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceCollection(this IServiceCollection services)
        {
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ISubCategoryService, SubCategoryService>();
            services.AddScoped<IPacientService, PacientService>();
            services.AddScoped<ITreatmentService, TreatmentService>();
            services.AddScoped<ISpecialistService, SpecialistService>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<IArticleStockService, ArticleStockService>();
            services.AddScoped<IFiscalUnitService, FiscalUnitService>();
            services.AddScoped<IFiscalSegmentService, FiscalSegmentService>();
            services.AddScoped<IFiscalFamilyService, FiscalFamilyService>();
            services.AddScoped<IFiscalClassService, FiscalClassService>();
            services.AddScoped<IFiscalProductService, FiscalProductService>();
            services.AddScoped<IWarehouseService, WarehouseService>();
            services.AddScoped<ISerieService, SerieService>();
            services.AddScoped<IAppUserService, AppUserService>();

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
