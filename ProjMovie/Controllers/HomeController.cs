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
            var model = await GetMovieList(GetRatedMovies());
            return View(model);
        }

        private async Task<List<MovieDTO>> GetMovieList(String[] array)
        {
            List<MovieDTO> movList = new List<MovieDTO>();
            for (int i = 0; i < array.Length; i++)
            {
                var item = await movieRepository.GetMovie(array[i]);
                movList.Add(item);
            }
            return movList;
        }

        private string[] GetRatedMovies()
        {
            //TODO: Hämta topp tre id från CMDb
            string[] mock = {"tt3731562", "tt10048342", "tt12298506", "tt1735898"};
            return mock;
        }
    }
}
