using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Models;

namespace MovieApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieAppContext _context;

        public MoviesController(MovieAppContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var movies = await _context.Movies.ToListAsync();
            return View(movies);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Movie movie)
        {
            MovieValidator(movie);
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        private void MovieValidator(Movie movie)
        {
            if (movie != null)
            {
                if (string.IsNullOrEmpty(movie.Title) || movie.Title.Length > 60)
                    ModelState.AddModelError("Title", "The title must be not null and at most 60 characters!");
                if (string.IsNullOrEmpty(movie.Genre) || movie.Genre.Length > 30)
                    ModelState.AddModelError("Genre", "The genre must be not null and at most 30 characters!");
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Movie movie)
        {
            MovieValidator(movie);
            if (ModelState.IsValid)
            {
                _context.Update(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);
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
            _context.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Customers(int id)
        {
            var customers = await _context.CustomerMovies
                .Where(cm => cm.MovieId == id)
                .Select(cm => cm.Customer)
                .ToListAsync();
            return View(customers);
        }
    }
}
