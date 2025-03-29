using Medical.Domain.Dto.Person;

namespace Medical.App.Services.ClientService
{
    public interface IClientService
    {
        event Action OnChange;
        List<ClientDto> Clients { get; set; }
        List<ClientDto> AdminClients { get; set; }
        Task GetClients();
        Task<ClientDto?> GetClientByFullName(string fullName);
        Task GetAdminClients();
        Task AddClient(ClientDto item);
        Task UpdateClient(ClientDto item);
        Task DeleteClient(int itemId);
        ClientDto CreateNewClient();
    }
}
