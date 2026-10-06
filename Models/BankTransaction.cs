using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankEase.Models
{
    public class BankTransaction
    {
        [Key]
        public int TransactionId { get; set; }

        public int AccountId { get; set; }

        public string TransactionType { get; set; }

        public decimal Amount { get; set; }

        public DateTime TransactionDate { get; set; }

        // Navigation Property
        public virtual Account Account { get; set; }
    }

}
