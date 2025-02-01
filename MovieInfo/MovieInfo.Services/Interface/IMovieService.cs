using MovieInfo.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieInfo.Services.Interface
{
    public interface IMovieService
    {
        Task<List<int>> GetYears();
        Task<List<Movie>> GetAsync(string title, int year);
    }
}
