using MalenkijMelo.Share.Assemblers;
using MalenkijMelo.Share.Models;
using MalenkijMelo.Share.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MalenkijMelo.Services.Base
{
    public class HttpClientServiceBase<TModel, TDto> : IHttpClientServiceBase<TModel, TDto>
            where TModel : class, IDbEntity<TModel>, new()
            where TDto : class, new()
    {
        protected readonly HttpClient _httpClient;
        protected Assembler<TModel, TDto> _assembler;

        public HttpClientServiceBase(Assembler<TModel, TDto>? assembler)
        {
            _httpClient = new HttpClient();
            bool test = false;
            if (test)
            {
                _httpClient.BaseAddress = new Uri("https://localhost:7020");
            }
            else
            {
                _httpClient.BaseAddress = new Uri("https://malenkijmelobackend-hxfzhdh3ggaye8de.germanywestcentral-01.azurewebsites.net/");
            }
            _assembler = assembler ?? throw new ArgumentNullException(nameof(assembler) + " was null");
        }

        public HttpClientServiceBase(IHttpClientFactory? httpClientFactory, Assembler<TModel, TDto>? assembler)
        {
            if (httpClientFactory == null)
            {
                throw new ArgumentNullException(nameof(httpClientFactory) + " was null");
            }
            _httpClient = httpClientFactory.CreateClient("MalenkijMeloApi");
            _assembler = assembler ?? throw new ArgumentNullException(nameof(assembler) + " was null");
        }


        public async Task<List<TDto>> GetAsync()
        {
            try
            {
                List<TDto>? dtos = await _httpClient.GetFromJsonAsync<List<TDto>>("api/" + typeof(TModel).Name);
                if (dtos is null)
                {
                    throw new Exception("No data found");
                }
                return dtos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            throw new Exception($"{nameof(GetAsync)} failed");
        }

        public async Task<ControllerResponse> DeleteAsync(string guid)
        {
            ControllerResponse defaultRespnse=new ControllerResponse();
            try
            {
                var response = await _httpClient.DeleteAsync($"api/{typeof(TModel).Name}/{guid}");

                if (response.IsSuccessStatusCode)
                {
                    return defaultRespnse;
                }
                else
                {

                    string text =await response.Content.ReadAsStringAsync();
                    ControllerResponse? response1 =JsonConvert.DeserializeObject<ControllerResponse>(text);
                    if (response1 is null)
                    {
                        defaultRespnse.AppendError("Hiba történt törlés során");
                    }
                    else
                    {
                        return response1;
                    }
                }
            }
            catch (Exception ex)
            {
                defaultRespnse.AppendError(ex.Message);
             
            }
            return defaultRespnse;
        }

        public async Task<TModel> GetByIdAsync(string guid)
        {
            try
            {
                TDto? result = await _httpClient.GetFromJsonAsync<TDto>($"api/{typeof(TModel).Name}/{guid}");
                if (result is not null)
                {
                    return _assembler.ConvertToModel(result);
                }
            }
            catch (Exception)
            {
            }
            return new TModel();
        }

        public async Task<ControllerResponse> PostAsync(TModel data)
        {
            ControllerResponse defaultResponse = new();
            try
            {
                var response = await _httpClient.PostAsJsonAsync<TDto>($"api/{typeof(TModel).Name}", _assembler.ConvertToDto(data));
                if (response.IsSuccessStatusCode)
                {
                    return defaultResponse;
                }
                else
                {
                    string text = await response.Content.ReadAsStringAsync();
                    ControllerResponse? newResponse = JsonConvert.DeserializeObject<ControllerResponse>(text);

                    if(newResponse is null)
                    {
                        defaultResponse.AppendError($"Hiba! Nem tudtuk létrehozni: {nameof(TModel)}");
                    }
                    else
                    {
                        return newResponse;
                    }
                }
            }
            catch(Exception e)
            {
                defaultResponse.AppendError(e.Message);
            }

            return defaultResponse;
        }

        public async Task<ControllerResponse> PutAsync(TModel data)
        {
            ControllerResponse defaultRespnse = new ControllerResponse();
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/{typeof(TModel).Name}", _assembler.ConvertToDto(data));

                if (response.IsSuccessStatusCode)
                {
                    return defaultRespnse;
                }
                else
                {

                    string text = await response.Content.ReadAsStringAsync();
                    ControllerResponse? response1 = JsonConvert.DeserializeObject<ControllerResponse>(text);
                    if (response1 is null)
                    {
                        defaultRespnse.AppendError("Hiba történt törlés során");
                    }
                    else
                    {
                        return response1;
                    }
                }
            }
            catch (Exception ex)
            {
                defaultRespnse.AppendError(ex.Message);

            }
            return defaultRespnse;
        }
    }
}
