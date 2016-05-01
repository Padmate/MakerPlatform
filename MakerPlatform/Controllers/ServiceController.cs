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

        
        public ActionResult Index()
        {
            var serviceTypes = _dbContext.ServiceTypes
                .Include("ServiceModules")
                .ToList();

            ViewData["ServiceTypes"] = serviceTypes;
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

        /// <summary>
        /// Display ServiceContent
        /// </summary>
        /// <returns></returns>
        public ActionResult ServiceContent(string typeCode)
        {
            var serviceType = _dbContext.ServiceTypes
               .Include("ServiceModules")
               .FirstOrDefault(s => s.TypeCode == typeCode)
;

            ViewData["ServiceType"] = serviceType;

            return View();

        }

        
    }
}