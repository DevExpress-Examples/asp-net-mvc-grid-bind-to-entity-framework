using System;
using System.Web.Mvc;

namespace EF.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }
    }
}