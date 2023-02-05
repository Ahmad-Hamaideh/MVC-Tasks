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
using System.IO;
using System.Web.UI.WebControls;

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
        [HttpPost]
        public ActionResult Index(string em , string by )
        {
          
            if(by == "fname")
            {
                return View( db.task3.Where(e => e.First_Name .Contains( em )).ToList() );
            }
            else if (by == "email")
            {
                return View(db.task3.Where(e => e.E_mail.Contains(em) ).ToList());
            }
            else if (by == "Age")
            {
                return View(db.task3.Where(e => e.Age.ToString().Contains(em)).ToList());
            }
            else
            {
                return View(db.task3.Where(e => e.Age.ToString().Contains(em) || e.First_Name.Contains(em) || e.Last_Name.Contains(em) || e.E_mail.Contains(em)).ToList());
            }

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
        public async Task<ActionResult> Create([Bind(Include = "First_Name,id,Last_Name,E_mail,phone,Age,jop_title,Gender ,img ,filee" )]   task3 task3 , HttpPostedFileBase image, HttpPostedFileBase cv)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    //string fileName = Path.GetFileName(image.FileName);
                    string path = Server.MapPath("~/Images/") + image.FileName;
                    image.SaveAs(path);
                    task3.img = image.FileName;
                }

                if (cv != null)
                {
                    //string fileName = Path.GetFileName(cv.FileName);
                    string path = Server.MapPath("~/CVs/") + cv.FileName;
                    cv.SaveAs(path);
                    task3.filee = cv.FileName;
                }


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
        public async Task<ActionResult> Edit([Bind(Include = "First_Name,id,Last_Name,E_mail,phone,Age,jop_title,Gender ,img ,filee")] task3 task3, HttpPostedFileBase image, HttpPostedFileBase cv)
        {
          

            if (ModelState.IsValid)
            {


                string imgPath = "";
                string cvPath = "";
                if (image != null)
                {
                    imgPath = Path.GetFileName(image.FileName);
                    image.SaveAs(Path.Combine(Server.MapPath("~/image/") + image.FileName));

                    task3.img = imgPath;
                }
             

                if (cv != null)
                {
                    cvPath = Path.GetFileName(cv.FileName);
                    cv.SaveAs(Path.Combine(Server.MapPath("~/CVs/") + cv.FileName));

                    task3.filee = cvPath;
                }

            
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
