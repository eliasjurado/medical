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
        services.AddScoped<ISubCategoryCommandRepository, SubCategoryCommandRepository>();
        services.AddScoped<IClientCommandRepository, ClientCommandRepository>();
        services.AddScoped<IPacientCommandRepository, PacientCommandRepository>();
        services.AddScoped<ITreatmentCommandRepository, TreatmentCommandRepository>();
        services.AddScoped<IWarehouseCommandRepository, WarehouseCommandRepository>();
        services.AddScoped<ISpecialistCommandRepository, SpecialistCommandRepository>();
        services.AddScoped<IAppointmentCommandRepository, AppointmentCommandRepository>();
        services.AddScoped<IBrandCommandRepository, BrandCommandRepository>();
        services.AddScoped<ISaleCommandRepository, SaleCommandRepository>();
        services.AddScoped<ISaleArticleCommandRepository, SaleArticleCommandRepository>();
        services.AddScoped<IArticleCommandRepository, ArticleCommandRepository>();
        services.AddScoped<IArticleStockCommandRepository, ArticleStockCommandRepository>();
        services.AddScoped<IFiscalUnitCommandRepository, FiscalUnitCommandRepository>();
        services.AddScoped<IFiscalSegmentCommandRepository, FiscalSegmentCommandRepository>();
        services.AddScoped<IFiscalFamilyCommandRepository, FiscalFamilyCommandRepository>();
        services.AddScoped<IFiscalClassCommandRepository, FiscalClassCommandRepository>();
        services.AddScoped<IFiscalProductCommandRepository, FiscalProductCommandRepository>();

        //Queries
        services.AddScoped<ICategoryQueryRepository, CategoryQueryRepository>();
        services.AddScoped<ISubCategoryQueryRepository, SubCategoryQueryRepository>();
        services.AddScoped<IClientQueryRepository, ClientQueryRepository>();
        services.AddScoped<IPacientQueryRepository, PacientQueryRepository>();
        services.AddScoped<ITreatmentQueryRepository, TreatmentQueryRepository>();
        services.AddScoped<IWarehouseQueryRepository, WarehouseQueryRepository>();
        services.AddScoped<ISpecialistQueryRepository, SpecialistQueryRepository>();
        services.AddScoped<IAppointmentQueryRepository, AppointmentQueryRepository>();
        services.AddScoped<IBrandQueryRepository, BrandQueryRepository>();
        services.AddScoped<ISaleQueryRepository, SaleQueryRepository>();
        services.AddScoped<ISaleArticleQueryRepository, SaleArticleQueryRepository>();
        services.AddScoped<IArticleQueryRepository, ArticleQueryRepository>();
        services.AddScoped<IArticleStockQueryRepository, ArticleStockQueryRepository>();
        services.AddScoped<IFiscalUnitQueryRepository, FiscalUnitQueryRepository>();
        services.AddScoped<IFiscalSegmentQueryRepository, FiscalSegmentQueryRepository>();
        services.AddScoped<IFiscalFamilyQueryRepository, FiscalFamilyQueryRepository>();
        services.AddScoped<IFiscalClassQueryRepository, FiscalClassQueryRepository>();
        services.AddScoped<IFiscalProductQueryRepository, FiscalProductQueryRepository>();

        return services;
    }
}
