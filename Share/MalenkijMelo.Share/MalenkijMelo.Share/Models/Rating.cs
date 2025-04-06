using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalenkijMelo.Share.Models
{
    public class Rating : IDbEntity<Rating>
    {
        public Rating()
        {
            Id = Guid.NewGuid().ToString();
            Value = 0;
        }

        public Rating(string id, string ratingText, double value, string raterID, string ratedID)
        {
            Id = id;
            RatingText = ratingText;
            Value = value;
            RaterID = raterID;
            RatedID = ratedID;
        }

        public string Id { get; set; } = Guid.Empty.ToString();
        public string RatingText { get; set; } = string.Empty;
        public double Value { get; set; }

        public string RaterID { get; set; } = string.Concat("d", Guid.Empty.ToString());
        public string RatedID { get; set; } = string.Concat("d" ,Guid.Empty.ToString());

        public static double CalculateRatingAvg(List<Rating> ratings)
        {
            double sum = 0;
            foreach (var rating in ratings)
            {
                sum += rating.Value;
            }
            return sum / ratings.Count;
        }
    }
}
