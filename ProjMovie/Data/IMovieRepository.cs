using ProjMovie.Models.DTO;
using ProjMovie.Models.ViewModels;
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
        Task<RatedMoviesDTO> GetRating(string movID);
        Task<List<MovieViewModel>> Search(string search);
    }
}
