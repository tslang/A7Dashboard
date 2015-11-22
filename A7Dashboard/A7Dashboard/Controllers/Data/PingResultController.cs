using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using A7Dashboard.Domain.Repositories;
using A7Dashboard.Infrastructure.Repositories;

namespace A7Dashboard.Controllers
{
    public class PingResultController : Controller
    {
        private PingResultRepository _repo = new PingResultRepository();
  

        // GET: PingResult
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetPingResults()
        {
            var results = _repo.GetAllPingResults();
            return View(results);
        }


        // GET: PingResult/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PingResult/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PingResult/Create
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

        // GET: PingResult/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PingResult/Edit/5
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

        // GET: PingResult/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PingResult/Delete/5
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
