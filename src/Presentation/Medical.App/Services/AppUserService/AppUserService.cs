using Medical.App.Utils;
using Medical.Domain.Dto.Response.Concrete;
using Medical.Domain.Dto.Sales;
using Medical.Domain.Dto.User;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace Medical.App.Services.AppUserService;

public class AppUserService : IAppUserService
{
    private readonly HttpClient _http;
    private const string BaseURL = "api/AppUser/";
    private readonly NavigationManager _navigationManager;
    private readonly NotificationService _notificationService;
    public AppUserService(HttpClient http, NavigationManager navigationManager, NotificationService notificationService)
    {
        _http = http;
        _navigationManager = navigationManager;
        _notificationService = notificationService;
    }

    public List<AppUserDto> AppUsers { get; set; } = new List<AppUserDto>();
    public List<AppUserDto> AdminAppUsers { get; set; } = new List<AppUserDto>();

    public event Action? OnChange;

    public async Task AddAppUser(AppUserDto item)
    {
        try
        {
            var response = await _http.PostAsJsonAsync($"{BaseURL}admin", item);
            var result = (await response.Content
                .ReadFromJsonAsync<ApiResponse<List<AppUserDto>>>());

            if (result != null && result.Success)
            {
                AdminAppUsers = result.Data!;

                await GetAppUsers();
                OnChange?.Invoke();
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }

    public AppUserDto CreateNewAppUser()
    {
        var newAppUserDto = new AppUserDto { IsNew = true, Editing = true };
        AdminAppUsers.Add(newAppUserDto);
        OnChange?.Invoke();
        return newAppUserDto;
    }

    //public async Task DeleteAppUser(int itemId)
    //{
    //    try
    //    {
    //        var response = await _http.DeleteAsync($"{BaseURL}admin/{itemId}");

    //        var result = (await response.Content
    //           .ReadFromJsonAsync<ApiResponse<List<AppUserDto>>>());

    //        if (result != null && result.Success)
    //        {
    //            AdminAppUsers = result.Data!;

    //            await GetAppUsers();
    //            OnChange?.Invoke();
    //        }
    //    }
    //    catch (HttpRequestException ex)
    //    {
    //        HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
    //    }
    //}

    public async Task GetAdminAppUsers()
    {
        try
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<List<AppUserDto>>>($"{BaseURL}admin");
            if (response != null && response.Success)
            {
                AdminAppUsers = response.Data!;
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }

    public async Task GetAppUsers()
    {
        try
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<List<AppUserDto>>>($"{BaseURL}");

            if (response != null && response.Success)
            {
                AppUsers = response.Data!;
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }

    public async Task<AppUserDto?> GetAppUserByUserId(string userId)
    {
        try
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<AppUserDto>>($"{BaseURL}user?user={userId}");

            if (response != null && response.Success)
            {
                return response.Data!;
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
        return null;
    }

    public async Task<AppUserDto?> GetAppUserByEmail(string email)
    {
        try
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<AppUserDto>>($"{BaseURL}email?email={email}");

            if (response != null && response.Success)
            {
                return response.Data!;
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
        return null;
    }

    public async Task UpdateAppUser(AppUserDto item)
    {
        try
        {
            var response = await _http.PutAsJsonAsync($"{BaseURL}admin", item);
            var result = (await response.Content
                .ReadFromJsonAsync<ApiResponse<List<AppUserDto>>>());

            if (result != null && result.Success)
            {
                AdminAppUsers = result.Data!;

                await GetAppUsers();
                OnChange?.Invoke();
            }
        }
        catch (HttpRequestException ex)
        {
            HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
        }
    }
}
