using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;
using MovieApp.Repositories;
using MovieApp.ViewModels;

namespace MovieApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieLikeController : ControllerBase
    {
        private readonly ILikeRepository _likeRepository;

        public MovieLikeController(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddLike([FromBody] AddLikeViewModel like)
        {
            if (like == null)
            {
                return BadRequest("Like cannot be null");
            }
            var model = new Like
            {
                MovieId = like.movieId,
                UserGId = like.userGId
            };
            await _likeRepository.AddLike(model);
            return Ok();
        }

        [HttpGet]
        [Route("{movieId:int}/GetLikes")]
        public async Task<IActionResult> GetMovieLikes([FromRoute]int movieId)
        {
            var likes = await _likeRepository.GetMovieLikesAsync(movieId);
            if (likes == null || !likes.Any())
            {
                return NotFound("No likes found for this movie");
            }
            return Ok(likes);
        }
    }
}
