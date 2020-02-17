using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce_Project_Three.Controllers
{
    public class PartialController : Controller
    {
        public PartialViewResult LoginPartial()
        {
            bool model = true;
            List<int> desktopWallpaperIds = (List<int>)Session["desktopWallpaperIds"];
            if(desktopWallpaperIds == null || desktopWallpaperIds.Count == 0)
            {
                model = false;
            }
            return PartialView("~/Views/Shared/_LoginPartial.cshtml", model);
        }
    }
}