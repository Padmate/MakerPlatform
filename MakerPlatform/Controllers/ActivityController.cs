using MakerPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MakerPlatform.Controllers
{
    public class ActivityController:BaseController
    {
        MakerDBContext _dbContext = new MakerDBContext();

        public ActionResult Index()
        {
            return View();
        }
    }
}