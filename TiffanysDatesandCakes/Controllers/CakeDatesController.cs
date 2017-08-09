using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TiffanysDatesandCakes.Models;

namespace TiffanysDatesandCakes.Controllers
{
    public class CakeDatesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: CakeDates
        public ActionResult Index()
        {
            var cakeDates = db.CakeDates.Include(c => c.Cake).Include(c => c.Date);
            return View(cakeDates.ToList());
        }

        // GET: CakeDates/Details/5 
        public ActionResult Details(string id)
        { 
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CakeDate cakeDate = db.CakeDates.Find(id);
            if (cakeDate == null)
            {
                return HttpNotFound();
            }
            return View(cakeDate);
        }

        // GET: CakeDates/Create
        public ActionResult Create()
        {
            ViewBag.CakeId = new SelectList(db.Cakes, "CakeId", "Name");
            ViewBag.DateId = new SelectList(db.Dates, "DateId", "Name");
            return View();
        }

        // POST: CakeDates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CakeDateId,CreateDate,EditDate,CakeId,GenreId,DateId")] CakeDate cakeDate)
        {
            if (ModelState.IsValid)
            {
                db.CakeDates.Add(cakeDate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CakeId = new SelectList(db.Cakes, "CakeId", "Name", cakeDate.CakeId);
            ViewBag.DateId = new SelectList(db.Dates, "DateId", "Name", cakeDate.DateId);
            return View(cakeDate);
        }

        // GET: CakeDates/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CakeDate cakeDate = db.CakeDates.Find(id);
            if (cakeDate == null)
            {
                return HttpNotFound();
            }
            ViewBag.CakeId = new SelectList(db.Cakes, "CakeId", "Name", cakeDate.CakeId);
            ViewBag.DateId = new SelectList(db.Dates, "DateId", "Name", cakeDate.DateId);
            return View(cakeDate);
        }

        // POST: CakeDates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CakeDateId,CreateDate,EditDate,CakeId,GenreId,DateId")] CakeDate cakeDate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cakeDate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CakeId = new SelectList(db.Cakes, "CakeId", "Name", cakeDate.CakeId);
            ViewBag.DateId = new SelectList(db.Dates, "DateId", "Name", cakeDate.DateId);
            return View(cakeDate);
        }

        // GET: CakeDates/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CakeDate cakeDate = db.CakeDates.Find(id);
            if (cakeDate == null)
            {
                return HttpNotFound();
            }
            return View(cakeDate);
        }

        // POST: CakeDates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CakeDate cakeDate = db.CakeDates.Find(id);
            db.CakeDates.Remove(cakeDate);
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
