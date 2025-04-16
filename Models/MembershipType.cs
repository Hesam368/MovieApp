using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    public class MembershipType
    {
        [Key]
        public byte Id { get; set; }

        [Required]
        [StringLength(60)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public short SignUpFee { get; set; }

        [Required]
        public byte DurationInMonths { get; set; }

        [Required]
        public byte DiscountRate { get; set; }

        public ICollection<Customer>? customers { get; set; }
    }
}
