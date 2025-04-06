using MalenkijMelo.Share.Dtos;
using MalenkijMelo.Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalenkijMelo.Share.Converters
{
    public static class RatingConverter
    {
        public static RatingDto ConvertToRatingDto(this Rating rating)
        {
            return new RatingDto()
            {
                RatingId = rating.Id,
                RatingText = rating.RatingText,
                Value = rating.Value,
                RaterID = rating.RaterID,
                RatedID = rating.RatedID,
            };
        }

        public static Rating ConvertToRating(this RatingDto ratingDto)
        {
            return new Rating()
            {
                Id = ratingDto.RatingId,
                RatingText = ratingDto.RatingText,
                Value = ratingDto.Value,
                RaterID = ratingDto.RaterID,
                RatedID = ratingDto.RatedID,
            };
        }

        public static List<RatingDto> ConvertListToRatingDtos(this List<Rating> ratings)
        {
            return ratings.Select(ConvertToRatingDto).ToList();
        }

        public static List<Rating> ConvertListToRatings(this List<RatingDto> ratingDtos)
        {
            return ratingDtos.Select(ConvertToRating).ToList();
        }
    }
}
