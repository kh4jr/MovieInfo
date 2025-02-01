using Microsoft.EntityFrameworkCore;
using MovieInfo.Repositories.Interfaces;
using MovieInfo.Repositories.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieInfo.Repositories.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DataContext _context;
        private readonly DbSet<Movie> _dbSet;

        public MovieRepository(DataContext context)
        {
            _context = context;
            _dbSet = context.Set<Movie>();
        }

        public async Task<Movie> CreateAsunc(Movie movie)
        {
            var result = await _context.Set<Movie>().AddAsync(movie);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<List<Movie>> GetByTitleAndYearAsync(string title, int year)
        {
            var result = await _dbSet
                .Where(c => c.Title.StartsWith(title) && c.ReleaseYear == year)
                .ToListAsync();

            return result;
        }

        public async Task<List<Movie>> GetByTitleAsync(string title)
        {
            var result = await _dbSet
                .Where(c => c.Title.StartsWith(title))
                .ToListAsync();

            return result;
        }

        public async Task<List<Movie>> GetByYearAsync(int year)
        {
            var result = await _dbSet
                .AsNoTracking()
                .Where(m => m.ReleaseYear == year)
                .ToListAsync();

            return result;
        }

        public async Task<List<int>> GetYearAsync()
        {
            return await _dbSet
                .Select(m => m.ReleaseYear)
                .Distinct()
                .OrderByDescending(y => y)
                .ToListAsync();
        }
    }
}
