using AutoMapper;
using MovieInfo.Entities;
using MovieInfo.Repositories.Interfaces;
using MovieInfo.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieInfo.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<List<Movie>> GetAsync(string title, int year)
        {
            var movieList = new List<Movie>();
            if (!string.IsNullOrEmpty(title) && year != 0)
            {
                var result = await _movieRepository.GetByTitleAndYearAsync(title, year);

                movieList = _mapper.Map<List<Movie>>(result);
            }
            else if (!string.IsNullOrEmpty(title) && year == 0)
            {
                var result = await _movieRepository.GetByTitleAsync(title);

                movieList = _mapper.Map<List<Movie>>(result);
            }
            else if (string.IsNullOrEmpty(title) && year != 0)
            {
                var result = await _movieRepository.GetByYearAsync(year);

                movieList = _mapper.Map<List<Movie>>(result);
            }

            return movieList;
        }

        public async Task<List<int>> GetYears()
        {
            return await _movieRepository.GetYearAsync();
        }
    }
}
