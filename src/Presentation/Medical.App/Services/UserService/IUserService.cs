using Medical.Domain.Dto.Response.Concrete;
using Medical.Domain.Dto.User;

namespace Medical.App.Services.UserService
{
    public interface IUserService
    {
        Task<ApiResponse<string>> ChangePassword(UserChangePassword request);
    }
}
