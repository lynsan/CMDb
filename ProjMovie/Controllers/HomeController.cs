using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjMovie.Data;
using ProjMovie.Models.DTO;

namespace ProjMovie.Controllers
{
    public class HomeController : Controller
    {
        private IMovieRepository movieRepository;
        public HomeController(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        
        public async Task<IActionResult> Index()
        {
            var toplist = GetRatedMovies().Result;
            var model = await GetMovieList(toplist);
            return View(model);
        }

        private async Task<List<MovieDTO>> GetMovieList(List<RatedMoviesDTO> array)
        {
            List<MovieDTO> movList = new List<MovieDTO>();
            for (int i = 0; i < array.Count; i++)
            {
                var item = await movieRepository.GetMovie(array[i].ImdbId);
                movList.Add(item);
            }
            return movList;
        }

        private async Task<List<RatedMoviesDTO>> GetRatedMovies()
        {
            return await movieRepository.GetTopList();
        }
    }
}
