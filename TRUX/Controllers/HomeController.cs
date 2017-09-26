using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TRUX.Controllers
{
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        [Route("~/Index")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("~/Info")]
        public ActionResult Info()
        {
            
            return View();
        }

        [Route("~/Create")]
        public ActionResult Create()
        {
            return View();
        }

        [Route("~/SplashPage")]
        public ActionResult SplashPage()
        {
            return View();
        }

        [Route("~/Search")]
        public ActionResult Search()
        {
            return View();
        }

        [Route("~/EnterRFID")]
        public ActionResult EnterRfid()
        {
            return View();
        }

        [Route("~/ConfirmPickup")]
        public ActionResult ConfirmPickup()
        {
            return View();
        }
    }
}