using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private static List<Movie> movieList = new List<Movie>() {
            new Movie()
            {
                Id = 1,
                Name = "Yüzüklerin Efendisi",
                GenreId = 1,
                Imdb = 9.0,
                PublishDate = DateTime.Today
            },
            new Movie()
            {
                Id = 2,
                Name = "Alacakaranlık",
                GenreId = 1,
                Imdb = 9.5,
                PublishDate = DateTime.Now
            },
            new Movie()
            {
                Id = 3,
                Name = "Who Am I?",
                GenreId = 2,
                Imdb = 8.0,
                PublishDate = DateTime.Today
            }
        };


        [HttpGet]
        public List<Movie> GetAllMovies()
        {
            return movieList.OrderBy(fu=>fu.Name).ToList();
        }

        [HttpGet("{id}")]
        public Movie GetMovieById(int id)
        {
            return movieList.FirstOrDefault(f=>f.Id == id);
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] Movie movie)
        {
            if(movieList.FirstOrDefault(f=>f.Name == movie.Name) != null)
            {
                return BadRequest("Bu isimde kayıtlı film bulunuyor.");
            }
            movieList.Add(movie);
            return Ok(movie);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, Movie updatedMovie)
        {
            var movie = movieList.FirstOrDefault(f => f.Id == id);
            if (movie == null)
            {
                return BadRequest("Girilen id'ye ait film bulunmamaktadır.");
            }
            movie.Name = updatedMovie != default ? updatedMovie.Name : movie.Name;
            movie.Imdb = updatedMovie != default ? updatedMovie.Imdb : movie.Imdb;
            movie.PublishDate = updatedMovie != default ? updatedMovie.PublishDate : movie.PublishDate;
            movie.GenreId = updatedMovie != default ? updatedMovie.GenreId : movie.GenreId;

            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var movie = movieList.FirstOrDefault(f => f.Id == id);
            if (movie == null)
            {
                return BadRequest("Girilen id'ye ait film bulunmamaktadır.");
            }
            movieList.Remove(movie);
            return Ok();
        }
    }
}
