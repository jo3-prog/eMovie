using eMovie.Interfaces;
using eMovie.Models;
using eMovie.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eMovie.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IPhotoService _photoService;
        public MovieController(IMovieRepository movieRepository, IPhotoService photoService)
        {
            _movieRepository = movieRepository;
            _photoService = photoService;
        }

        //Get Movie...
        public async Task<IActionResult> Index()
        {
            IEnumerable<Movie> movies = await _movieRepository.GetAll();
            return View(movies);
        }

        //Search Movie...
        [HttpPost, ActionName("Search")]
        public async Task<IActionResult> SearchMovie(string search)
        {
            IEnumerable<Movie> movies = await _movieRepository.GetMovie(search);
            return View("Index", movies);
        }

        //Watch Trailer...
        public async Task<IActionResult> Trailer(int id)
        {
            Movie trailer = await _movieRepository.GetByIdAsync(id);
            if (trailer == null)
            {
                return NotFound();
            }

            var trailerVM = new TrailerViewModel
            {
                Id = trailer.Id,
                TrailerUrl = trailer.TrailerUrl
            };

            return View(trailerVM);
        }

        //Movie Details...
        public async Task<IActionResult> Detail(int id)
        {
            Movie movie = await _movieRepository.GetByIdAsync(id);
            return View(movie);
        }

        //Get Method for Create...
        public IActionResult Create()
        {
            return View();
        }

        //Post Method for Create...
        [HttpPost]
        public async Task<IActionResult> Create(CreateMovieViewModel movieVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _photoService.AddPhotoAsync(movieVM.ImageUrl);

                    var movie = new Movie
                    {
                        Title = movieVM.Title,
                        Description = movieVM.Description,
                        ImageUrl = result.Url.ToString(),
                        MovieGenre = movieVM.MovieGenre,
                        ReleaseDate = movieVM.ReleaseDate,
                        Duration = movieVM.Duration,
                        TrailerUrl = movieVM.TrailerUrl,
                        WatchUrl = movieVM.WatchUrl,
                    };
                    _movieRepository.Add(movie);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Could not create due to " + ex.Message);
                }
                return View(movieVM);
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }

            return View(movieVM);
        }

        //Get Method for Edit...
        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            var movieVM = new EditMovieViewModel
            {
                Title = movie.Title,
                Description = movie.Description,
                URL = movie.ImageUrl,
                MovieGenre = movie.MovieGenre,
                ReleaseDate = movie.ReleaseDate,
                Duration = movie.Duration,
                TrailerUrl = movie.TrailerUrl,
                WatchUrl = movie.WatchUrl
            };
            return View(movieVM);
        }

        //Post request for Edit...
        [HttpPost]
        public async Task<IActionResult> Edit(EditMovieViewModel editVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit movie");
                return View("Edit", editVM);
            }

            var movie = await _movieRepository.GetByIdAsync(editVM.Id);
            if (movie != null)
            {
                //Check if image exist...
                if (editVM.ImageUrl != null)
                {
                    try
                    {
                        await _photoService.DeletePhotoAsync(movie.ImageUrl);
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "Could not delete photo due to " + ex.Message);
                        return View("Edit", editVM);
                    }
                }
                //Start editing the movie...
                var photoResult = await _photoService.AddPhotoAsync(editVM.ImageUrl);

                movie.Title = editVM.Title;
                movie.Description = editVM.Description;
                movie.MovieGenre = editVM.MovieGenre;
                movie.Duration = editVM.Duration;
                movie.ReleaseDate = editVM.ReleaseDate;
                movie.TrailerUrl = editVM.TrailerUrl;
                movie.WatchUrl = editVM.WatchUrl;

                _movieRepository.Update(movie);

                return RedirectToAction("Index");
            }
            else
            {
                return View(editVM);
            }
        }

        //Delete Method...
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var delete = await _movieRepository.GetByIdAsync(id);
            if (delete != null)
            {
                _movieRepository.Delete(delete);
            }
            _movieRepository.Save();
            return RedirectToAction("Index");
        }

        //Donations...
        public IActionResult Donate()
        {
            return View();
        }
    }
}
