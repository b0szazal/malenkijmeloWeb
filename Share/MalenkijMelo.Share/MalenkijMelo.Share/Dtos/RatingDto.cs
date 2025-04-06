using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalenkijMelo.Share.Dtos
{
    public class RatingDto
    {

        public string RatingId { get; set; } = Guid.Empty.ToString();
        public string RatingText { get; set; } = string.Empty;
        public double Value { get; set; }

        public string RaterID { get; set; } = string.Concat("d", Guid.Empty.ToString());
        public string RatedID { get; set; } = string.Concat("d", Guid.Empty.ToString());
    }
}
