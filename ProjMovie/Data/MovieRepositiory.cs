using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ProjMovie.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjMovie.Data
{
    public class MovieRepositiory : IMovieRepository
    {
        private string baseUrl;
        private string apiKey;
        private string baseUrl2;
        private string EndPoint;

        public MovieRepositiory(IConfiguration configuration)
        {
            baseUrl = configuration.GetValue<string>("OMDbApi:BaseUrl");
            apiKey = configuration.GetValue<string>("OMDbApi:ApiKey");
            baseUrl2 = configuration.GetValue<string>("CMDbApi:BaseUrl2");
        }

        //public async Task<MovieDTO> GetMovie(string movID)
        //{
        //    EndPoint = $"{baseUrl}?i={movID}&plot=full{apiKey}";
        //    var result = await ApiRequest();
        //    return result;
        //}

        //public async Task<List<RatedMoviesDTO>> GetTopList()
        //{
        //    EndPoint = $"{baseUrl2}toplist?type=popularity&sort=desc&count=4";
        //    var result = await ApiRequest();
        //    return result;
        //}

        public async Task<MovieDTO> GetMovie(string movID)
        {
            
            using (HttpClient client = new HttpClient())
            {
                string endpoint = $"{baseUrl}?i={movID}&plot=full{apiKey}";
                var response = await client.GetAsync(endpoint, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();
                var result = BreakOutPlots(JsonConvert.DeserializeObject<MovieDTO>(data));
                return (MovieDTO)result;
            }
        }
        public async Task<List<RatedMoviesDTO>> GetTopList()
        {
            //TODO: Dont repeat yourself
            using (HttpClient client = new HttpClient())
            {
                string endpoint = $"{baseUrl2}toplist?type=popularity&sort=desc&count=4";
                var response = await client.GetAsync(endpoint, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();
                var myobjList = JsonConvert.DeserializeObject<List<RatedMoviesDTO>>(data);
                return myobjList;
            }
        }

        private object BreakOutPlots(MovieDTO movieDTO)
        {
            //Delar upp plot till två delar.
            string plot = movieDTO.Plot;
            movieDTO.Short = plot.Substring(0, 50);
            movieDTO.Full = plot.Substring(50);
            return movieDTO;
        }

    }
}
