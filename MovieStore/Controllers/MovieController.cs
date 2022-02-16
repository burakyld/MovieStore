using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public MovieController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        [HttpGet]
        public List<Movie> GetAllMovies()
        {
            return _appDbContext.Movies.OrderBy(fu=>fu.Name).ToList();
        }

        [HttpGet("{id}")]
        public Movie GetMovieById(int id)
        {
            return _appDbContext.Movies.FirstOrDefault(f=>f.Id == id);
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] Movie movie)
        {
            if(_appDbContext.Movies.FirstOrDefault(f=>f.Name == movie.Name) != null)
            {
                return BadRequest("Bu isimde kayıtlı film bulunuyor.");
            }
            _appDbContext.Movies.Add(movie);
            _appDbContext.SaveChanges();
            return Ok(movie);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, Movie updatedMovie)
        {
            var movie = _appDbContext.Movies.FirstOrDefault(f => f.Id == id);
            if (movie == null)
            {
                return BadRequest("Girilen id'ye ait film bulunmamaktadır.");
            }
            movie.Name = updatedMovie != default ? updatedMovie.Name : movie.Name;
            movie.Imdb = updatedMovie != default ? updatedMovie.Imdb : movie.Imdb;
            movie.PublishDate = updatedMovie != default ? updatedMovie.PublishDate : movie.PublishDate;
            movie.GenreId = updatedMovie != default ? updatedMovie.GenreId : movie.GenreId;

            _appDbContext.SaveChanges();

            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var movie = _appDbContext.Movies.FirstOrDefault(f => f.Id == id);
            if (movie == null)
            {
                return BadRequest("Girilen id'ye ait film bulunmamaktadır.");
            }
            _appDbContext.Movies.Remove(movie);
            _appDbContext.SaveChanges();
            return Ok();
        }
    }
}
