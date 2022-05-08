using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using StudentComp.Models;

namespace StudentComp.Controllers
{
    public class HandbooksController : Controller
    {
        private EventDbContext db = new EventDbContext();

        // GET: Handbooks

        public ActionResult Index()
        {
            var handbooks = db.Handbooks.ToList();
            handbooks.OrderByDescending(v => v.Id);
            return View(handbooks);
        }
        [HttpPost]
        public ActionResult Index(string searchString, int? page)
        {
            int recordsPerPage = 8;

            if (!page.HasValue)
            {
                page = 1; // set initial page value
            }
            ViewBag.Keyword = searchString;

            var handbooks = db.Handbooks.ToList();
            try
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    handbooks = handbooks.Where(s => s.Content.Contains(searchString)).ToList();
                }
            }
            catch (Exception ex) { }
            handbooks.OrderByDescending(v => v.Id);

            var finalList = handbooks.ToPagedList(page.Value, recordsPerPage);
            return View(finalList);
        }

        // GET: Handbooks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Handbook handbook = db.Handbooks.Find(id);

            Recommend recommend = db.Recommends.Where(r => r.HandbookId == id).FirstOrDefault();
            string recomm = recommend.RecommendArticle;
            ViewBag.RecommendArticle = recomm;
            
            if (handbook == null)
            {

                return HttpNotFound();
            }
            handbook.Hit += 1;

            Read read = new Read();
            read.HbId = id;
            read.UserName = User.Identity.Name;
            db.Reads.Add(read);
            db.SaveChanges();
            return View(handbook);
        }

        // GET: Handbooks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Handbooks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,Brief,Content,Type")] Handbook handbook)
        {
            if (ModelState.IsValid)
            {
                handbook.CreatedDate = DateTime.Today.Date;
                handbook.Hit = 0;
                db.Handbooks.Add(handbook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(handbook);
        }

        // GET: Handbooks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Handbook handbook = db.Handbooks.Find(id);
            if (handbook == null)
            {
                return HttpNotFound();
            }
            return View(handbook);
        }

        // POST: Handbooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Brief,CreatedDate,Content,Type,Hit")] Handbook handbook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(handbook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(handbook);
        }

        // GET: Handbooks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Handbook handbook = db.Handbooks.Find(id);
            if (handbook == null)
            {
                return HttpNotFound();
            }
            return View(handbook);
        }

        // POST: Handbooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Handbook handbook = db.Handbooks.Find(id);
            db.Handbooks.Remove(handbook);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Rate(string vote)
        {
            string[] array = vote.Split('-');
            int id = int.Parse(array[0]);
            decimal rate = decimal.Parse(array[1]);
            Handbook hb = db.Handbooks.Find(id);
            if (hb != null)
            {
                hb.Rates.Add(new Models.Rate() { HandbookId = id, Rate1 = rate });
                db.SaveChanges();
            }

            ViewBag.Vote = vote;
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Comment(int handbookId, string userName, string comment, string returnUrl)
        {
            Comment cmt = new Models.Comment();
            cmt.HandbookId = handbookId;
            cmt.UserName = userName;
            cmt.CommentDate = DateTime.Today;
            cmt.Comment1 = comment;

            db.Comments.Add(cmt);
            db.SaveChanges();
            return RedirectToAction("../" + returnUrl);
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
