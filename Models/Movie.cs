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
        [StringLength(30)]
        public string Genre { get; set; } = string.Empty;

        public List<CustomerMovie>? customerMovies { get; set; }
    }
}
