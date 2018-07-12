using Microsoft.AspNet.Identity;
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
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employees
        public ActionResult Index()
        {
            var currentUserId = User.Identity.GetUserId();
            var employees = db.Employee.Where(c => c.UserId == currentUserId);
            return View(db.Employee.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            var currentUserId = User.Identity.GetUserId();
            var employee = db.Employee.Where(c => c.UserId == currentUserId).FirstOrDefault();
            if (currentUserId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,FirstName,LastName,EmailAddress,StreetAddress,City,State,ZipCode")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.UserId = User.Identity.GetUserId();
                db.Employee.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,FirstName,LastName,EmailAddress,StreetAddress,City,State,ZipCode")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employee.Find(id);
            db.Employee.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DisplayPickups(int? id)
        {
            var today = DateTime.Now.DayOfWeek.ToString();
            var userId = User.Identity.GetUserId();
            Employee employee = db.Employee.Where(e => e.UserId == userId).FirstOrDefault();
            var currentUserZip = from e in db.Employee select e;
            var customers = from c in db.Customer select c;
            var pickups = db.Customer.Where(c => c.ZipCode == employee.ZipCode && c.PickupDay == today).ToList();
            return View("Pickups", pickups);
        }

        public ActionResult SortPickups(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            ViewBag.DaySortParm = sortOrder == "PickupDay" ? "PickupDay_desc" : "PickUpDay";
            var userId = User.Identity.GetUserId();
            Employee employee = db.Employee.Where(e => e.UserId == userId).FirstOrDefault();
            var customers = from c in db.Customer select c;
            var weeksPickups = db.Customer.Where(c => c.ZipCode == employee.ZipCode).ToList();
            
            switch (sortOrder)
            {
                case "Name_desc":
                    customers = customers.OrderByDescending(c => c.LastName);
                    break;
                case "PickupDay":
                    customers = customers.OrderBy(c => c.PickupDay);
                    break;
                default:
                    customers = customers.OrderBy(c => c.LastName);
                    break;
            }
            return View("SortedPickups", weeksPickups);
        }

        public ActionResult LogPickupComplete()
        {
            return View();
        }

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
