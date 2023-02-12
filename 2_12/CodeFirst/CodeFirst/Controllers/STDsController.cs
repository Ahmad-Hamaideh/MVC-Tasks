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
{ [HandleError(View = "error")]
    public class STDsController : Controller
    {
       

        private MvcEntities db = new MvcEntities();

        // GET: STDs
        public ActionResult Index()
        {
            return View(db.STDs.ToList());
        }
        public ActionResult error()
        {
            return View("error");
        }
        // GET: STDs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STD sTD = db.STDs.Find(id);
            if (sTD == null)
            {
                return HttpNotFound();
            }
            return View(sTD);
        }

        // GET: STDs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: STDs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StudentName,Age")] STD sTD)
        {
            if (ModelState.IsValid)
            {
                db.STDs.Add(sTD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sTD);
        }

        // GET: STDs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STD sTD = db.STDs.Find(id);
            if (sTD == null)
            {
                return HttpNotFound();
            }
            return View(sTD);
        }

        // POST: STDs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StudentName,Age")] STD sTD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sTD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sTD);
        }

        // GET: STDs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STD sTD = db.STDs.Find(id);
            if (sTD == null)
            {
                return HttpNotFound();
            }
            return View(sTD);
        }

        // POST: STDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            STD sTD = db.STDs.Find(id);
            db.STDs.Remove(sTD);
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
