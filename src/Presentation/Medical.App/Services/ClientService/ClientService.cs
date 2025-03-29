using Medical.App.Utils;
using Medical.Domain.Dto.Person;
using Medical.Domain.Dto.Response.Concrete;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace Medical.App.Services.ClientService
{
    public class ClientService : IClientService
    {
        private readonly HttpClient _http;
        private const string BaseURL = "api/Client/";
        private readonly NavigationManager _navigationManager;
        private readonly NotificationService _notificationService;
        public ClientService(HttpClient http, NavigationManager navigationManager, NotificationService notificationService)
        {
            _http = http;
            _navigationManager = navigationManager;
            _notificationService = notificationService;
        }

        public List<ClientDto> Clients { get; set; } = new List<ClientDto>();
        public List<ClientDto> AdminClients { get; set; } = new List<ClientDto>();

        public event Action? OnChange;

        public async Task AddClient(ClientDto Client)
        {
            try
            {
                var response = await _http.PostAsJsonAsync($"{BaseURL}admin", Client);
                var result = (await response.Content
                    .ReadFromJsonAsync<ApiResponse<List<ClientDto>>>());

                if (result != null && result.Success)
                {
                    AdminClients = result.Data!;

                    await GetClients();
                    OnChange!.Invoke();
                }
            }
            catch (HttpRequestException ex)
            {
                HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
            }
        }

        public ClientDto CreateNewClient()
        {
            var newClientDto = new ClientDto { IsNew = true, Editing = true };
            AdminClients.Add(newClientDto);
            OnChange!.Invoke();
            return newClientDto;
        }

        public async Task DeleteClient(int itemId)
        {
            try
            {
                var response = await _http.DeleteAsync($"{BaseURL}admin/{itemId}");

                var result = (await response.Content
                   .ReadFromJsonAsync<ApiResponse<List<ClientDto>>>());

                if (result != null && result.Success)
                {
                    AdminClients = result.Data!;

                    await GetClients();
                    OnChange!.Invoke();
                }
            }
            catch (HttpRequestException ex)
            {
                HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
            }
        }

        public async Task GetAdminClients()
        {
            try
            {
                var response = await _http.GetFromJsonAsync<ApiResponse<List<ClientDto>>>($"{BaseURL}admin");
                if (response != null && response.Success)
                {
                    AdminClients = response.Data!;
                }
            }
            catch (HttpRequestException ex)
            {
                HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
            }
        }

        public async Task GetClients()
        {
            try
            {
                var response = await _http.GetFromJsonAsync<ApiResponse<List<ClientDto>>>($"{BaseURL}");

                if (response != null && response.Success)
                {
                    Clients = response.Data!;
                }
            }
            catch (HttpRequestException ex)
            {
                HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
            }            
        }

        public async Task<ClientDto?> GetClientByFullName(string fullName)
        {
            try
            {
                var response = await _http.GetFromJsonAsync<ApiResponse<ClientDto>>($"{BaseURL}name?name={fullName}");

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
        public async Task UpdateClient(ClientDto item)
        {
            try
            {
                var response = await _http.PutAsJsonAsync($"{BaseURL}admin", item);
                var result = (await response.Content
                    .ReadFromJsonAsync<ApiResponse<List<ClientDto>>>());

                if (result != null && result.Success)
                {
                    AdminClients = result.Data!;

                    await GetClients();
                    OnChange!.Invoke();
                }
            }
            catch (HttpRequestException ex)
            {
                HttpHelpers.HandleRequestException(ex, _navigationManager, _notificationService);
            }
        }
    }
}
