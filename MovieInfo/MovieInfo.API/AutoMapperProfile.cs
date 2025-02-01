using AutoMapper;
using entities = MovieInfo.Entities;
using MovieInfo.API.Models;
using repositorie = MovieInfo.Repositories.Models;

namespace MovieInfo.API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<MovieResponse, entities.Movie>().ReverseMap();
            CreateMap<repositorie.Movie, entities.Movie>()
                .ReverseMap();
        }
    }
}
