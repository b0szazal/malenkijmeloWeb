using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalenkijMelo.Share.Dtos
{
    public class AdminActionDto
    {
        public string Id { get; set; } = Guid.Empty.ToString();

        public string ActionType { get; set; } = "";

        public string ActionDescription { get; set; } = "";

        public DateTime ActionDate { get; set; } = DateTime.Now;

        public string AdminId { get; set; } = string.Concat("a", Guid.Empty);

        public string AffectedId { get; set; } = string.Concat("d", Guid.Empty);
    }
}
