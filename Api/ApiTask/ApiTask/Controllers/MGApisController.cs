using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ApiTask.Models;

namespace ApiTask.Controllers
{
    public class MGApisController : Controller
    {
        private MvcEntities db = new MvcEntities();

        // GET: MGApis
        public ActionResult Index(int?id)
        {
            var mGApis = db.MGApis.Where(m => m.CLLApi.IdCLL == id );
            return View(mGApis.ToList());
        }

        // GET: MGApis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MGApi mGApi = db.MGApis.Find(id);
            if (mGApi == null)
            {
                return HttpNotFound();
            }
            return View(mGApi);
        }

        // GET: MGApis/Create
        public ActionResult Create()
        {
            ViewBag.idCLL = new SelectList(db.CLLApis, "IdCLL", "NameCLL");
            return View();
        }

        // POST: MGApis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMG,NameMG,idCLL")] MGApi mGApi)
        {
            if (ModelState.IsValid)
            {
                db.MGApis.Add(mGApi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCLL = new SelectList(db.CLLApis, "IdCLL", "NameCLL", mGApi.idCLL);
            return View(mGApi);
        }

        // GET: MGApis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MGApi mGApi = db.MGApis.Find(id);
            if (mGApi == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCLL = new SelectList(db.CLLApis, "IdCLL", "NameCLL", mGApi.idCLL);
            return View(mGApi);
        }

        // POST: MGApis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMG,NameMG,idCLL")] MGApi mGApi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mGApi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCLL = new SelectList(db.CLLApis, "IdCLL", "NameCLL", mGApi.idCLL);
            return View(mGApi);
        }

        // GET: MGApis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MGApi mGApi = db.MGApis.Find(id);
            if (mGApi == null)
            {
                return HttpNotFound();
            }
            return View(mGApi);
        }

        // POST: MGApis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MGApi mGApi = db.MGApis.Find(id);
            db.MGApis.Remove(mGApi);
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
