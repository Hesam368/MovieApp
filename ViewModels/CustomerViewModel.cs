using MovieApp.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name!")]
        [StringLength(60, ErrorMessage = "The name must be at most 60 characters!")]
        public string Name { get; set; } = string.Empty;

        [DisplayName("Subscribe to newsletter")]
        public bool IsSubscribedToNewsletter { get; set; }

        [Required(ErrorMessage = "Please enter a birthdate!")]
        public DateOnly Birthdate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [DisplayName("Membership type")]
        public byte MembershipTypeId { get; set; }
        public IEnumerable<MembershipType>? MembershipTypes { get; set; }
    }
}
