using BankEase.Models;
using System.Linq;
using System.Web.Mvc;

namespace BankEase.Controllers
{
    public class CustomerController : Controller
    {
        BankContext db = new BankContext();

        public ActionResult Index()
        {
            var customers = db.Customers.ToList();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = db.Customers.Find(id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (db.Customers.Any(c => c.Email == customer.Email))
            {
                ModelState.AddModelError("Email",
                    "This email is already registered.");
            }

            if (db.Customers.Any(c => c.Phone == customer.Phone))
            {
                ModelState.AddModelError("Phone",
                    "This phone number is already registered.");
            }

            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = db.Customers.Find(id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            if (db.Customers.Any(c =>
                c.Email == customer.Email &&
                c.CustomerId != customer.CustomerId))
            {
                ModelState.AddModelError("Email",
                    "This email is already registered.");
            }

            if (db.Customers.Any(c =>
                c.Phone == customer.Phone &&
                c.CustomerId != customer.CustomerId))
            {
                ModelState.AddModelError("Phone",
                    "This phone number is already registered.");
            }

            if (ModelState.IsValid)
            {
                db.Entry(customer).State =
                    System.Data.Entity.EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(customer);
        }

        public ActionResult Delete(int id)
        {
            var customer = db.Customers.Find(id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var customer = db.Customers.Find(id);

            if (customer == null)
            {
                return RedirectToAction("Index");
            }

            db.Customers.Remove(customer);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
