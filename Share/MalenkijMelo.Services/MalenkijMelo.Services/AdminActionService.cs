using MalenkijMelo.Services.Base;
using MalenkijMelo.Services.IHttpClientServices;
using MalenkijMelo.Share.Assemblers;
using MalenkijMelo.Share.Dtos;
using MalenkijMelo.Share.Models;
using MalenkijMelo.Share.Models.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MalenkijMelo.Services
{
    public class AdminActionService : HttpClientServiceBase<AdminAction, AdminActionDto>, IAdminActionService
    {
        private AdminActionAssembler _adminActionAssembler;

        public AdminActionService(AdminActionAssembler? assembler) : base(assembler)
        {
            _adminActionAssembler = assembler ?? throw new ArgumentNullException(nameof(assembler));
        }
        public async Task<ControllerResponse> SuspendUserAsync(string adminId, string userId, int days)
        {
            ControllerResponse response = new();
            try
            {
                var request = new
                {
                    AdminId = adminId,
                    UserId = userId,
                    Days = days
                };

                HttpResponseMessage res = await _httpClient.PostAsJsonAsync("api/AdminAction/suspend", request);
                Debug.WriteLine(res.StatusCode);
                string text = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<ControllerResponse>(text) ?? new();

                if (!res.IsSuccessStatusCode)
                {
                    return response;
                }
                else
                {
                    return response!;
                }
            }
            catch (Exception e)
            {
            }
            return response;
        }
    }
}
