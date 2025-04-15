using MovieApp.Models;

namespace MovieApp.Repositories
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllMovies();
        Task<Movie> AddMovie(Movie movie);
        Task<Movie?> GetMovieById(int movieId);
        Task<Movie?> UpdateMovie(Movie movie);
        Task<Movie?> DeleteMovie(Movie movie);
        Task<IEnumerable<Genre>> GetGenres();
    }
}
