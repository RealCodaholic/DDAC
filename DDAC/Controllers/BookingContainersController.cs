using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DDAC.Models;

namespace DDAC.Controllers
{
    [Authorize]
    public class BookingContainersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BookingContainers
        public ActionResult Index()
        {
            var bookingContainers = db.BookingContainers.Include(b => b.Booking).Include(b => b.Container);
            return View(bookingContainers.ToList());
        }

        // GET: BookingContainers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingContainer bookingContainer = db.BookingContainers.Find(id);
            if (bookingContainer == null)
            {
                return HttpNotFound();
            }
            return View(bookingContainer);
        }

        // GET: BookingContainers/Create
        public ActionResult Create()
        {
            ViewBag.BookingID = new SelectList(db.Bookings, "BookingID", "BookingID");
            ViewBag.ContainerID = new SelectList(db.Containers, "ContainerID", "ContainerID");
            return View();
        }

        // POST: BookingContainers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "BookingContainerID,BookingID,ContainerID")] BookingContainer bookingContainer)
        {
            if (ModelState.IsValid)
            {
                db.BookingContainers.Add(bookingContainer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookingID = new SelectList(db.Bookings, "BookingID", "BookingID", bookingContainer.BookingID);
            ViewBag.ContainerID = new SelectList(db.Containers, "ContainerID", "ContainerID", bookingContainer.ContainerID);
            return View(bookingContainer);
        }

        // GET: BookingContainers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingContainer bookingContainer = db.BookingContainers.Find(id);
            if (bookingContainer == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookingID = new SelectList(db.Bookings, "BookingID", "BookingID", bookingContainer.BookingID);
            ViewBag.ContainerID = new SelectList(db.Containers, "ContainerID", "ContainerID", bookingContainer.ContainerID);
            return View(bookingContainer);
        }

        // POST: BookingContainers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit([Bind(Include = "BookingContainerID,BookingID,ContainerID")] BookingContainer bookingContainer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookingContainer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookingID = new SelectList(db.Bookings, "BookingID", "BookingID", bookingContainer.BookingID);
            ViewBag.ContainerID = new SelectList(db.Containers, "ContainerID", "ContainerID", bookingContainer.ContainerID);
            return View(bookingContainer);
        }

        // GET: BookingContainers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingContainer bookingContainer = db.BookingContainers.Find(id);
            if (bookingContainer == null)
            {
                return HttpNotFound();
            }
            return View(bookingContainer);
        }

        // POST: BookingContainers/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            BookingContainer bookingContainer = db.BookingContainers.Find(id);
            db.BookingContainers.Remove(bookingContainer);
            db.SaveChanges();
            return RedirectToAction("Index");
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
