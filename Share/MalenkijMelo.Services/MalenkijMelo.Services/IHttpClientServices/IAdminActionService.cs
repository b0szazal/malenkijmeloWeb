using MalenkijMelo.Services.Base;
using MalenkijMelo.Share.Dtos;
using MalenkijMelo.Share.Models;
using MalenkijMelo.Share.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalenkijMelo.Services.IHttpClientServices
{
    public interface IAdminActionService : IHttpClientServiceBase<AdminAction, AdminActionDto>
    {
        public Task<ControllerResponse> SuspendUserAsync(string adminId, string userId, int days);
    }
}
