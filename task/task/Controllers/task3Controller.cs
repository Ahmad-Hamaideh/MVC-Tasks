using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using task.Models;

namespace task.Controllers
{
    public class task3Controller : Controller
    {
        private MvcEntities2 db = new MvcEntities2();

        // GET: task3
        public async Task<ActionResult> Index()
        {
            return View(await db.task3.ToListAsync());
        }

        // GET: task3/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            task3 task3 = await db.task3.FindAsync(id);
            if (task3 == null)
            {
                return HttpNotFound();
            }
            return View(task3);
        }

        // GET: task3/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: task3/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "First_Name,id,Last_Name,E_mail,phone,Age,jop_title,Gender")] task3 task3)
        {
            if (ModelState.IsValid)
            {
                db.task3.Add(task3);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(task3);
        }

        // GET: task3/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            task3 task3 = await db.task3.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "First_Name,id,Last_Name,E_mail,phone,Age,jop_title,Gender")] task3 task3)
        {
            if (ModelState.IsValid)
            {
                db.Entry(task3).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(task3);
        }

        // GET: task3/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            task3 task3 = await db.task3.FindAsync(id);
            if (task3 == null)
            {
                return HttpNotFound();
            }
            return View(task3);
        }

        // POST: task3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            task3 task3 = await db.task3.FindAsync(id);
            db.task3.Remove(task3);
            await db.SaveChangesAsync();
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
