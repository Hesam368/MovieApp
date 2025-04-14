using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name!")]
        [MaxLength(15, ErrorMessage = "Genre name must be at most 15 characters!")]
        public string Name { get; set; } = string.Empty;

        public ICollection<Movie>? Movies { get; set; }
    }
}
