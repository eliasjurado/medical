using Blazored.LocalStorage;
using Medical.Application.Contracts.Identity;
using Medical.Identity;
using Medical.Resource;
using Medical.UI;
using Medical.UI.Components;
using Medical.UI.Data;
using Medical.UI.Models;
using Medical.UI.Services;
using Medical.UI.Services.AuthService;
using Medical.UI.Services.UserService;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Text;
using Toolbelt.Blazor.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddLocalization();
builder.Services.AddHttpClientInterceptor();

builder.Services.AddIdentityServices(builder.Configuration);

// Add services to the container.
Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

builder.Services.AddRazorComponents().AddInteractiveServerComponents();

builder.Services.AddBootstrapBlazor(op =>
{
    op.DefaultCultureInfo = Constants.LANGUAGE_SPANISH_PERU;
    op.IgnoreLocalizerMissing = true;
});

builder.Services.AddSingleton<WeatherForecastService>();

// Add Table data service operation class
builder.Services.AddTableDemoDataService();

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

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseResponseCompression();
}

app.UseStaticFiles();

app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.UseCors("all");

app.Run();
