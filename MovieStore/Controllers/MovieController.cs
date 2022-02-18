using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.DbOperations;
using MovieStore.MovieOperations.CreateMovie;
using MovieStore.MovieOperations.DeleteMovie;
using MovieStore.MovieOperations.GetMovieById;
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
        private readonly IMapper _mapper;

        public MovieController(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetAllMovies()
        {
            GetMoviesQuery getMoviesQuery = new GetMoviesQuery(_appDbContext, _mapper);

            return Ok(getMoviesQuery.Handle());
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            GetMovieByIdQuery getMovieByIdQuery = new GetMovieByIdQuery(_appDbContext, _mapper);
            GetMovieByIdViewModel result;

            try {
                getMovieByIdQuery.MovieId = id;

                GetMovieByIdQueryValidator validator = new GetMovieByIdQueryValidator();
                validator.ValidateAndThrow(getMovieByIdQuery);

                result = getMovieByIdQuery.Handle();


            } catch(Exception ex) {

                return BadRequest(ex.Message);
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] CreateMovieModel createMovieModel)
        {
            CreateMovieCommand createMovieCommand = new CreateMovieCommand(_appDbContext, _mapper);
            try
            {
                createMovieCommand.CreateMovieModel = createMovieModel;

                CreateMovieCommandValidator validator = new CreateMovieCommandValidator();
                validator.ValidateAndThrow(createMovieCommand);

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
            UpdateMovieCommand updateMovieCommand = new UpdateMovieCommand(_appDbContext, _mapper);
            try
            {
                updateMovieCommand.UpdateMovieModel = updatedMovie;
                updateMovieCommand.MovieId = id;

                UpdateMovieCommandValidator validator = new UpdateMovieCommandValidator();
                validator.ValidateAndThrow(updateMovieCommand);

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

                DeleteMovieCommandValidator validator = new DeleteMovieCommandValidator();
                validator.ValidateAndThrow(deleteMovieCommand);

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
