using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalenkijMelo.Share.Models
{
    public class Job : IDbEntity<Job>
    {
        public Job(Guid jobId,
            string jobName,
            string jobDescription,
            bool isPaymentMoney,
            DateTime dateOfWork,
            Guid placeId,
            double paymentInHuf)
        {
            Id =jobId.ToString();
            JobName = jobName;
            JobDescription = jobDescription;
            DateOfWork = dateOfWork;
            IsPaymentMoney = isPaymentMoney;
            PaymentInHuf = paymentInHuf;
            WorkplaceId = placeId.ToString();
        }

        public Job()
        {
        }

        public string Id { get; set; } = Guid.Empty.ToString();
        public string JobName {  get; set; } = string.Empty;
        public string WorkplaceId { get; set; } = Guid.Empty.ToString();
        public string JobDescription { get; set; } = string.Empty;
        public DateTime DateOfWork { get; set; } = DateTime.Now;
        public bool IsActive => DateOfWork > System.DateTime.Now;
        public bool IsPaymentMoney { get; set; } = true;
        public double PaymentInHuf { get; set; } = 0;
    }
}
