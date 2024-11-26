using Medical.Domain.Dto.User;
using System.Threading.Tasks;

namespace Medical.Web.Client.Services.UserService
{
    public interface IUserService
    {
        Task<ApiResponse<string>> ChangePassword(UserChangePassword request);
    }
}
