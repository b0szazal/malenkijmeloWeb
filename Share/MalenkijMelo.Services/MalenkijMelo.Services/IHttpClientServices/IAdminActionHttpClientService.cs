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
    public interface IAdminActionHttpClientService : IHttpClientServiceBase<AdminAction, AdminActionDto>
    {
        Task<List<AdminAction>> GetNotifications();
    }
}
