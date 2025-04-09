using Microsoft.EntityFrameworkCore;
using MovieApp.Models;

namespace MovieApp.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieAppContext _context;

        public MovieRepository(MovieAppContext context)
        {
            _context = context;
        }
        public async Task<Movie> AddMovie(Movie movie)
        {
            _context.Add(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task<Movie?> DeleteMovie(Movie movie)
        {
            _context.Remove(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task<Movie?> GetMovieById(int movieId)
        {
            return await _context.Movies.FirstOrDefaultAsync(m => m.Id == movieId);
        }

        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie?> UpdateMovie(Movie movie)
        {
            _context.Update(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task<IEnumerable<Customer?>> GetCustomersByMovieId(int movieId)
        {
            return await _context.CustomerMovies
                .Where(cm => cm.MovieId == movieId)
                .Include(cm => cm.Customer)
                .ThenInclude(c => c.MembershipType)
                .Select(cm => cm.Customer)
                .ToListAsync();
        }
    }
}
