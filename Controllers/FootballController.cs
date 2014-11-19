using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;

namespace MvcApplication2.Controllers
{
    public class FootballController : Controller
    {
        private FootballDBContext db = new FootballDBContext();

        //
        // GET: /Football/

        public ActionResult Index()
        {
            return View(db.Football.ToList());
        }

        //
        // GET: /Football/Details/5

        public ActionResult Details(int id = 0)
        {
            Football football = db.Football.Find(id);
            if (football == null)
            {
                return HttpNotFound();
            }
            return View(football);
        }

        //
        // GET: /Football/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Football/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Football football)
        {
            if (ModelState.IsValid)
            {
                db.Football.Add(football);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(football);
        }

        //
        // GET: /Football/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Football football = db.Football.Find(id);
            if (football == null)
            {
                return HttpNotFound();
            }
            return View(football);
        }

        //
        // POST: /Football/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Football football)
        {
            if (ModelState.IsValid)
            {
                db.Entry(football).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(football);
        }

        //
        // GET: /Football/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Football football = db.Football.Find(id);
            if (football == null)
            {
                return HttpNotFound();
            }
            return View(football);
        }

        //
        // POST: /Football/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Football football = db.Football.Find(id);
            db.Football.Remove(football);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}