using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieInfo.API.Models;
using MovieInfo.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieInfo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly ILogger<MovieController> _logger;
        private IMovieService _movieService;
        private readonly IMapper _mapper;

        public MovieController(ILogger<MovieController> logger, 
            IMovieService movieService,
            IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("years")]
        public async Task<IActionResult> GetYears()
        {
            var years = await _movieService.GetYears();

            return Ok(years);
        }

        [HttpPost]
        public async Task<IActionResult> GetMovies(MovieRequest request)
        {
            var movie = await _movieService.GetAsync(request.Title, request.Year);
            var response = _mapper.Map<List<MovieResponse>>(movie);

            return Ok(response);
        }
    }
}
