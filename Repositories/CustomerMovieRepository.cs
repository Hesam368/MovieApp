using Microsoft.EntityFrameworkCore;
using MovieApp.Models;

namespace MovieApp.Repositories
{
    public class CustomerMovieRepository : ICustomerMovieRepository
    {
        private readonly MovieAppContext _context;

        public CustomerMovieRepository(MovieAppContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Customer?>> GetCustomers(int movieId)
        {
            return await _context.CustomerMovies
                .Where(cm => cm.MovieId == movieId)
                .Include(cm => cm.Customer)
                .ThenInclude(c => c.MembershipType)
                .Select(cm => cm.Customer)
                .ToListAsync();
        }

        public async Task<IEnumerable<Movie?>> GetMovies(int customerId)
        {
            return await _context.CustomerMovies
                .Where(cm => cm.CustomerId == customerId)
                .Select(cm => cm.Movie)
                .ToListAsync();
        }
    }
}
