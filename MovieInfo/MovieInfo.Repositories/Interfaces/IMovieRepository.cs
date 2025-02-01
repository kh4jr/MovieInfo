using MovieInfo.Repositories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieInfo.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetByTitleAndYearAsync(string title, int year);
        Task<List<Movie>> GetByTitleAsync(string title);
        Task<List<Movie>> GetByYearAsync(int year);
        Task<Movie> CreateAsunc(Movie movie);
        Task<List<int>> GetYearAsync();
    }
}
