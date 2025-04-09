using Medical.Domain.Dto.User;

namespace Medical.App.Services.AppUserService;

public interface IAppUserService
{
    event Action OnChange;
    List<AppUserDto> AppUsers { get; set; }
    List<AppUserDto> AdminAppUsers { get; set; }
    Task GetAppUsers();
    Task<AppUserDto?> GetAppUserByUserId(string user);
    Task<AppUserDto?> GetAppUserByEmail(string email);
    Task GetAdminAppUsers();
    Task AddAppUser(AppUserDto item);
    Task UpdateAppUser(AppUserDto item);
    //Task DeleteAppUser(int itemId);
    AppUserDto CreateNewAppUser();
}
