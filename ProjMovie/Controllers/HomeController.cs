using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjMovie.Data;

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
            var model = await movieRepository.GetMovie();
            return View(model);
        }
    }
}
