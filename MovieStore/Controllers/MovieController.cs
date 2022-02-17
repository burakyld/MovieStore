using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.DbOperations;
using MovieStore.MovieOperations.CreateMovie;
using MovieStore.MovieOperations.DeleteMovie;
using MovieStore.MovieOperations.GetMovies;
using MovieStore.MovieOperations.UpdateMovie;
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
        public IActionResult GetAllMovies()
        {
            GetMoviesQuery getMoviesQuery = new GetMoviesQuery(_appDbContext);

            return Ok(getMoviesQuery.Handle());
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            GetMovieByIdQuery getMovieByIdQuery = new GetMovieByIdQuery(_appDbContext);
            GetMovieByIdViewModel result;

            try {
                getMovieByIdQuery.MovieId = id;
                result = getMovieByIdQuery.Handle();


            } catch(Exception ex) {

                return BadRequest(ex.Message);
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] CreateMovieModel createMovieModel)
        {
            CreateMovieCommand createMovieCommand = new CreateMovieCommand(_appDbContext);
            try
            {
                createMovieCommand.CreateMovieModel = createMovieModel;
                createMovieCommand.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, UpdateMovieModel updatedMovie)
        {
            UpdateMovieCommand updateMovieCommand = new UpdateMovieCommand(_appDbContext);
            try
            {
                updateMovieCommand.UpdateMovieModel = updatedMovie;
                updateMovieCommand.MovieId = id;
                updateMovieCommand.Handle();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            DeleteMovieCommand deleteMovieCommand = new DeleteMovieCommand(_appDbContext);
            try
            {
                deleteMovieCommand.MovieId = id;
                deleteMovieCommand.Handle();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
