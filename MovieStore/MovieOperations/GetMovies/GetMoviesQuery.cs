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

        public GetMoviesQuery(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<MoviesViewModel> Handle()
        {
            var movieList = _appDbContext.Movies.OrderBy(fu => fu.Name).ToList();

            List<MoviesViewModel> moviesViewModel = new List<MoviesViewModel>();
            foreach (var movie in movieList)
            {
                moviesViewModel.Add(new MoviesViewModel()
                {
                    Name = movie.Name,
                    PublishDate = movie.PublishDate.Date.ToString("dd/MM/yyyy"),
                    Imdb = movie.Imdb,
                    Genre = ((GenreEnum)movie.GenreId).ToString()
                });
            }
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
