using AutoMapper;
using MovieStore.Common;
using MovieStore.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.MovieOperations.GetMovies
{
    public class GetMoviesQuery
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public GetMoviesQuery(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public List<MoviesViewModel> Handle()
        {
            var movieList = _appDbContext.Movies.OrderBy(fu => fu.Name).ToList();

            List<MoviesViewModel> moviesViewModel = _mapper.Map<List<MoviesViewModel>>(movieList);

            return moviesViewModel;
        }
    }

    public class MoviesViewModel
    {
        public string Name { get; set; }

        public double Imdb { get; set; }

        public string PublishDate { get; set; }

        public string Genre { get; set; }
    }
}
