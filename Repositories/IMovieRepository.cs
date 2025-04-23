using MovieApp.Models;
using MovieApp.ViewModels;

namespace MovieApp.Repositories
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllMoviesAsync();
        Task<Movie> AddMovieAsync(Movie movie);
        Task<Movie?> GetMovieByIdAsync(int movieId);
        Task<Movie?> GetMovieByUrlAsync(string urlHandle);
        Task<Movie?> UpdateMovieAsync(Movie movie);
        Task<Movie?> DeleteMovieAsync(Movie movie);
        Task<IEnumerable<Genre>> GetGenresAsync();
        Task<ICollection<Genre>> GetSelectedGenres(MovieViewModel model);
    }
}
