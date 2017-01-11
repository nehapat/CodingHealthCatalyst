using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCWebApp.Models;

namespace MVCWebApp.Controllers
{
    public class PeopleController : Controller
    {
        private PeopleDataDBContext db = new PeopleDataDBContext();

        // GET: People
        public ActionResult Index()
        {
            return View(db.People.ToList());
        }

        // GET: People/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            People peopleData = db.People.Find(id);
            if (peopleData == null)
            {
                return HttpNotFound();
            }
            return View(peopleData);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Address,Age,Image")] People peopleData)
        {
            if (ModelState.IsValid)
            {
                db.People.Add(peopleData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(peopleData);
        }

        // GET: People/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            People peopleData = db.People.Find(id);
            if (peopleData == null)
            {
                return HttpNotFound();
            }
            return View(peopleData);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Address,Age,Image")] People peopleData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(peopleData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(peopleData);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            People peopleData = db.People.Find(id);
            if (peopleData == null)
            {
                return HttpNotFound();
            }
            return View(peopleData);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            People peopleData = db.People.Find(id);
            db.People.Remove(peopleData);
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
