using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodeFirst.Models;

namespace CodeFirst.Controllers
{
    [HandleError(View = "Error")]
    public class CORstdsController : Controller
    {

        private MvcEntities db = new MvcEntities();

        // GET: CORstds
        public ActionResult Index()
        {
            var cORstds = db.CORstds.Include(c => c.Course).Include(c => c.STD);
            return View(cORstds.ToList());
        }

        // GET: CORstds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CORstd cORstd = db.CORstds.Find(id);
            if (cORstd == null)
            {
                return HttpNotFound();
            }
            return View(cORstd);
        }

        // GET: CORstds/Create
        public ActionResult Create()
        {
            ViewBag.CorID = new SelectList(db.Courses, "CID", "Name");
            ViewBag.StdID = new SelectList(db.STDs, "ID", "StudentName");
            return View();
        }

        // POST: CORstds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CorID,StdID,xx")] CORstd cORstd)
        {
            if (ModelState.IsValid)
            {
                db.CORstds.Add(cORstd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CorID = new SelectList(db.Courses, "CID", "Name", cORstd.CorID);
            ViewBag.StdID = new SelectList(db.STDs, "ID", "StudentName", cORstd.StdID);
            return View(cORstd);
        }

        // GET: CORstds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CORstd cORstd = db.CORstds.Find(id);
            if (cORstd == null)
            {
                return HttpNotFound();
            }
            ViewBag.CorID = new SelectList(db.Courses, "CID", "Name", cORstd.CorID);
            ViewBag.StdID = new SelectList(db.STDs, "ID", "StudentName", cORstd.StdID);
            return View(cORstd);
        }

        // POST: CORstds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CorID,StdID,xx")] CORstd cORstd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cORstd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CorID = new SelectList(db.Courses, "CID", "Name", cORstd.CorID);
            ViewBag.StdID = new SelectList(db.STDs, "ID", "StudentName", cORstd.StdID);
            return View(cORstd);
        }

        // GET: CORstds/Delete/5
            
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CORstd cORstd = db.CORstds.Find(id);
            if (cORstd == null)
            {
                return HttpNotFound();
            }
            return View(cORstd);
        }

        // POST: CORstds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CORstd cORstd = db.CORstds.Find(id);
            db.CORstds.Remove(cORstd);
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
