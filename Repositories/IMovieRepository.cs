using MovieApp.Models;

namespace MovieApp.Repositories
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllMovies();
        Task<Movie> AddMovie(Movie movie);
        Task<Movie?> GetMovieById(int MovieId);
        Task<Movie?> UpdateMovie(Movie movie);
        Task<Movie?> DeleteMovie(Movie movie);
        Task<IEnumerable<Customer?>> GetCustomersByMovieId(int movieId);
    }
}
