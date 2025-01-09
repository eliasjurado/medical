global using Medical.Domain.Dto.Response.Concrete;
global using MediatR;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Mvc;
global using Medical.Domain.Dto.Response.Abstract;

using Blazored.LocalStorage;
using Medical.Application;
using Medical.Application.Contracts.Identity;
using Medical.Identity;
using Medical.Persistence;
using Medical.Persistence.Contexts;
using Medical.Resource;
using Medical.UI;
using Medical.UI.Components;
using Medical.UI.Data;
using Medical.UI.Extensions;
using Medical.UI.Models;
using Medical.UI.Services;
using Medical.UI.Services.AuthService;
using Medical.UI.Services.UserService;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Text;
using Toolbelt.Blazor.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));

var settings = builder.Configuration.GetSection("ApiSettings").Get<ApiSettings>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(settings!.ApiHub!.App!) });

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddLocalization();
builder.Services.AddHttpClientInterceptor();

builder.Services.AddApplicationServices();
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddPersistanceServices(builder.Configuration);

// Add services to the container.
Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

builder.Services.AddRazorComponents().AddInteractiveServerComponents();

builder.Services.AddBootstrapBlazor(op =>
{
    op.DefaultCultureInfo = Constants.LANGUAGE_SPANISH_PERU;
    op.IgnoreLocalizerMissing = true;
});

builder.Services.AddBootstrapBlazorTableExportService();

builder.Services.AddSingleton<WeatherForecastService>();

// Add Table data service operation class
builder.Services.AddTableDemoDataService();
builder.Services.AddServiceCollection();

// Add SignalR service data transfer size limit configuration
builder.Services.Configure<HubOptions>(option => option.MaximumReceiveMessageSize = null);

builder.Services.AddScoped<ICurrentUser, CurrentUser>();
builder.Services.AddScoped<Medical.UI.Services.AuthService.IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<HttpInterceptorService>();
builder.Services.AddScoped<RefreshTokenService>();

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("all", builder => builder.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());
});

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

        throw;
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseResponseCompression();
}

app.UseStaticFiles();

app.UseSwaggerUI();
app.UseSwagger();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.MapControllers();

app.UseCors("all");

await app.RunAsync();
