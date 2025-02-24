using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a title!")]
        [StringLength(60, ErrorMessage = "The title must be at most 60 characters!")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a genre!")]
        [StringLength(30, ErrorMessage = "The genre must be at most 30 characters!")]
        public string Genre { get; set; } = string.Empty;

        public List<CustomerMovie>? customerMovies { get; set; }
    }
}
