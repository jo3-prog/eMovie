using eMovie.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace eMovie.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Movie Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Movie Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Movie Image is required")]
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Please select Movie Genre")]
        public MovieGenre MovieGenre { get; set; }

        [Required(ErrorMessage = "Movie Release Date is required")]
        [DisplayFormat(DataFormatString = "{0:MMM-dd-yyyy}")]
        [Display(Name = "Release Date")]
        public DateOnly ReleaseDate { get; set; }

        [Required(ErrorMessage = "Movie Duration is required")]
        [DisplayFormat(DataFormatString = "{0} min")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "Trailer link is required")]
        [Display(Name = "Trailer link")]
        public string TrailerUrl { get; set; }

        [Required(ErrorMessage = "Watch now link is required")]
        [Display(Name = "Watch now link")]
        public string WatchUrl { get; set; }
    }
}