using FluentValidation;
using MovieStore.MovieOperations.GetMovies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.MovieOperations.GetMovieById
{
    public class GetMovieByIdQueryValidator : AbstractValidator<GetMovieByIdQuery>
    {
        public GetMovieByIdQueryValidator()
        {
            RuleFor(fu => fu.MovieId).GreaterThan(0);
        }
    }
}
