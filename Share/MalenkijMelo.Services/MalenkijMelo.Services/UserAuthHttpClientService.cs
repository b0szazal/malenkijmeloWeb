using MalenkijMelo.Services.IHttpClientServices;
using MalenkijMelo.Share.Models.Responses;
using MalenkijMelo.Share.Assemblers;
using MalenkijMelo.Share.Dtos;
using MalenkijMelo.Share.Models;
using MalenkijMelo.Services.Base;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace MalenkijMelo.Services
{
    public class UserAuthHttpClientService : HttpClientServiceBase<User, UserDto>, IUserAuthHttpClientService
    {
        public UserAuthHttpClientService(UserAssembler? assembler) : base(assembler)
        {
        }

        public async Task<string> UserLoginAsync(string email, string password)
        {
            string token = "";
            try
            {
                var response = await _httpClient.PostAsJsonAsync<UserDto>($"api/Auth/UserLogin?email={email}&password={password}", new UserDto { Email = email, Password = password });

                if (response.IsSuccessStatusCode)
                {
                    token = await response.Content.ReadAsStringAsync();
                }
            }
            catch(Exception)
            {
            }

            return token;
        }

        public async Task<ControllerResponse> UserRegisterAsync(User user)
        {
            ControllerResponse response = new();
            try
            {
                HttpResponseMessage res = await _httpClient.PostAsJsonAsync<UserDto>("api/Auth/UserRegister", _assembler.ConvertToDto(user));

                if (res.IsSuccessStatusCode)
                {
                    return response;
                }
                else
                {
                    ControllerResponse? newResponse = JsonConvert.DeserializeObject<ControllerResponse>(await res.Content.ReadAsStringAsync());
                    if(newResponse is not null)
                    {
                        return newResponse;
                    }
                    else
                    {
                        response.AppendError("Hiba!");
                    }
                }
            }
            catch(Exception e)
            {
                response.AppendError(e.Message);
            }

            return response;
        }
	}     
}
