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
    public class ShipDocksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ShipDocks
        public ActionResult Index()
        {
            return View(db.ShipDocks.ToList());
        }

        // GET: ShipDocks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipDock shipDock = db.ShipDocks.Find(id);
            if (shipDock == null)
            {
                return HttpNotFound();
            }
            return View(shipDock);
        }

        // GET: ShipDocks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShipDocks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "ShipDockID,Name,Country")] ShipDock shipDock)
        {
            if (ModelState.IsValid)
            {
                db.ShipDocks.Add(shipDock);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shipDock);
        }

        // GET: ShipDocks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipDock shipDock = db.ShipDocks.Find(id);
            if (shipDock == null)
            {
                return HttpNotFound();
            }
            return View(shipDock);
        }

        // POST: ShipDocks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit([Bind(Include = "ShipDockID,Name,Country")] ShipDock shipDock)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shipDock).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shipDock);
        }

        // GET: ShipDocks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipDock shipDock = db.ShipDocks.Find(id);
            if (shipDock == null)
            {
                return HttpNotFound();
            }
            return View(shipDock);
        }

        // POST: ShipDocks/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ShipDock shipDock = db.ShipDocks.Find(id);
            db.ShipDocks.Remove(shipDock);
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
