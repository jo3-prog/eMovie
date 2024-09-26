using eMovie.Data.Enums;

namespace eMovie.ViewModels
{
    public class CreateMovieViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile ImageUrl { get; set; }
        public MovieGenre MovieGenre { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public int Duration { get; set; }
        public string TrailerUrl { get; set; }
        public string WatchUrl { get; set; }
    }
}
