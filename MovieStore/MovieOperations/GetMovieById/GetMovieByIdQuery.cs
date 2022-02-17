using MovieStore.Common;
using MovieStore.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.MovieOperations.GetMovies
{
    public class GetMovieByIdQuery
    {
        private readonly AppDbContext _appDbContext;

        public GetMovieByIdQuery(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public GetMovieByIdViewModel Handle(int id)
        {
            var result = _appDbContext.Movies.FirstOrDefault(f => f.Id == id);
            if (result == null) throw new InvalidOperationException("Girilen id ye ait film bulunmamaktadır.");

            GetMovieByIdViewModel getMovieByIdViewModel = new GetMovieByIdViewModel();

            getMovieByIdViewModel.Genre = ((GenreEnum)result.GenreId).ToString();
            getMovieByIdViewModel.PublishDate = result.PublishDate.Date.ToString("dd/MM/yyyy");
            getMovieByIdViewModel.Name = result.Name;
            getMovieByIdViewModel.Imdb = result.Imdb;

            return getMovieByIdViewModel;
        }
    }

    public class GetMovieByIdViewModel
    {
        public string Name { get; set; }

        public double Imdb { get; set; }

        public string PublishDate { get; set; }

        public string Genre { get; set; }
    }
}
