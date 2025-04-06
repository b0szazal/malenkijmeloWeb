using MalenkijMelo.Share.Converters;
using MalenkijMelo.Share.Dtos;
using MalenkijMelo.Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalenkijMelo.Share.Assemblers
{
    public class RatingAssembler : Assembler<Rating, RatingDto>
    {
        public override RatingDto ConvertToDto(Rating model)
        {
            return model.ConvertToRatingDto();
        }

        public override Rating ConvertToModel(RatingDto dto)
        {
            return dto.ConvertToRating();
        }
    }
}
