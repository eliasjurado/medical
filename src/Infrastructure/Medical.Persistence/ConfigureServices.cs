using Medical.Persistence.Contexts;
using Medical.Persistence.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Medical.Persistence;

public static class ConfigureServices
{
    public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Default") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        services.AddDbContext<PersistenceDataContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<PersistenceDbContextInitialiser>();

        services.AddScoped<IQueryUnitOfWork, QueryUnitOfWork>();
        services.AddScoped(typeof(ICommandUnitOfWork<>), typeof(CommandUnitOfWork<>));

        //Commands
        services.AddScoped<ICategoryCommandRepository, CategoryCommandRepository>();
        services.AddScoped<IPacientCommandRepository, PacientCommandRepository>();
        services.AddScoped<ITreatmentCommandRepository, TreatmentCommandRepository>();
        services.AddScoped<ISpecialistCommandRepository, SpecialistCommandRepository>();
        services.AddScoped<IAppointmentCommandRepository, AppointmentCommandRepository>();
        services.AddScoped<IBrandCommandRepository, BrandCommandRepository>();
        services.AddScoped<IArticleCommandRepository, ArticleCommandRepository>();
        services.AddScoped<IFiscalUnitCommandRepository, FiscalUnitCommandRepository>();
        services.AddScoped<IFiscalSegmentCommandRepository, FiscalSegmentCommandRepository>();
        services.AddScoped<IFiscalFamilyCommandRepository, FiscalFamilyCommandRepository>();
        services.AddScoped<IFiscalClassCommandRepository, FiscalClassCommandRepository>();
        services.AddScoped<IFiscalProductCommandRepository, FiscalProductCommandRepository>();

        //Queries
        services.AddScoped<ICategoryQueryRepository, CategoryQueryRepository>();
        services.AddScoped<IPacientQueryRepository, PacientQueryRepository>();
        services.AddScoped<ITreatmentQueryRepository, TreatmentQueryRepository>();
        services.AddScoped<ISpecialistQueryRepository, SpecialistQueryRepository>();
        services.AddScoped<IAppointmentQueryRepository, AppointmentQueryRepository>();
        services.AddScoped<IBrandQueryRepository, BrandQueryRepository>();
        services.AddScoped<IArticleQueryRepository, ArticleQueryRepository>();
        services.AddScoped<IFiscalUnitQueryRepository, FiscalUnitQueryRepository>();
        services.AddScoped<IFiscalSegmentQueryRepository, FiscalSegmentQueryRepository>();
        services.AddScoped<IFiscalFamilyQueryRepository, FiscalFamilyQueryRepository>();
        services.AddScoped<IFiscalClassQueryRepository, FiscalClassQueryRepository>();
        services.AddScoped<IFiscalProductQueryRepository, FiscalProductQueryRepository>();

        return services;
    }
}
