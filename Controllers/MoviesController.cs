using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Models;
using MovieApp.Repositories;

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
            var movies = await _movieRepository.GetAllMovies();
            return View(movies);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                await _movieRepository.AddMovie(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _movieRepository.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                await _movieRepository.UpdateMovie(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _movieRepository.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Movie movie)
        {
            if (movie == null)
            {
                return NotFound();
            }
            await _movieRepository.DeleteMovie(movie);
            return RedirectToAction("Index");
        }

    }
}
