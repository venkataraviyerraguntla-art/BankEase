using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BankEase.Models
{
    public class BankContext:DbContext
    {
        public BankContext() : base("Constr")
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<BankTransaction> BankTransactions { get; set; }
    }
}