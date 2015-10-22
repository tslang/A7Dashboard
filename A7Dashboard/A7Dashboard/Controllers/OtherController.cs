using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace A7Dashboard.Controllers
{
    public class OtherController : Controller
    {
        // GET: Other
        public ActionResult Index()
        {
            return View();
        }

        // GET: Other/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Other/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Other/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Other/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Other/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Other/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Other/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
