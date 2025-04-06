using MalenkijMelo.Services.Base;
using MalenkijMelo.Share.Dtos;
using MalenkijMelo.Share.Models;
using MalenkijMelo.Share.Models.Responses;

namespace MalenkijMelo.Services.IHttpClientServices
{
    public interface IUserAuthHttpClientService : IHttpClientServiceBase<User, UserDto>
    {
        Task<string> UserLoginAsync(string email, string password);
        Task<ControllerResponse> UserRegisterAsync(User user);
    }
}
