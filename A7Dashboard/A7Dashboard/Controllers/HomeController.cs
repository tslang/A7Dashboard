
using A7Dashboard.Domain.Models;
using A7Dashboard.Hubs;
using A7Dashboard.Infrastructure.Repositories;
using A7Dashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace A7Dashboard.Controllers
{
    public class HomeController : Controller 
    {
        private PingResultRepository _repo = new PingResultRepository();

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";   
            return View();
        }

        public ActionResult Status()
        {

            return PartialView("~/Views/Shared/_PingResults.cshtml", _repo.GetAllPingResults());
        }


    }
}
