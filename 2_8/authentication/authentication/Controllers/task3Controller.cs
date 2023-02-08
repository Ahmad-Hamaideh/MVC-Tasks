using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using authentication.Models;

namespace authentication.Controllers
{
    [Authorize]
    public class task3Controller : Controller
    {
        private mvcEntities db = new mvcEntities();

        // GET: task3
        public ActionResult Index()
        {
            return View(db.task3.ToList());
        }

        // GET: task3/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            task3 task3 = db.task3.Find(id);
            if (task3 == null)
            {
                return HttpNotFound();
            }
            return View(task3);
        }

        [Authorize (Roles ="Admin")]
        // GET: task3/Create
        public ActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        // POST: task3/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "First_Name,id,Last_Name,E_mail,jop_title,img")] task3 task3  ,HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    //string fileName = Path.GetFileName(image.FileName);
                    string path = Server.MapPath("~/image/") + image.FileName;
                    image.SaveAs(path);
                    task3.img = image.FileName;
                }

            

                db.task3.Add(task3);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(task3);
        }

        // GET: task3/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            task3 task3 = db.task3.Find(id);
            if (task3 == null)
            {
                return HttpNotFound();
            }
            return View(task3);
        }

        // POST: task3/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "First_Name,id,Last_Name,E_mail,phone,Age,jop_title,Gender,img,filee")] task3 task3)
        {
            if (ModelState.IsValid)
            {
                db.Entry(task3).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(task3);
        }

        // GET: task3/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            task3 task3 = db.task3.Find(id);
            if (task3 == null)
            {
                return HttpNotFound();
            }
            return View(task3);
        }

        // POST: task3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            task3 task3 = db.task3.Find(id);
            db.task3.Remove(task3);
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
