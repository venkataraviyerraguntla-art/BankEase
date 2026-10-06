using BankEase.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace BankEase.Controllers
{
    public class BankTransactionController : Controller
    {
        BankContext db = new BankContext();

        // GET: Transaction History
        [HttpGet]
        public ActionResult Index(string AccountNumber)
        {
            var transactions = db.BankTransactions
                .Include("Account")
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(AccountNumber))
            {
                transactions = transactions.Where(t =>
                    t.Account.AccountNumber == AccountNumber);
            }

            transactions = transactions
                .OrderByDescending(t => t.TransactionDate);

            ViewBag.AccountNumber = AccountNumber;

            return View(transactions.ToList());
        }

        // GET: Deposit
        [HttpGet]
        public ActionResult Deposit()
        {
            return View();
        }

        // POST: Deposit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deposit(string AccountNumber, decimal Amount)
        {
            var account = db.Accounts
                .FirstOrDefault(a => a.AccountNumber == AccountNumber);

            if (account == null)
            {
                ModelState.AddModelError(
                    "AccountNumber",
                    "Account number not found.");
            }

            if (Amount <= 0)
            {
                ModelState.AddModelError(
                    "Amount",
                    "Amount must be greater than zero.");
            }

            if (ModelState.IsValid)
            {
                account.Balance += Amount;

                BankTransaction transaction = new BankTransaction
                {
                    AccountId = account.AccountId,
                    TransactionType = "Deposit",
                    Amount = Amount,
                    TransactionDate = DateTime.Now
                };

                db.BankTransactions.Add(transaction);
                db.SaveChanges();

                return RedirectToAction("Index",
                    new { AccountNumber = AccountNumber });
            }

            return View();
        }

        // GET: Withdraw
        [HttpGet]
        public ActionResult Withdraw()
        {
            return View();
        }

        // POST: Withdraw
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Withdraw(string AccountNumber, decimal Amount)
        {
            var account = db.Accounts
                .FirstOrDefault(a => a.AccountNumber == AccountNumber);

            if (account == null)
            {
                ModelState.AddModelError(
                    "AccountNumber",
                    "Account number not found.");
            }
            else
            {
                if (Amount <= 0)
                {
                    ModelState.AddModelError(
                        "Amount",
                        "Amount must be greater than zero.");
                }
                else if (Amount > account.Balance)
                {
                    ModelState.AddModelError(
                        "Amount",
                        "Insufficient balance.");
                }
            }

            if (ModelState.IsValid)
            {
                account.Balance -= Amount;

                BankTransaction transaction = new BankTransaction
                {
                    AccountId = account.AccountId,
                    TransactionType = "Withdraw",
                    Amount = Amount,
                    TransactionDate = DateTime.Now
                };

                db.BankTransactions.Add(transaction);
                db.SaveChanges();

                return RedirectToAction("Index",
                    new { AccountNumber = AccountNumber });
            }

            return View();
        }
    }
}
