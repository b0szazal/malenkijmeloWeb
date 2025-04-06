using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalenkijMelo.Share.Models
{
    public class UserSuspension : IDbEntity<UserSuspension>
    {
        public string UserId { get; set; }
        public DateTime SuspensionEndDate { get; set; }
        public string SuspendedByAdminId { get; set; }
        public string Id { get; set; } = Guid.NewGuid().ToString();

    }
}
