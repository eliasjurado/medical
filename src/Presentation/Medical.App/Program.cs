using Medical.App.Components;
using Medical.App.Extensions;
using Medical.App.Models;
using Medical.App.Services;
using Medical.Application;
using Medical.Application.Contracts.Identity;
using Medical.Identity;
using Medical.Persistence;
using Medical.Persistence.Contexts;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));

var settings = builder.Configuration.GetSection("ApiSettings").Get<ApiSettings>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(settings!.ApiHub!.App!) });

// Add services to the container.
builder.Services.AddRazorComponents()
      .AddInteractiveServerComponents().AddHubOptions(options => options.MaximumReceiveMessageSize = 10 * 1024 * 1024);

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen();
builder.Services.AddRadzenComponents();

builder.Services.AddRadzenCookieThemeService(options =>
{
    options.Name = "Medical.AppTheme";
    options.Duration = TimeSpan.FromDays(365);
});
builder.Services.AddHttpClient();

builder.Services.AddApplicationServices();
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddPersistanceServices(builder.Configuration);
builder.Services.AddServiceCollection();

var app = builder.Build();

// Initialise and seed the database
using (var scope = app.Services.CreateScope())
{
    try
    {
        var initialiser = scope.ServiceProvider.GetRequiredService<UserIdentityDbContextInitialiser>();
        await initialiser.InitialiseAsync();

        var persistenceInitialiser = scope.ServiceProvider.GetRequiredService<PersistenceDbContextInitialiser>();
        await persistenceInitialiser.InitialiseAsync();
    }
    catch (Exception ex)
    {
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred during database initialisation.");
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwaggerUI();
app.UseSwagger();
app.UseRouting();
app.UseHttpsRedirection();
app.MapControllers();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

app.Run();