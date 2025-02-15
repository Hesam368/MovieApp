using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    public class MembershipType
    {
        [Key]
        public byte Id { get; set; }

        [Required]
        public short SignUpFee { get; set; }

        [Required]
        public byte DurationInMonths { get; set; }

        [Required]
        public byte DiscountRate { get; set; }
    }
}
