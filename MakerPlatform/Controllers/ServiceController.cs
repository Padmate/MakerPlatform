using MakerPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MakerPlatform.Controllers
{
    public class ServiceController:Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ServiceManagement()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ServiceManage(ServiceViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                return View();
            }

            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            return View(model);
        } 

        //市场平台
        public ActionResult MarketPlatform()
        {
            return View();
        }

        //品牌平台
        public ActionResult BrandPlatform()
        {

            return View();
        }

        //销售平台
        public ActionResult SellPlatform()
        {

            return View();
        }

        //制造平台
        public ActionResult MakePlatform()
        {

            return View();
        }

        //工程平台
        public ActionResult ProjectPlatform()
        {

            return View();
        }

        //产品平台
        public ActionResult ProductPlatform()
        {

            return View();
        }

        //供应链管理
        public ActionResult SupplyManagement()
        {

            return View();
        }

        //导师平台
        public ActionResult TutorPlatform()
        {

            return View();
        }

        //资金平台
        public ActionResult FundPlatform()
        {

            return View();
        }
    }
}