using System;
using System.Linq;
using System.Web.Mvc;
using EF.Models;

namespace EF.Controllers {
    public class EFDatabaseServerModeController : Controller {
        NorthwindContext db = new NorthwindContext();

        public ActionResult Index() {
            return View();
        }

        public ActionResult GridViewPartial() {
            return PartialView(db.Orders);
        }
    }
}