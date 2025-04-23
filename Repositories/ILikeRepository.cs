using MovieApp.Models;

namespace MovieApp.Repositories
{
    public interface ILikeRepository
    {
        Task<IEnumerable<Like>> GetMovieLikesAsync(int movieId);
        Task<Like> AddLike(Like like);
    }
}
