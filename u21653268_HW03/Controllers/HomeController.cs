using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using u21653268_HW03.Models;

namespace u21653268_HW03.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Home()
        {
            ViewBag.Message = "Welcome to your MediaMaster Home page.";
            return View();
        }

        [HttpPost]
        public ActionResult Home(HttpPostedFileBase File, string FileType)
        {
            if(File != null && File.ContentLength > 0)
            {
                var fileName = Path.GetFileName(File.FileName);
                var fileType = FileType + "s/";
                var path = Path.Combine(Server.MapPath("~/Media/" + fileType), fileName);

                File.SaveAs(path);
            }
            
            return RedirectToAction("Home");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Who is Tifuh?";

            return View();
        }
    }
}