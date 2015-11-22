using A7Dashboard.Domain.Models;
using A7Dashboard.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace A7Dashboard.Controllers
{
    public class ApplicationController : Controller
    {
        private ApplicationRepository _repo = new ApplicationRepository();

        // GET: Application
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var target = _repo.GetTargets();
            return View(target);
        }

        // GET: Application/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Application/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Application/Create
        [HttpPost]
        public ActionResult Create(Application app)
        {
            try
            {
                if (app != null)
                {
                    _repo.AddTarget(app);                    
                }

                return RedirectToAction("GetTargets");
            }
            catch
            {
                return View();
            }
        }

        // GET: Application/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Application/Edit/5
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

        // GET: Application/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Application/Delete/5
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
