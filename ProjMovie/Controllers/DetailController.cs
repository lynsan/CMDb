using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using ProjMovie.Data;
using ProjMovie.Models.DTO;
using ProjMovie.Models.ViewModels;

namespace ProjMovie.Controllers
{
    public class DetailController : Controller
    {
        private IMovieRepository movieRepository;
        public DetailController(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }
        public async Task<IActionResult> Index(string ID)
        {
            ViewData["Title"] = ID;
            MovieViewModel movieViewModel = new MovieViewModel();
            var movie = await movieRepository.GetMovie(ID);
            var rating = await movieRepository.GetRating(ID);
            movieViewModel.Movie = movie;
            movieViewModel.Ratings = rating;
            return View(movieViewModel);
        }
    }
    //TODO: hämta den specifika filmen man klickat på och lägga in den i detail page. Endpoint har ett id som matchar filmens id. Går det att plocka ut det?
}
