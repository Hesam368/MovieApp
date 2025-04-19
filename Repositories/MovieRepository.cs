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
            _context.Add(movie);
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

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await _context.Movies.Include(m => m.Genres).ToListAsync();
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
    }
}
