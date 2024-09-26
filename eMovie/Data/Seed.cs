using eMovie.Data.Enums;
using eMovie.Models;

namespace eMovie.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                //Movies
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Title = "Madame Webb",
                            Description = "Forced to confront revelations about her past, paramedic Cassandra Webb forges a relationship with three " +
                                          "young women destined for powerful futures...if they can all survive a deadly present.",
                            ImageUrl = "https://www.starazi.com/assets/movies/poster/movie_poster_1801.jpg",
                            MovieGenre = MovieGenre.Action,
                            ReleaseDate = new DateOnly(2024, 02, 14),
                            Duration = 116,
                            TrailerUrl = "https://www.youtube.com/embed/ZtAlt2O_t28?si=FlFeNqsCUfvwLppi",
                            WatchUrl = "https://stream-1-2.loadshare.org/custom/VideoID-po87Mn12/file.mp4"
                        },

                        new Movie()
                        {
                            Title = "Beekeeper",
                            Description = "One man’s campaign for vengeance takes on national stakes after he is revealed to be a former operative of a " +
                                          "powerful and clandestine organization known as Beekeepers.",
                            ImageUrl = "https://www.starazi.com/assets/movies/poster/movie_poster_1743.jpg",
                            MovieGenre = MovieGenre.Action,
                            ReleaseDate = new DateOnly(2024, 01, 12),
                            Duration = 105,
                            TrailerUrl = "https://www.youtube.com/embed/CHKn-yDCE2w?si=y74_aW-qoL8oA_A8",
                            WatchUrl = "https://stream-1-2.loadshare.org/custom/VideoID-po87Mn12/file.mp4"
                        },

                        new Movie()
                        {
                            Title = "Aquaman and the Lost Kingdom",
                            Description = "Black Manta, still driven by the need to avenge his father's death and wielding the power of the mythic Black Trident, " +
                                          "will stop at nothing to take Aquaman down once and for all. To defeat him, Aquaman must turn to his imprisoned brother Orm, " +
                                          "the former King of Atlantis, to forge an unlikely alliance in order to save the world from irreversible destruction.",
                            ImageUrl = "https://www.starazi.com/assets/movies/poster/movie_poster_1735.jpg",
                            MovieGenre = MovieGenre.Adventure,
                            ReleaseDate = new DateOnly(2023, 12, 22),
                            Duration = 115,
                            TrailerUrl = "https://www.youtube.com/embed/UGc5Tzz19UY?si=j3TrEVXefSw38wsR",
                            WatchUrl = "https://stream-1-2.loadshare.org/custom/VideoID-po87Mn12/file.mp4"
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
