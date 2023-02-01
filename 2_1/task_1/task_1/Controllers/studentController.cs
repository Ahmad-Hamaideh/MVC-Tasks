using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using task_1.Models;

namespace task_1.Controllers
{
    public class studentController : Controller
    {
        // GET: student
        public ActionResult Index()
        {
            student st = new student();
            st.Name = "Ahmad Hamaideh";
            st.Age= 21;
            st.Faculity = "IT";

            return View(st);
        }
    }
}