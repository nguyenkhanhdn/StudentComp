using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentComp.Models;

namespace StudentComp.Controllers
{
    public class MaximsController : Controller
    {
        private EventDbContext db = new EventDbContext();

        // GET: Maxims
        public ActionResult Index()
        {
            return View(db.Maxims.ToList());
        }

        // GET: Maxims/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maxim maxim = db.Maxims.Find(id);
            if (maxim == null)
            {
                return HttpNotFound();
            }
            return View(maxim);
        }

        // GET: Maxims/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Maxims/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Maxim1,Author,Status,CreatedDate")] Maxim maxim)
        {
            if (ModelState.IsValid)
            {
                db.Maxims.Add(maxim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(maxim);
        }

        // GET: Maxims/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maxim maxim = db.Maxims.Find(id);
            if (maxim == null)
            {
                return HttpNotFound();
            }
            return View(maxim);
        }

        // POST: Maxims/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Maxim1,Author,Status,CreatedDate")] Maxim maxim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maxim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(maxim);
        }

        // GET: Maxims/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maxim maxim = db.Maxims.Find(id);
            if (maxim == null)
            {
                return HttpNotFound();
            }
            return View(maxim);
        }

        // POST: Maxims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Maxim maxim = db.Maxims.Find(id);
            db.Maxims.Remove(maxim);
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
