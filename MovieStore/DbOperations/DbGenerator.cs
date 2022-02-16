using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.DbOperations
{
    public class DbGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                if (context.Movies.Any())
                {
                    return;
                }
                context.AddRange(
                    new Movie()
                    {
                        Name = "Yüzüklerin Efendisi",
                        GenreId = 1,
                        Imdb = 9.0,
                        PublishDate = DateTime.Today
                    },
                    new Movie()
                    {
                        Name = "Alacakaranlık",
                        GenreId = 1,
                        Imdb = 9.5,
                        PublishDate = DateTime.Now
                    },
                    new Movie()
                    {
                        Name = "Who Am I?",
                        GenreId = 2,
                        Imdb = 8.0,
                        PublishDate = DateTime.Today
                    }
                    );
                context.SaveChanges();
            };
        }
    }
}
