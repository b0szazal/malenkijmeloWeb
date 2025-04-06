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
    public class JobHttpClientService : HttpClientServiceBase<Job, JobDto>, IJobHttpClientService
    {
        private JobAssembler _jobAssembler;
        public JobHttpClientService(JobAssembler? assembler) : base(assembler)
        {
            _jobAssembler = assembler ?? throw new ArgumentNullException(nameof(assembler));
        }

        public async Task<Job[]> GetJobs(int page)
        {
            try
            {
                Job[] jobs = await _httpClient.GetFromJsonAsync<Job[]>("api/Job/GetJobs?page=" + page) ?? [];
                return jobs;
            }
            catch (Exception)
            {
                return [];
            }
        }

        public async Task<int> GetNumberOfJobs()
        {
            try
            {
                int eredmeny = await _httpClient.GetFromJsonAsync<int>("api/Job/getNumberOfJobs");
                return eredmeny;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
