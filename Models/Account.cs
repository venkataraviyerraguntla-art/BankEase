using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankEase.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }

        [Required]
        [StringLength(10)]
        public string AccountNumber { get; set; }

        public string AccountType { get; set; }

        public decimal Balance { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}