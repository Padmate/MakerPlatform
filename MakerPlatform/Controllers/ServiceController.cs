using MakerPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MakerPlatform.Controllers
{
    
    public class ServiceController:BaseController
    {
        private MakerDBContext _dbContext = new MakerDBContext();

        
        public ActionResult Index(string typeCode)
        {
            if(string.IsNullOrEmpty(typeCode))
            {
                return RedirectToAction("Default", "Home");
            }

            var serviceType = _dbContext.ServiceTypes
              .Include("ServiceModules")
              .FirstOrDefault(s => s.TypeCode == typeCode)
;           
            //构造模块菜单按钮
            List<TopNavMenuModel> topNavMenus = null;
            if(serviceType !=null)
            {
                topNavMenus = serviceType.ServiceModules.Select(s => new TopNavMenuModel()
                {
                    Href = s.ModuleCode,
                    Name = s.ModuleName
                }).ToList();
            }

            ViewData["ServiceType"] = serviceType;
            ViewData["TopNavMenus"] = topNavMenus;
            return View();
        }

        [Authorize]
        public ActionResult ServiceManage()
        {
            var serviceTypes = _dbContext.ServiceTypes
               .Include("ServiceModules")
               .ToList();

            ViewData["ServiceTypes"] = serviceTypes;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult GetServiceModuleByServiceType(string TypeCode)
        {
            List<ServiceModuleModel> serviceModules = new List<ServiceModuleModel>();
            var serviceType = _dbContext.ServiceTypes.FirstOrDefault(s => s.TypeCode == TypeCode);
            if(serviceType !=null)
            {
                serviceModules = _dbContext.ServiceModules
                    .Where(s => s.ServiceTypeId == serviceType.Id)
                    .Select(s => new ServiceModuleModel() { 
                        Id = s.Id,
                        ModuleCode = s.ModuleCode,
                        ModuleName = s.ModuleName,
                        ModuleContent = s.ModuleContent
                    })
                    .ToList();

            }

            return Json(serviceModules);

        }

        [Authorize]
        [HttpPost]
        public ActionResult GetServiceModuleByModuleCode(string ModuleCode)
        {
            var serviceModule = _dbContext.ServiceModules
                .Select(s => new ServiceModuleModel() {
                    Id = s.Id,
                    ModuleCode = s.ModuleCode,
                    ModuleName = s.ModuleName,
                    ModuleContent = s.ModuleContent
                })
                .FirstOrDefault(s => s.ModuleCode == ModuleCode);

            return Json(serviceModule);

        }

        // POST: /Account/Login
        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SaveServiceContent(ServiceViewModel model)
        {
            Message message = new Message();
            message.Success = true;
            message.Content = "保存成功";
            if (ModelState.IsValid)
            {
                var serviceModule = _dbContext.ServiceModules.FirstOrDefault(s => s.ModuleCode == model.ServiceModuleCode);
                serviceModule.ModuleContent = model.ServiceModuleContent;
                _dbContext.SaveChanges();
            }
            else
            {
                message.Success = false;
                message.Content = ModelStateError();
                return Json(message);
            }
            return Json(message);
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