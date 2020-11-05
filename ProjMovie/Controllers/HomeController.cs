using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjMovie.Data;
using ProjMovie.Models.DTO;
using ProjMovie.Models.ViewModels;

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
            var toplist = await movieRepository.GetTopList(); 
            var model = await GetMovieList(toplist);
            return View(model);
        }

        /// <summary>
        /// Hämtar en lista av MovieViewModels baserat på en lista av RatedMoviesDTOs
        /// </summary>
        /// <param name="ratedMoviesList"></param>
        /// <returns></returns>
        private async Task<List<MovieViewModel>> GetMovieList(List<RatedMoviesDTO> ratedMoviesList)
        {
            List<MovieViewModel> movList = new List<MovieViewModel>();
            for (int i = 0; i < ratedMoviesList.Count; i++)
            {
                MovieViewModel homeViewModel = new MovieViewModel();
                var movie = await movieRepository.GetMovie(ratedMoviesList[i].ImdbId);
                homeViewModel.Movie = movie;
                var rating = await movieRepository.GetRating(ratedMoviesList[i].ImdbId);
                homeViewModel.Ratings = rating;
                movList.Add(homeViewModel);
            }
            return movList;
        }
    }
}
