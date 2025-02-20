using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    public class CustomerMovie
    {
        [Key]
        public int Id { get; set; }

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

        public Movie Movie { get; set; }
        public int MovieId { get; set; }

    }
}
