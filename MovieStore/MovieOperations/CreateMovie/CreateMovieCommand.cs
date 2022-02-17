using AutoMapper;
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
        private readonly IMapper _mapper;
        public CreateMovieModel CreateMovieModel { get; set; }

        public CreateMovieCommand(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var movies = _appDbContext.Movies.FirstOrDefault(f => f.Name == CreateMovieModel.Name);
            if (movies != null)
            {
                throw new InvalidOperationException("Bu isimde kayıtlı film bulunuyor.");
            }
            movies = _mapper.Map<Movie>(CreateMovieModel);

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
