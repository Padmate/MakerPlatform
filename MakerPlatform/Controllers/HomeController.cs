using MakerPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MakerPlatform.Controllers
{
    public class HomeController : Controller
    {
        private MakerDBContext _dbContext = new MakerDBContext();

        public ActionResult Index()
        {
            var serviceTypes = _dbContext.ServiceTypes
                .Include("ServiceModules")
                .ToList();

            ViewData["ServiceTypes"] = serviceTypes;
            return View();
        }

        public ActionResult Default()
        {
            var serviceTypes = _dbContext.ServiceTypes
                .ToList();

            ViewData["ServiceTypes"] = serviceTypes;
            return View();
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

        public ActionResult SystemManage()
        {
           
            return View();
        }
    }
}