using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MakerPlatform.Controllers
{
    public class ArticleController:BaseController
    {
        public ActionResult Index(string type)
        {
            ViewData["type"] = type;
            return View();
        }

        public ActionResult ShowContent(string type,string articletype)
        {
            ViewData["type"] = type;
            ViewData["articletype"] = articletype;
            
            return View();
        }
    }
}