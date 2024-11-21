using Medical.Domain.Dto.Auth;
using Medical.Domain.Dto.User;
using System.Threading.Tasks;

namespace Medical.Web.Client.Services.AuthService
{
    public interface IAuthService
    {
        Task<ApiResponse<string>> Register(UserRegister request);
        Task<ApiResponse<AuthResponseDto>> Login(UserLogin request);
        Task<string> RefreshToken();
        Task<bool> IsUserAuthenticated();
    }
}
