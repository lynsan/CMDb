using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMovie.Models.DTO
{
    public class SearchDTO
    {
        public MovieDTO[] Search { get; set; }
        public string totalResults { get; set; }
        public string Response { get; set; }

    }
}
