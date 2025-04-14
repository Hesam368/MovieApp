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
        public string Story { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a short description!")]
        public string ShortDesc { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter an Image URL!")]
        public string ImageUrl { get; set; } = string.Empty;
        public string UrlHandle { get; set; } = string.Empty;
        public DateOnly PublishedDate { get; set; }

        [Required(ErrorMessage = "Please enter the director name!")]
        public string Director { get; set; } = string.Empty;
        public bool Visible { get; set; }

        public ICollection<CustomerMovie>? customerMovies { get; set; }
        public ICollection<Genre>? Genres { get; set; }
    }
}
