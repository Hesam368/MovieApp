using Microsoft.AspNetCore.Mvc;

namespace MovieApp.Controllers
{
    public class CustomerMovieController : Controller
    {
        public IActionResult Customers()
        {
            return View();
        }
    }
}
