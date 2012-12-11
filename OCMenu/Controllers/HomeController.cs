using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OCMenu.Models;

namespace OCMenu.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            Cafeteria c = new Cafeteria();

            c.readXML();

            return View(c);
        }

    }
}
