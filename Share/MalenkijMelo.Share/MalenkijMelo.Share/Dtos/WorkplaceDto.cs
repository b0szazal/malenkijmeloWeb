using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalenkijMelo.Share.Dtos
{
    public class WorkplaceDto
    {
        public string PlaceId { get; set; } = Guid.Empty.ToString();
        public string PlaceName { get; set; } = string.Empty;
    }
}
