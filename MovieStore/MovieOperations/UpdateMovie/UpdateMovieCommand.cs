using MovieStore.DbOperations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.MovieOperations.UpdateMovie
{
    public class UpdateMovieCommand
    {
        private readonly AppDbContext _appDbContext;
        public UpdateMovieModel UpdateMovieModel { get; set; }
        public int MovieId { get; set; }

        public UpdateMovieCommand(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Handle()
        {
            var movie = _appDbContext.Movies.FirstOrDefault(f=>f.Id == MovieId);
            if (movie == null) throw new InvalidOperationException("Girilen id ye ait film bulunmamaktadır.");

            movie.Name = UpdateMovieModel.Name != default && UpdateMovieModel.Name != null ? UpdateMovieModel.Name : movie.Name;
            movie.GenreId = UpdateMovieModel.GenreId != default ? UpdateMovieModel.GenreId : movie.GenreId;
            movie.Imdb = UpdateMovieModel.Imdb != default ? UpdateMovieModel.Imdb : movie.Imdb;
            movie.PublishDate = UpdateMovieModel.PublishDate != default ? UpdateMovieModel.PublishDate : movie.PublishDate;

            _appDbContext.SaveChanges();
        }


    }
    public class UpdateMovieModel
    {
        public string Name { get; set; }

        public DateTime PublishDate { get; set; }

        public int GenreId { get; set; }

        public double Imdb { get; set; }
    }
}
