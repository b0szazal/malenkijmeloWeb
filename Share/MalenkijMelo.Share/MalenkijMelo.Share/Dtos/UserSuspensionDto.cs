using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalenkijMelo.Share.Dtos
{
    public class UserSuspensionDto
    {
        public string UserId { get; set; } = string.Concat("d", Guid.Empty);
        public DateTime SuspensionEndDate { get; set; } = DateTime.Now;
        public string SuspendedByAdminId { get; set; } = string.Concat("a", Guid.Empty);
        public string Id { get; set; } = Guid.Empty.ToString();
    }
}
