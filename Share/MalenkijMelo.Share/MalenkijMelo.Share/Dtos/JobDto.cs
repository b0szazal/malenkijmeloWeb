using MalenkijMelo.Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalenkijMelo.Share.Dtos
{
    public class JobDto
    {
        public string JobId { get; set; } = Guid.Empty.ToString();
        public string JobName { get; set; } = string.Empty;
        public string WorkplaceId { get; set; } = Guid.Empty.ToString();
        public string JobDescription { get; set; } = string.Empty;
        public DateTime DateOfWork { get; set; } = DateTime.Now;
        public bool IsPaymentMoney { get; set; } = true;
        public double PaymentInHuf { get; set; } = 0;
        public override string? ToString()
        {
            return JobName + " "+ JobDescription;
        }
    }
}
