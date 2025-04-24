
using Microsoft.EntityFrameworkCore;
using MovieApp.Models;

namespace MovieApp.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        private readonly MovieAppContext _context;

        public LikeRepository(MovieAppContext context)
        {
            _context = context;
        }

        public async Task<Like> AddLike(Like like)
        {
            await _context.Likes.AddAsync(like);
            await _context.SaveChangesAsync();
            return like;
        }

        public async Task<IEnumerable<Like>> GetMovieLikesAsync(int movieId)
        {
            return await _context.Likes
                .Where(l => l.MovieId == movieId)
                .ToListAsync();
        }
    }
}
