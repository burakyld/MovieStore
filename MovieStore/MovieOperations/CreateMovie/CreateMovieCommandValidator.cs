using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.MovieOperations.CreateMovie
{
    public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
    {
        public CreateMovieCommandValidator(){
            RuleFor(fu => fu.CreateMovieModel.GenreId).GreaterThan(0).NotNull();
            RuleFor(ru => ru.CreateMovieModel.Name).MinimumLength(5);
            RuleFor(ru => ru.CreateMovieModel.Imdb).ExclusiveBetween(1,10);
            RuleFor(ru => ru.CreateMovieModel.PublishDate).NotEmpty().LessThan(DateTime.Today);
        }
    }
}
