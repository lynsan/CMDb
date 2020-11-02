using ProjMovie.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMovie.Data
{
    public interface IMovieRepository
    {
        Task<MovieDTO> GetMovie(string movID);
        Task<List<RatedMoviesDTO>> GetTopList();
        Task<RatedMoviesDTO> Rate(string movID, bool rating);
    }
}
