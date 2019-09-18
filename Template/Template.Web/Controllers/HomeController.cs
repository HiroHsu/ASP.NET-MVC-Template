using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Template.Service.Test;

namespace Template.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITestService _ITestService;

        public HomeController(ITestService testService)
        {
            this._ITestService = testService;
        }
        public ActionResult Index()
        {
            ViewBag.Title = _ITestService.GetString();

            return View();
        }
    }
}
