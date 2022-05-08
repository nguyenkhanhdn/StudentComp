using StudentComp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentComp.Controllers
{
    public class HomeController : Controller
    {
        private EventDbContext db = new EventDbContext();

        // GET: Handbooks

        public ActionResult Index()
        {
            var handbooks = db.Handbooks.OrderBy(r => Guid.NewGuid()).Take(5);
            return View(handbooks);
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Calendar()
        {
            return View();
        }
        public ActionResult Recommend()
        {
            return View(db.Handbooks.OrderByDescending(h=>h.Id).ToList().Take(5));
        }
        public ActionResult PomoTimer()
        {
            return View();
        }
        public JsonResult GetEvents()
        {
            using (EventDbContext dc = new EventDbContext())
            {
                var events = dc.Events.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        [HttpPost]
        public JsonResult SaveEvent(Event e)
        {
            //return new JsonResult();
            var status = false;
            using (EventDbContext dc = new EventDbContext())
            {
                if (e.EventID > 0)
                {
                    //Update the event
                    var v = dc.Events.Where(a => a.EventID == e.EventID).FirstOrDefault();
                    if (v != null)
                    {
                        v.Subject = e.Subject;
                        v.Start = e.Start;
                        v.End = e.End;
                        v.Description = e.Description;
                        v.IsFullDay = e.IsFullDay;
                        v.ThemeColor = e.ThemeColor;
                    }
                }
                else
                {
             
                    dc.Events.Add(e);
                }

                dc.SaveChanges();
                status = true;

            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            var status = false;
            using (EventDbContext dc = new EventDbContext())
            {
                var v = dc.Events.Where(a => a.EventID == eventID).FirstOrDefault();
                if (v != null)
                {
                    dc.Events.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
            //return new JsonResult();
        }
    }
}