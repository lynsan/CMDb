﻿using Microsoft.Extensions.Configuration;
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
        private string baseUrl2;

        public MovieRepositiory(IConfiguration configuration)
        {
            baseUrl = configuration.GetValue<string>("OMDbApi:BaseUrl");
            apiKey = configuration.GetValue<string>("OMDbApi:ApiKey");
            baseUrl2 = configuration.GetValue<string>("CMDbApi:BaseUrl2");
        }

        public async Task<MovieDTO> GetMovie(string movID)
        {
            
            using (HttpClient client = new HttpClient())
            {
                string endpoint = $"{baseUrl}?i={movID}{apiKey}";
                var response = await client.GetAsync(endpoint, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<MovieDTO>(data);
                return result;
            }
        }

        //public async Task<MovieRatingsDTO> GetMovieRatings(string imdbId)
        //{

        //    using (HttpClient client = new HttpClient())
        //    {
        //        string endpoint = $"{baseUrl2}?i={imdbId}";
        //        var response = await client.GetAsync(endpoint, HttpCompletionOption.ResponseHeadersRead);
        //        response.EnsureSuccessStatusCode();
        //        var data = await response.Content.ReadAsStringAsync();
        //        var result = JsonConvert.DeserializeObject<MovieRatingsDTO>(data);
        //        return result;
        //    }
        //}
    }
}