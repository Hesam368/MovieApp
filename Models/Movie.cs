using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(60)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Story { get; set; } = string.Empty;

        [Required]
        public string ShortDesc { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string UrlHandle { get; set; } = string.Empty;
        public DateOnly PublishedDate { get; set; }

        [Required]
        [MaxLength(50)]
        public string Director { get; set; } = string.Empty;

        [Required]
        public bool Visible { get; set; }

        public ICollection<CustomerMovie>? customerMovies { get; set; }
        public ICollection<Genre>? Genres { get; set; }
    }
}
