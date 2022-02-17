using MovieStore.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.MovieOperations.DeleteMovie
{
    public class DeleteMovieCommand
    {
        private readonly AppDbContext _appDbContext;
        public int MovieId { get; set; }


        public DeleteMovieCommand(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Handle()
        {
            var movie = _appDbContext.Movies.FirstOrDefault(f => f.Id == MovieId);
            if (movie == null)
                throw new InvalidOperationException("Girilen id ye ait film bulunmamaktadır.");


            _appDbContext.Movies.Remove(movie);
            _appDbContext.SaveChanges();
        }
    }
}
