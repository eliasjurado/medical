using Medical.Persistence.Contexts;
using Medical.Persistence.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Medical.Persistence;

public static class ConfigureServices
{
    public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("App") ?? throw new InvalidOperationException("Connection string 'AppConnection' not found.");

        services.AddDbContext<PersistenceDataContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<PersistenceDbContextInitialiser>();

        services.AddScoped<IQueryUnitOfWork, QueryUnitOfWork>();
        services.AddScoped(typeof(ICommandUnitOfWork<>), typeof(CommandUnitOfWork<>));

        //Commands
        services.AddScoped<ICategoryCommandRepository, CategoryCommandRepository>();
        services.AddScoped<IPacientCommandRepository, PacientCommandRepository>();

        //Queries
        services.AddScoped<ICategoryQueryRepository, CategoryQueryRepository>();
        services.AddScoped<IPacientQueryRepository, PacientQueryRepository>();

        return services;
    }
}
