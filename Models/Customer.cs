using System.ComponentModel.DataAnnotations;

namespace BankEase.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^[6-9][0-9]{9}$",
        ErrorMessage = "Phone number must be 10 digits and start with 6, 7, 8, or 9.")]
        public string Phone { get; set; }

        public string Address { get; set; }
    }
}
