using Microsoft.EntityFrameworkCore;
using MovieApp.Models;
using MovieApp.ViewModels;

namespace MovieApp.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieAppContext _context;

        public MovieRepository(MovieAppContext context)
        {
            _context = context;
        }
        public async Task<Movie> AddMovieAsync(Movie movie)
        {
            await _context.AddAsync(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task<Movie?> DeleteMovieAsync(Movie movie)
        {
            _context.Remove(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task<Movie?> GetMovieByIdAsync(int movieId)
        {
            return await _context.Movies.Include(m => m.Genres).FirstOrDefaultAsync(m => m.Id == movieId);
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync(
            string? searchQuery, string? sortBy, string? direction,
            int pageNumber = 1, int pageSize = 100)
        {
            var query = _context.Movies.Include(m => m.Genres).AsQueryable();
            
            //searching
            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                query = query.Where(m => m.Title.Contains(searchQuery));
            }

            //sorting
            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                var isAsc = string.Equals(direction, "Asc", StringComparison.OrdinalIgnoreCase);
                if (string.Equals(sortBy, "Title", StringComparison.OrdinalIgnoreCase))
                {
                    query = isAsc ? query.OrderBy(m => m.Title) : query.OrderByDescending(m => m.Title);
                }
            }

            //pagination
            var skip = (pageNumber - 1) * pageSize;
            if (skip >= 0)
            {
                query = query.Skip(skip).Take(pageSize);
            }

            return await query.ToListAsync();
        }

        public async Task<Movie?> UpdateMovieAsync(Movie movie)
        {
            _context.Update(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task<IEnumerable<Genre>> GetGenresAsync()
        {
            return await _context.Genre.ToListAsync();
        }

        public async Task<ICollection<Genre>> GetSelectedGenres(MovieViewModel model)
        {
            return await _context.Genre.Where(g => model.SelectedGenreIds.Contains(g.Id)).ToListAsync();
        }

        public async Task<Movie?> GetMovieByUrlAsync(string urlHandle)
        {
            return await _context.Movies
                .Include(m => m.Genres)
                .FirstOrDefaultAsync(m => m.UrlHandle == urlHandle);
        }

        public async Task<int> GetCountAsync()
        {
            return await _context.Movies.CountAsync();
        }
    }
}
