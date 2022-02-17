using MovieStore.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.MovieOperations.CreateMovie
{
    public class CreateMovieCommand
    {
        private readonly AppDbContext _appDbContext;
        public CreateMovieModel CreateMovieModel { get; set; }

        public CreateMovieCommand(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Handle()
        {
            var movies = _appDbContext.Movies.FirstOrDefault(f => f.Name == CreateMovieModel.Name);
            if (movies != null)
            {
                throw new InvalidOperationException("Bu isimde kayıtlı film bulunuyor.");
            }
            movies = new Movie();
            movies.Name = CreateMovieModel.Name;
            movies.Imdb = CreateMovieModel.Imdb;
            movies.GenreId = CreateMovieModel.GenreId;
            movies.PublishDate = CreateMovieModel.PublishDate;

            _appDbContext.Movies.Add(movies);
            _appDbContext.SaveChanges();
        }


    }

    public class CreateMovieModel
    {
        public string Name { get; set; }

        public DateTime PublishDate { get; set; }

        public int GenreId { get; set; }

        public double Imdb { get; set; }
    }
}
