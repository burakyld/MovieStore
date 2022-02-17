using AutoMapper;
using MovieStore.Common;
using MovieStore.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.MovieOperations.GetMovies
{
    public class GetMovieByIdQuery
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public int MovieId { get; set; }

        public GetMovieByIdQuery(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public GetMovieByIdViewModel Handle()
        {
            var result = _appDbContext.Movies.FirstOrDefault(f => f.Id == MovieId);
            if (result == null) 
                throw new InvalidOperationException("Girilen id ye ait film bulunmamaktadır.");

            GetMovieByIdViewModel getMovieByIdViewModel = _mapper.Map<GetMovieByIdViewModel>(result);

            return getMovieByIdViewModel;
        }
    }

    public class GetMovieByIdViewModel
    {
        public string Name { get; set; }

        public double Imdb { get; set; }

        public string PublishDate { get; set; }

        public string Genre { get; set; }
    }
}
