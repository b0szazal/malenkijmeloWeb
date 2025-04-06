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
    public class UserJobActionHttpClientService : HttpClientServiceBase<UserJobAction, UserJobActionDto>, IUserJobActionHttpClientService
    {
        public UserJobActionHttpClientService(UserJobActionAssembler? assembler) : base(assembler)
        {
        }

        public async Task<int> GetNumberOfApplicants(string jobId)
        {
            try
            {
                int? numberOfApplicants = await _httpClient.GetFromJsonAsync<int>("/api/UserJobAction/GetNumberOfApplicants?jobId=" + jobId);
                return numberOfApplicants ?? 0;
            }
            catch
            {
                return -1;
            }
        }

        public async Task<UserJobActionDto> GetUserJobActionByBothJobAndUserIds(string jobId, string userId)
        {
            try
            {
                UserJobActionDto? userJobActionDto = await _httpClient.GetFromJsonAsync<UserJobActionDto>($"/api/UserJobAction/GetSignleUJA?jobId={jobId}&userId={userId}");
                return userJobActionDto ?? new();
            }
            catch
            {
                return new();
            }
        }

        public async Task<UserJobActionDto> GetPublisher(string jobId)
        {
            try
            {
                UserJobActionDto? userJobActionDto = await _httpClient.GetFromJsonAsync<UserJobActionDto>($"/api/UserJobAction/GetPublisher?jobId={jobId}");
                return userJobActionDto ?? new();
            }
            catch
            {
                return new();
            }
        }

        public async Task<List<UserJobActionDto>> GetUserJobActionsByUserId(string userId)
        {
            try
            {
                List<UserJobActionDto>? userJobActionDtos = await _httpClient.GetFromJsonAsync<List<UserJobActionDto>>($"api/UserJobAction/GetByUserId?userId={userId}");
                return userJobActionDtos ?? new();
            }
            catch
            {
                return new();
            }
        }

        public async Task<List<UserJobAction>> GetApplicants(string jobId)
        {
            try
            {
                List<UserJobAction> userJobActions = await _httpClient.GetFromJsonAsync<List<UserJobAction>>($"/api/UserJobAction/GetApplicants?jobId={jobId}") ?? new();
                return userJobActions;
            }
            catch
            {
                return new();
            }
        }
    }
}
