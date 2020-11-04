using ProjMovie.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMovie.Models.ViewModels
{
    public class MovieViewModel
    {
        public MovieDTO Movie { get; set; }
        public RatedMoviesDTO Ratings { get; set; }
    }
}
