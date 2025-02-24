using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApp.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name!")]
        [StringLength(60, ErrorMessage = "The name must be at most 60 characters!")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [DisplayName("Subscribe to newsletter")]
        public bool IsSubscribedToNewsletter { get; set; }
        public DateOnly Birthdate { get; set; }

        [DisplayName("Membership type")]
        public byte MembershipTypeId { get; set; }

        [ForeignKey("MembershipTypeId")]
        public MembershipType? MembershipType { get; set; }

        public List<CustomerMovie>? customerMovies { get; set; }
    }
}
