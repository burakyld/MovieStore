using AutoMapper;
using MovieStore.Common;
using MovieStore.MovieOperations.CreateMovie;
using MovieStore.MovieOperations.GetMovies;
using MovieStore.MovieOperations.UpdateMovie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MoviesViewModel>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()))
                .ForMember(dest => dest.PublishDate, opt => opt.MapFrom(src => (src.PublishDate).Date.ToString("dd/MM/yyyy")));

            CreateMap<Movie, GetMovieByIdViewModel>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()))
                .ForMember(dest => dest.PublishDate, opt => opt.MapFrom(src => (src.PublishDate).Date.ToString("dd/MM/yyyy")));

            CreateMap<CreateMovieModel, Movie>();
            CreateMap<UpdateMovieModel, Movie>();
        }
    }
}
