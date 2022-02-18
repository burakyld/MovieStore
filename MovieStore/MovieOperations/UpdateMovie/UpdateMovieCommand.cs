using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        private readonly IMapper _mapper;
        public UpdateMovieModel UpdateMovieModel { get; set; }
        public int MovieId { get; set; }

        public UpdateMovieCommand(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var movie = _appDbContext.Movies.FirstOrDefault(f=>f.Id == MovieId);
            if (movie == null) throw new InvalidOperationException("Girilen id ye ait film bulunmamaktadır.");

            movie.Name = UpdateMovieModel.Name != default ? UpdateMovieModel.Name : movie.Name;
            movie.Imdb = UpdateMovieModel.Imdb != default ? UpdateMovieModel.Imdb : movie.Imdb;

            _appDbContext.SaveChanges();
        }


    }
    public class UpdateMovieModel
    {
        public string Name { get; set; }

        public double Imdb { get; set; }
    }
}
