using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;
using MovieApp.Repositories;
using MovieApp.ViewModels;
using System.Threading.Tasks;

namespace MovieApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ILikeRepository _likeRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public MoviesController(IMovieRepository movieRepository, ILikeRepository likeRepository,
            UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _movieRepository = movieRepository;
            _likeRepository = likeRepository;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            var movies = await _movieRepository.GetAllMoviesAsync();
            return View(movies);
        }

        [Authorize(Roles = "Admin")]
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

        public async Task<IActionResult> ReadMore(string urlHandle)
        {
            if (string.IsNullOrEmpty(urlHandle))
            {
                return BadRequest();
            }
            var movie = await _movieRepository.GetMovieByUrlAsync(urlHandle);
            if (movie == null)
            {
                return NotFound();
            }
            var movieLikes = await _likeRepository.GetMovieLikesAsync(movie.Id);
            movie.likes = movieLikes?.ToList();

            ViewData["movieLiked"] = false;
            if (_signInManager.IsSignedIn(User))
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    var userId = user.Id;
                    var userLikes = movie.likes?.FirstOrDefault(l => l.UserGId == Guid.Parse(userId));
                    if (userLikes != null)
                    {
                        ViewData["movieLiked"] = true;
                    }
                }
            }
            return View(movie);
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
