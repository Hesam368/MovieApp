using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;
using MovieApp.Repositories;
using MovieApp.ViewModels;

namespace MovieApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieRepository _movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IActionResult> Index()
        {
            var movies = await _movieRepository.GetAllMoviesAsync();
            return View(movies);
        }

        public async Task<IActionResult> Create()
        {
            var model = new MovieViewModel
            {
                AllGenres = await _movieRepository.GetGenresAsync()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieViewModel model)
        {
            if (ModelState.IsValid)
            {
                var movie = BuildMovie(model);
                movie.Genres = await _movieRepository.GetSelectedGenres(model); //Bind selected genres
                await _movieRepository.AddMovieAsync(movie);
                return RedirectToAction("Index");
            }
            model.AllGenres = await _movieRepository.GetGenresAsync();
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var movie = await _movieRepository.GetMovieByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            var model = await BuildMovieViewModel(movie);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MovieViewModel model)
        {
            if (ModelState.IsValid)
            {
                var movie = BuildMovie(model);
                movie.Genres = await _movieRepository.GetSelectedGenres(model); //Bind selected genres
                movie.Id = model.Id; // Ensure the ID is set for the update

                await _movieRepository.UpdateMovieAsync(movie);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var movie = await _movieRepository.GetMovieByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            var model = await BuildMovieViewModel(movie);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var movie = await _movieRepository.GetMovieByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            await _movieRepository.DeleteMovieAsync(movie);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var movie = await _movieRepository.GetMovieByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            var model = await BuildMovieViewModel(movie);
            return View(model);
        }

        private Movie BuildMovie(MovieViewModel model)
        {
            return new Movie
            {
                Title = model.Title,
                Story = model.Story,
                ShortDesc = model.ShortDesc,
                ImageUrl = model.ImageUrl,
                UrlHandle = model.UrlHandle,
                PublishedDate = model.PublishedDate,
                Director = model.Director,
                Visible = model.Visible
            };
        }

        private async Task<MovieViewModel> BuildMovieViewModel(Movie movie)
        {
            return new MovieViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Story = movie.Story,
                ShortDesc = movie.ShortDesc,
                ImageUrl = movie.ImageUrl,
                UrlHandle = movie.UrlHandle,
                PublishedDate = movie.PublishedDate,
                Director = movie.Director,
                Visible = movie.Visible,
                AllGenres = await _movieRepository.GetGenresAsync(),
                SelectedGenreIds = movie.Genres?.Select(g => g.Id).ToList()
            };
        }

    }
}
