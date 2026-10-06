using System;
using System.Linq;
using System.Web.Mvc;
using BankEase.Models;

namespace BankEase.Controllers
{
    public class AccountController : Controller
    {
        BankContext db = new BankContext();

        // GET: Account
        public ActionResult Index()
        {
            var accounts = db.Accounts.ToList();
            return View(accounts);
        }

        // GET: Account/Details
        public ActionResult Details(int id)
        {
            var account = db.Accounts.Find(id);

            if (account == null)
            {
                return HttpNotFound();
            }

            return View(account);
        }

        // GET: Account/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(
                db.Customers,
                "CustomerId",
                "CustomerName"
            );

            return View();
        }

        // POST: Account/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Account account)
        {
            // Check if customer already has an account
            if (db.Accounts.Any(a => a.CustomerId == account.CustomerId))
            {
                ModelState.AddModelError(
                    "CustomerId",
                    "This customer already has an account."
                );
            }

            // Generate Account Number
            account.AccountNumber = "BNK" +
                Guid.NewGuid()
                .ToString("N")
                .Substring(0, 7)
                .ToUpper();

            // Check balance
            if (account.Balance < 0)
            {
                ModelState.AddModelError(
                    "Balance",
                    "Balance cannot be negative."
                );
            }

            // AccountNumber is generated automatically
            ModelState.Remove("AccountNumber");

            if (ModelState.IsValid)
            {
                db.Accounts.Add(account);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(
                db.Customers,
                "CustomerId",
                "CustomerName",
                account.CustomerId
            );

            return View(account);
        }

        // GET: Account/Edit
        public ActionResult Edit(int id)
        {
            var account = db.Accounts.Find(id);

            if (account == null)
            {
                return HttpNotFound();
            }

            ViewBag.CustomerId = new SelectList(
                db.Customers,
                "CustomerId",
                "CustomerName",
                account.CustomerId
            );

            return View(account);
        }

        // POST: Account/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Account account)
        {
            if (ModelState.IsValid)
            {
                db.Entry(account).State =
                    System.Data.Entity.EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(
                db.Customers,
                "CustomerId",
                "CustomerName",
                account.CustomerId
            );

            return View(account);
        }

        // GET: Account/Delete
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var account = db.Accounts.Find(id);

            if (account == null)
            {
                return HttpNotFound();
            }

            return View(account);
        }

        // POST: Account/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var account = db.Accounts.Find(id);

            if (account != null)
            {
                db.Accounts.Remove(account);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
