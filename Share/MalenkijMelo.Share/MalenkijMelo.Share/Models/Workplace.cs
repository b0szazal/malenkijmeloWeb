using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalenkijMelo.Share.Models
{
    public class Workplace : IDbEntity<Workplace>
    {
        public Workplace()
        {
        }
        public Workplace(Guid name, string description)
        {
            Id = name.ToString();
            PlaceName = description;
        }
        public string Id { get; set; } = Guid.Empty.ToString();
        public string PlaceName { get; set; } = string.Empty;
    }
}
