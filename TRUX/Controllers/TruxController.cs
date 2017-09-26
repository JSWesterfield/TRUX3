using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TRUX.Models
{
    public class TruxController : Controller
    {

        // GET: Trux
        public ActionResult Index()
        {
            return View("~/Index");
        }

        public ActionResult Create()
        {
            return View("~/Create");
        }
    }
}