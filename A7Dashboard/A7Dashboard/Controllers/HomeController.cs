using A7Dashboard.Domain.Repositories;
using A7Dashboard.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace A7Dashboard.Controllers
{
    public class HomeController : Controller
    {
        private ICallRepository _repo = new CallRepository();
        private IRestSharpRepository _rs = new RestSharpRepository();

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            var result = _repo.GetAll();

            return View(result);
        }

    }
}
