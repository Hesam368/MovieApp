using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;
using MovieApp.Repositories;

namespace MovieApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMovieRepository _movieRepository;

    public HomeController(ILogger<HomeController> logger, IMovieRepository movieRepository)
    {
        _logger = logger;
        _movieRepository = movieRepository;
    }

    public async Task<IActionResult> Index()
    {
        var movies = await _movieRepository.GetAllMoviesAsync();
        return View(movies);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
