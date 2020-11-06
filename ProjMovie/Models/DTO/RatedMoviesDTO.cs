using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMovie.Models.DTO
{
    public class RatedMoviesDTO
    {
        public string ImdbId { get; set; }
        public int NumberOfLikes { get; set; }
        public int NumberOfDislikes { get; set; }
        public int Rating { get; set; }
    }
}
