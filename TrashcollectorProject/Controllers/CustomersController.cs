using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashcollectorProject.Models;

namespace TrashcollectorProject.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customer.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            List<SelectListItem> days = new List<SelectListItem>();
            days.Add(new SelectListItem { Text = "Monday"});
            days.Add(new SelectListItem { Text = "Tuesday" });
            days.Add(new SelectListItem { Text = "Wednesday" });
            days.Add(new SelectListItem { Text = "Thursday" });
            days.Add(new SelectListItem { Text = "Friday" });
            days.Add(new SelectListItem { Text = "Saturday" });
            days.Add(new SelectListItem { Text = "Sunday" });
            Customer customer = new Customer()
            {
                DayList = days
            };
            return View(customer);
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,FirstName,LastName,EmailAddress,StreetAddress,City,State,ZipCode,PickupDay")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customer.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,FirstName,LastName,EmailAddress,StreetAddress,City,State,ZipCode,PickupDay")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customer.Find(id);
            db.Customer.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //public List<SelectListItem> SelectPickUpDay()
        //{
        //    List<SelectListItem> days = new List<SelectListItem>();
        //    days.Add(new SelectListItem { Text = "Monday" });
        //    days.Add(new SelectListItem { Text = "Tuesday" });
        //    days.Add(new SelectListItem { Text = "Wednesday" });
        //    days.Add(new SelectListItem { Text = "Thursday" });
        //    days.Add(new SelectListItem { Text = "Friday" });
        //    days.Add(new SelectListItem { Text = "Saturday" });
        //    days.Add(new SelectListItem { Text = "Sunday" });
        //    Customer customer = new Customer()
        //    {
        //        DayList = days
        //    };
        //    return day(customer);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
