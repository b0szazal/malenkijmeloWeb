using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalenkijMelo.Share.Models
{
    public class AdminAction : IDbEntity<AdminAction>
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string ActionType { get; set; } = "";

        public string ActionDescription { get; set; } = "";

        public DateTime ActionDate { get; set; } = DateTime.Now;

        public string AdminId { get; set; } = string.Concat("d", Guid.Empty);

        public string AffectedId { get; set; } = string.Concat("d", Guid.Empty);

        public AdminAction()
        {
            
        }

        public AdminAction(string actionType, string actionDescription, DateTime actionDate, string adminId, string affectedId)
        {
            ActionType = actionType;
            ActionDescription = actionDescription;
            ActionDate = actionDate;
            AdminId = adminId;
            AffectedId = affectedId;
        }
    }
}
