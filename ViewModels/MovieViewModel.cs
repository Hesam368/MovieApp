using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using MovieApp.Models;

namespace MovieApp.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a title!")]
        [StringLength(60, ErrorMessage = "The title must be at most 60 characters!")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a story!")]
        public string Story { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a short description!")]
        [DisplayName("Short Description")]
        public string ShortDesc { get; set; } = string.Empty;


        [Required(ErrorMessage = "Please enter an Image URL!")]
        [MaxLength(200, ErrorMessage = "Image URL must be at most 200 characters!")]
        [DisplayName("Image URL")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter URL handle!")]
        [MaxLength(200, ErrorMessage = "URL handle must be at most 200 characters!")]
        [DisplayName("URL Handle")]
        public string UrlHandle { get; set; } = string.Empty;

        [DisplayName("Published Date")]
        [Required(ErrorMessage = "Please enter a published date!")]
        public DateOnly PublishedDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [Required(ErrorMessage = "Please enter the director name!")]
        [MaxLength(50, ErrorMessage = "Director name must be at most 50 characters!")]
        public string Director { get; set; } = string.Empty;

        public bool Visible { get; set; }

        [DisplayName("Genres")]
        public IEnumerable<Genre>? AllGenres { get; set; }
        public List<int>? SelectedGenreIds { get; set; }
    }
}
