using MalenkijMelo.Services.Base;
using MalenkijMelo.Share.Dtos;
using MalenkijMelo.Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalenkijMelo.Services.IHttpClientServices
{
    public interface IRatingHttpClientService : IHttpClientServiceBase<Rating, RatingDto>
    {
        Task<double> GetUserRatingAvg(string userId);

        Task<Rating> GetRatingByRaterAndRatedId(string raterId, string ratedId);
    }
}
