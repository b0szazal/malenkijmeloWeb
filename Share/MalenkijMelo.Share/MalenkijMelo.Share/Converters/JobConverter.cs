using MalenkijMelo.Share.Dtos;
using MalenkijMelo.Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalenkijMelo.Share.Converters
{
    public static class JobConverter
    {
        public static JobDto ConvertToJobDto(this Job job)
        {
            return new JobDto()
            {
                JobId = job.Id,
                DateOfWork = job.DateOfWork,
                WorkplaceId = job.WorkplaceId,
                IsPaymentMoney = job.IsPaymentMoney,
                JobDescription = job.JobDescription,
                JobName = job.JobName,
                PaymentInHuf = job.PaymentInHuf,
            };
        }

        public static Job ConvertToJob(this JobDto jobDto) 
        {
            return new Job()
            {
                Id = jobDto.JobId,
                DateOfWork = jobDto.DateOfWork,
                WorkplaceId = jobDto.WorkplaceId,
                IsPaymentMoney = jobDto.IsPaymentMoney,
                JobDescription = jobDto.JobDescription,
                JobName = jobDto.JobName,
                PaymentInHuf = jobDto.PaymentInHuf,
            };
        }

        public static List<JobDto> ConvertListToJobDtos(this List<Job> jobs)
        {
            return jobs.Select(ConvertToJobDto).ToList();
        }

        public static List<Job> ConvertListToJobs(this List<JobDto> jobDtos) 
        {
            return jobDtos.Select(ConvertToJob).ToList();
        }
    }
}
