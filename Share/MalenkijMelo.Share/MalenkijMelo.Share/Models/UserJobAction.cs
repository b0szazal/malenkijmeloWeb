using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalenkijMelo.Share.Models
{
    public class UserJobAction : IDbEntity<UserJobAction>
    {
        public UserJobAction()
        {
        }

        public UserJobAction(string appliedEmployeeId, string appliedJobId, DateTime dateOfApply)
        {
            UserId = appliedEmployeeId;
            JobId = appliedJobId;
            DateOfApplication = dateOfApply;
        }

        public string UserId { get; set; }= string.Concat("d", Guid.Empty.ToString());
        public string JobId { get; set; } = Guid.Empty.ToString();
        public DateTime DateOfApplication { get; set; } = DateTime.Now;
        public string Id { get; set; }= Guid.Empty.ToString();
    }
}
