using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApp.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(60)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public bool IsSubscribedToNewsletter { get; set; }
        public DateOnly Birthdate { get; set; }
        public byte MembershipTypeId { get; set; }

        [ForeignKey("MembershipTypeId")]
        public MembershipType? MembershipType { get; set; }

        public List<CustomerMovie>? customerMovies { get; set; }
    }
}
