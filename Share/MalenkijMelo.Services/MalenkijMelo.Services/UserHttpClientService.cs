using MalenkijMelo.Services.Base;
using MalenkijMelo.Services.IHttpClientServices;
using MalenkijMelo.Share.Assemblers;
using MalenkijMelo.Share.Converters;
using MalenkijMelo.Share.Dtos;
using MalenkijMelo.Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MalenkijMelo.Services
{
    public class UserHttpClientService : HttpClientServiceBase<User, UserDto>, IUserHttpClientService
    {
        private UserAssembler _userAssembler;
        public UserHttpClientService(UserAssembler? assembler) : base(assembler)
        {
            _userAssembler = assembler ?? throw new ArgumentNullException(nameof(assembler));
        }

        public async Task<List<UserDto>> GetEmployeesAsync()
        {
            try
            {
                List<UserDto>? employees = await _httpClient.GetFromJsonAsync<List<UserDto>>("api/User/getEmployees");
                return employees ?? new List<UserDto>();
            }
            catch (Exception)
            {
                return new List<UserDto>();
            }
        }

        public async Task<List<UserDto>> GetEmployersAsync()
        {
            try
            {
                List<UserDto>? employers = await _httpClient.GetFromJsonAsync<List<UserDto>>("api/User/getEmployers");
                return employers ?? new List<UserDto>();
            }
            catch (Exception)
            {
                return new List<UserDto>();
            }
        }

        public async Task<List<User>> GetAdmins()
        {
            try
            {
                List<User>? result = await _httpClient.GetFromJsonAsync<List<User>>("api/User/getAdmins");
                return result ?? new();

            }
            catch (Exception e)
            {
                return new();
            }
        }
        
        public async Task<User> GetUserByEmailAsync(string email)
        {
            try
            {
                User? employers = await _httpClient.GetFromJsonAsync<User>($"api/User/email={email}");
                return employers ?? new User();
            }
            catch (Exception)
            {
                return new User();
            }
        }

        public async Task<int> GetNumberOfEmployeesAsync()
        {
            try
            {
                int? numberOfEmployees = await _httpClient.GetFromJsonAsync<int>("api/User/getNumberOfEmployees");
                return numberOfEmployees ?? 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public async Task<int> GetNumberOfEmployersAsync()
        {
            try
            {
                int? numberOfEmployers = await _httpClient.GetFromJsonAsync<int>("api/User/getNumberOfEmployers");
                return numberOfEmployers ?? 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
