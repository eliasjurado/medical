using Medical.App.CustomExceptions;
using Medical.App.Services.AuthService;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;
using System.Net;
using System.Net.Http.Headers;
using Toolbelt.Blazor;

namespace Medical.App.Services;

public class HttpInterceptorService
{
    private readonly HttpClientInterceptor _interceptor;
    private readonly NavigationManager _navManager;
    private readonly RefreshTokenService _refreshTokenService;
    private readonly IAuthService _authService;
    public NotificationService _notificationService;

    public HttpInterceptorService(HttpClientInterceptor interceptor, NavigationManager navManager, RefreshTokenService refreshTokenService, IAuthService authService, NotificationService notificationService)
    {
        _interceptor = interceptor;
        _navManager = navManager;
        _refreshTokenService = refreshTokenService;
        _authService = authService;
        _notificationService = notificationService;
    }

    public void RegisterEvent()
    {
        _interceptor.AfterSend += InterceptResponse!;
        _interceptor.BeforeSendAsync += InterceptBeforeHttpAsync;
    }

    public async Task InterceptBeforeHttpAsync(object sender, HttpClientInterceptorEventArgs e)
    {
        try
        {
            var absPath = e.Request.RequestUri!.AbsolutePath;

            var isUserAuthenticated = await _authService.IsUserAuthenticated();

            if (!absPath.Contains("auth") && isUserAuthenticated)
            {
                var token = await _refreshTokenService.TryRefreshToken();

                if (!string.IsNullOrEmpty(token))
                {
                    e.Request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.Replace("\"", ""));
                }
            }
        }
        catch (JSDisconnectedException ex)
        {
            //Ignore
        }
    }

    private void InterceptResponse(object sender, HttpClientInterceptorEventArgs e)
    {
        string message = string.Empty;

        if (e.Response is not null && !e.Response.IsSuccessStatusCode)
        {
            var statusCode = e.Response.StatusCode;

            switch (statusCode)
            {
                case HttpStatusCode.NotFound:
                    //_navManager.NavigateTo("/404");
                    message = "The requested resorce was not found.";
                    break;
                case HttpStatusCode.Unauthorized:
                    //_navManager.NavigateTo("/login");
                    message = "User is not authorized";
                    break;
                default:
                    //_navManager.NavigateTo("/500");
                    message = "Something went wrong, please contact Administrator";
                    break;
            }

            var notification = new NotificationMessage
            {
                Severity = NotificationSeverity.Error,
                Summary = statusCode.ToString(),
                Detail = message,
                Duration = 2000,
                CloseOnClick = true
            };
            //_notificationService.Notify(notification);
            //throw new HttpResponseException(message);
        }
    }

    public void DisposeEvent()
    {
        _interceptor.AfterSend -= InterceptResponse!;
        _interceptor.BeforeSendAsync -= InterceptBeforeHttpAsync;
    }
}