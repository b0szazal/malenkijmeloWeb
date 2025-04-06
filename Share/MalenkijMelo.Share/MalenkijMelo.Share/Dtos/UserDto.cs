using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalenkijMelo.Share.Dtos
{
    public class UserDto
    {
        public string UserId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateTime SuspendedUntil { get; set; } = DateTime.Now;

        public DateTime AdminPermissionExpirationDate { get; set; }

        public byte AdminLevel { get; set; } = 0;

        public override string? ToString()
        {
            return $"{Name}: {SuspendedUntil}";
        }
    }
}
