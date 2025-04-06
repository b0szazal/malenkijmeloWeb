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
    public interface IUserJobActionHttpClientService : IHttpClientServiceBase<UserJobAction, UserJobActionDto>
    {
        Task<int> GetNumberOfApplicants(string jobId);

        Task<UserJobActionDto> GetPublisher(string jobId);

        Task<List<UserJobActionDto>> GetUserJobActionsByUserId(string userId);

        Task<List<UserJobAction>> GetApplicants(string jobId);

        Task<UserJobActionDto> GetUserJobActionByBothJobAndUserIds(string jobId, string userId);
    }
}
