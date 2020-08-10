using INSTA_APP.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using INSTA_APP.Models;

namespace INSTA_APP.Controllers
{
    public class HomeController : Controller
    {
        private INSTA_APPEntities db = new INSTA_APPEntities();
        private PanelLogic BLL = new PanelLogic();
        public ActionResult Index()
        {

            return View();
        }
        public PartialViewResult All()
        {
            List<profil> model = db.profils.ToList();
            return PartialView("_profil", model);
        }
        public PartialViewResult UpocomingTop3()
        {
            List<profil> model = db.profils.OrderByDescending(x => x.datum_rodjenja).Take(3).ToList();
            return PartialView("_profil", model);
        }
        public PartialViewResult Bottom3()
        {
            List<profil> model = db.profils.OrderBy(x => x.datum_rodjenja).Take(3).ToList();
            return PartialView("_profil", model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //public JsonResult FindProfile(string SearchBox)
        //{

        //    //var data = BLL.FindProfile(SearchBox);

        //    return Json(data, JsonRequestBehavior.AllowGet);

        //}
    }
}