﻿using Microsoft.AspNetCore.Components.Forms;
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

        /// <summary>
        /// Hämtar en film av ett visst id från OMDb
        /// </summary>
        /// <param name="movID"></param>
        /// <returns></returns>
        public async Task<MovieDTO> GetMovie(string movID)
        {
            EndPoint = $"{baseUrl}?i={movID}&plot=full{apiKey}";
            var result = await ApiRequest<MovieDTO>();
            var obj = BreakOutPlots(result);
            return (MovieDTO)obj;
        }

        /// <summary>
        /// Hämtar top 4 filmer från CMDb
        /// </summary>
        /// <returns></returns>
        public async Task<List<RatedMoviesDTO>> GetTopList()
        {
            EndPoint = $"{baseUrl2}toplist?type=rating&sort=desc&count=4";
            var result = await ApiRequest<List<RatedMoviesDTO>>();
            return result;
        }

        /// <summary>
        /// Ger en rating och returnerar filmen med uppdaterade ratings. True = like, false = dislike
        /// </summary>
        /// <param name="movID"></param>
        /// <returns></returns>
        public async Task<RatedMoviesDTO> Rate(string movID, bool rating)
        {
            if (rating)
            {
                EndPoint = $"{baseUrl2}movie/{movID}/like";
            }
            else
            {
                EndPoint = $"{baseUrl2}movie/{movID}/dislike";
            }
            await ApiRequest<RatedMoviesDTO>();
            EndPoint = $"{baseUrl2}movie/{movID}";
            var result = await ApiRequest<RatedMoviesDTO>();
            return result;
        }

        /// <summary>
        /// Generisk metod för att göra api-anrop
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private async Task<T> ApiRequest<T>()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(EndPoint, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<T>(data);
                return result;
            }
        }

        /// <summary>
        /// Delar upp movie plot till två delar. En kort och en lång
        /// </summary>
        /// <param name="movieDTO"></param>
        /// <returns></returns>
        private object BreakOutPlots(MovieDTO movieDTO)
        {
            string plot = movieDTO.Plot;
            movieDTO.Short = plot.Substring(0, 50);
            movieDTO.Full = plot.Substring(50);
            return movieDTO;
        }

    }
}
