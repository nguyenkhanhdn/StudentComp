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
    public class RecommendsController : Controller
    {
        private EventDbContext db = new EventDbContext();

        // GET: Recommends
        public ActionResult Index()
        {
            return View(db.Recommends.ToList());
        }

        // GET: Recommends/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recommend recommend = db.Recommends.Find(id);
            if (recommend == null)
            {
                return HttpNotFound();
            }
            return View(recommend);
        }

        // GET: Recommends/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recommends/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,HandbookId,Title")] Recommend recommend)
        {
            if (ModelState.IsValid)
            {
                db.Recommends.Add(recommend);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recommend);
        }

        // GET: Recommends/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recommend recommend = db.Recommends.Find(id);
            if (recommend == null)
            {
                return HttpNotFound();
            }
            return View(recommend);
        }

        // POST: Recommends/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,HandbookId,Title")] Recommend recommend)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recommend).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recommend);
        }

        // GET: Recommends/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recommend recommend = db.Recommends.Find(id);
            if (recommend == null)
            {
                return HttpNotFound();
            }
            return View(recommend);
        }

        // POST: Recommends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recommend recommend = db.Recommends.Find(id);
            db.Recommends.Remove(recommend);
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
