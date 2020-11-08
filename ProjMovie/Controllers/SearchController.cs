using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjMovie.Data;
using ProjMovie.Models.ViewModels;

namespace ProjMovie.Controllers
{
    public class SearchController : Controller
    {
        private IMovieRepository movieRepository;
        public SearchController(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public async Task<IActionResult> Index(string id)
        {
            var model = await movieRepository.Search(id);
            return View(model);
        }
    }
}
