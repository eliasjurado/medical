using Medical.Domain.Dto.Auth;
using Medical.Domain.Dto.Response.Concrete;
using Medical.Domain.Dto.User;

namespace Medical.UI.Services.AuthService
{
    public interface IAuthService
    {
        Task<ApiResponse<string>> Register(UserRegister request);
        Task<ApiResponse<AuthResponseDto>> Login(UserLogin request);
        Task<string> RefreshToken();
        Task<bool> IsUserAuthenticated();
    }
}
