using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.MovieOperations.UpdateMovie
{
    public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>
    {
        public UpdateMovieCommandValidator()
        {
            RuleFor(fu => fu.MovieId).GreaterThan(0);
            RuleFor(ru => ru.UpdateMovieModel.Name).MinimumLength(5);
            RuleFor(ru => ru.UpdateMovieModel.Imdb).ExclusiveBetween(1, 10);
        }
    }
}
