global using Medical.Domain.Dto.Response.Concrete;
global using Medical.Web.Client.Services.AuthService;
global using System.Net.Http;
global using System.Net.Http.Json;
using Blazored.LocalStorage;
using Medical.Resource;
using Medical.Web.Client;
using Medical.Web.Client.Data;
using Medical.Web.Client.Extensions;
using Medical.Web.Client.Services;
using Medical.Web.Client.Services.UserService;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


using System;
using Toolbelt.Blazor.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddLocalization();

var apiUrl = builder.Configuration.GetValue<string>("AppConfig:ApiUrl");
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(!string.IsNullOrEmpty(apiUrl) ? apiUrl : builder.HostEnvironment.BaseAddress),
}.EnableIntercept(sp));

builder.Services.AddHttpClientInterceptor();

builder.Services.AddBootstrapBlazor(op =>
{
    op.DefaultCultureInfo = Constants.LANGUAGE_SPANISH_PERU;
    op.IgnoreLocalizerMissing = true;
});

builder.Services.AddSingleton<WeatherForecastService>();

// 增加 Table 数据服务操作类
builder.Services.AddTableDemoDataService();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<HttpInterceptorService>();
builder.Services.AddScoped<RefreshTokenService>();

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

var host = builder.Build();

await host.RunAsync();
