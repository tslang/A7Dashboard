using A7Dashboard.Domain.Models;
using A7Dashboard.Domain.Repositories;
using A7Dashboard.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace A7Dashboard.Controllers
{
    public class MonitorController : Controller
    {
        private RestSharp _rs = new RestSharp();
        private ICallRepository _repo = new CallRepository();

        // GET: Monitor
        public ActionResult Index()
        {
            var result = _repo.GetAll();
            return View(result);
        }

        public ActionResult CallResults()
        {
            var result = _rs.SendCall();
            return View(result);
        }

        [HttpGet]
        public ActionResult CreateCall()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCall(Call call)
        {         
                _repo.AddCall(call);
                return RedirectToAction("Index");
        }
    }
}