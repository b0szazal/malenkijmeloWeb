using MalenkijMelo.Services.Base;
using MalenkijMelo.Share.Dtos;
using MalenkijMelo.Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalenkijMelo.Services.IHttpClientServices
{
    public interface IUserHttpClientService : IHttpClientServiceBase<User, UserDto>
    {
        public Task<List<UserDto>> GetEmployeesAsync();
        public Task<int> GetNumberOfEmployeesAsync();
        public Task<List<UserDto>> GetEmployersAsync();
        public Task<int> GetNumberOfEmployersAsync();
        public Task<List<User>> GetAdmins();
        Task<User> GetUserByEmailAsync(string email);
    }
}
