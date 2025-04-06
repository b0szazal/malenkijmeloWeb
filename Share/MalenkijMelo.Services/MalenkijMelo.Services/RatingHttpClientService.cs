using MalenkijMelo.Services.Base;
using MalenkijMelo.Services.IHttpClientServices;
using MalenkijMelo.Share.Assemblers;
using MalenkijMelo.Share.Dtos;
using MalenkijMelo.Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MalenkijMelo.Services
{
    public class RatingHttpClientService : HttpClientServiceBase<Rating, RatingDto>, IRatingHttpClientService
    {
        public RatingHttpClientService(RatingAssembler assembler) : base(assembler)
        {
        }

        public async Task<Rating> GetRatingByRaterAndRatedId(string raterId, string ratedId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Rating>("api/Rating/GetRatingByRaterAndRatedId?raterId=" + raterId + "&ratedId=" + ratedId) ?? new();
            }
            catch
            {
                return new();
            }
        }

        public async Task<double> GetUserRatingAvg(string userId)
        {
            try
            {
                double res = await _httpClient.GetFromJsonAsync<double>("api/Rating/GetUserRatingsAverage?userId=" + userId);
                return res;
            }
            catch
            {
                return -1;
            }
        }
    }
}
