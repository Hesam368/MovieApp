using Microsoft.AspNetCore.Mvc;
using MovieApp.Repositories;

namespace MovieApp.Controllers
{
    public class CustomerMovieController : Controller
    {
        private readonly ICustomerMovieRepository _customerMovieRepository;

        public CustomerMovieController(ICustomerMovieRepository customerMovieRepository)
        {
            _customerMovieRepository = customerMovieRepository;
        }
        public async Task<IActionResult> Customers(int id)
        {
            var customers = await _customerMovieRepository.GetCustomers(id);
            return View(customers);
        }

        public async Task<IActionResult> Movies(int id)
        {
            var movies = await _customerMovieRepository.GetMovies(id);
            return View(movies);
        }
    }
}
