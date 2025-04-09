using MovieApp.Models;

namespace MovieApp.Repositories
{
    public interface ICustomerMovieRepository
    {
        Task<IEnumerable<Customer?>> GetCustomers(int movieId);
        Task<IEnumerable<Movie?>> GetMovies(int customerId);
    }
}
