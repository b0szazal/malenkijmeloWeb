using MalenkijMelo.Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalenkijMelo.Share.Dtos
{
    public class UserJobActionDto
    {
        public string UserId { get; set; } = string.Concat("d", Guid.Empty.ToString());
        public string JobId { get; set; } = Guid.Empty.ToString();
        public DateTime DateOfApplication { get; set; } = DateTime.Now;

        public string Id { get; set; } = "0";
    }
}
