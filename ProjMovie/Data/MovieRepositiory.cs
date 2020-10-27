using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ProjMovie.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjMovie.Data
{
    public class MovieRepositiory : IMovieRepository
    {
        private string baseUrl;
        private string apiKey;

        public MovieRepositiory(IConfiguration configuration)
        {
            baseUrl = configuration.GetValue<string>("OMDbApi:BaseUrl");
            apiKey = configuration.GetValue<string>("OMDbApi:ApiKey");
        }

        public async Task<MovieDTO> GetMovie(string MovID)
        {
            
            using (HttpClient client = new HttpClient())
            {
                string endpoint = $"{baseUrl}?i={MovID}{apiKey}";
                var response = await client.GetAsync(endpoint, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<MovieDTO>(data);
                return result;
            }
        }
    }
}
