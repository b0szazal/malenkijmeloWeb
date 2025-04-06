using MalenkijMelo.Services.Base;
using MalenkijMelo.Services.IHttpClientServices;
using MalenkijMelo.Share.Assemblers;
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
    public class AdminActionHttpClientService : HttpClientServiceBase<AdminAction, AdminActionDto>, IAdminActionHttpClientService
    {
        public AdminActionHttpClientService(AdminActionAssembler? assembler) : base(assembler)
        {
        }

        public async Task<List<AdminAction>> GetNotifications()
        {
            try
            {
                List<AdminAction> adminActions = await _httpClient.GetFromJsonAsync<List<AdminAction>>("api/AdminAction/GetNotifications") ?? new();
                return adminActions;
            }
            catch (Exception)
            {
                return new();
            }
        }
    }
}
