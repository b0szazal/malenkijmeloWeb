using MalenkijMelo.Share.Models;
using MalenkijMelo.Share.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalenkijMelo.Services.Base
{
    public interface IHttpClientServiceBase<TModel, TDto>
        where TModel : class, IDbEntity<TModel> ,new()
        where TDto : class, new()
    {
        Task<List<TDto>> GetAsync();
        Task<ControllerResponse> PostAsync(TModel data);
        Task<ControllerResponse> PutAsync(TModel data);
        Task<ControllerResponse> DeleteAsync(string guid);
        Task<TModel> GetByIdAsync(string guid);
    }
}
