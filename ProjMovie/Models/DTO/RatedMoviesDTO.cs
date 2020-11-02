using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMovie.Models.DTO
{
    public class RatedMoviesDTO
    {
        public string ImdbId { get; set; }
        public string NumberOfLikes { get; set; }
        public string NumberOfDislikes { get; set; }
    }
}
