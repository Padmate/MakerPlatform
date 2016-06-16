using MakerPlatform.Models;
using MakerPlatform.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MakerPlatform.Controllers
{
    public class HomeController : Controller
    {
        MakerDBContext _dbContext = new MakerDBContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Default1()
        {
            ViewBag.From = "Default";
            //活动预告
            List<Article> activityForecastArticles = _dbContext.Atricles
                .Where(a => a.Type == Common.ActivityForecast)
                .OrderByDescending(a => a.Pubtime)
                .Take(3)
                .ToList();
            //精彩活动
            List<Article> wonderfulActivityArticles = _dbContext.Atricles
                .Where(a => a.Type == Common.WonderfulActivity)
                .OrderByDescending(a => a.Pubtime)
                .Take(3)
                .ToList();

            //资讯
            List<Article> informationArticles = _dbContext.Atricles
                .Where(a => a.Type == Common.Information)
                .OrderByDescending(a => a.Pubtime)
                .Take(6)
                .ToList();

            ViewData["activityForecastArticles"] = activityForecastArticles;
            ViewData["wonderfulActivityArticles"] = wonderfulActivityArticles;
            ViewData["informationArticles"] = informationArticles;

            //首页图片
            List<Image> homebgImages = _dbContext.Images
                .Where(i => i.Type == Common.Image_HomeBG)
                .OrderBy(i => i.Sequence)
                .ToList();
            ViewData["homebgImages"] = homebgImages;

            return View();
        }

        public ActionResult Default()
        {
            ViewBag.From = "Default";
            //活动预告
            List<Article> activityForecastArticles = _dbContext.Atricles
                .Where(a => a.Type == Common.ActivityForecast)
                .OrderByDescending(a => a.Pubtime)
                .Take(3)
                .ToList();
            //精彩活动
            List<Article> wonderfulActivityArticles = _dbContext.Atricles
                .Where(a => a.Type == Common.WonderfulActivity)
                .OrderByDescending(a => a.Pubtime)
                .Take(3)
                .ToList();

            //资讯
            List<Article> informationArticles = _dbContext.Atricles
                .Where(a => a.Type == Common.Information)
                .OrderByDescending(a => a.Pubtime)
                .Take(6)
                .ToList();

            ViewData["activityForecastArticles"] = activityForecastArticles;
            ViewData["wonderfulActivityArticles"] = wonderfulActivityArticles;
            ViewData["informationArticles"] = informationArticles;

            //首页图片
            List<Image> homebgImages = _dbContext.Images
                .Where(i=>i.Type == Common.Image_HomeBG)
                .OrderBy(i=>i.Sequence)
                .ToList();
            ViewData["homebgImages"] = homebgImages;

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

        /// <summary>
        /// 系统管理
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public ActionResult SystemManage()
        {
            
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

        #region 背景图片管理

        public List<string> AllowImageExtensions = new List<string>() { ".gif",".jpg",".jpeg",".bmp",".png"};
        private string homebgVirtualFloader = "../img/Upload/homebg/";
        /// <summary>
        /// 获取背景图片
        /// </summary>
        /// <returns></returns>
        public ActionResult GetHomeBGImages()
        {
            var bgImages = _dbContext.Images
                .Where(i=>i.Type == Common.Image_HomeBG)
                .OrderBy(i=>i.Sequence)
                .ToList();

            return Json(bgImages);
           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="images"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateImageSequence()
        {

            StreamReader srRequest = new StreamReader(Request.InputStream);
            String strReqStream = srRequest.ReadToEnd();
            List<ImageViewModel> images = JsonHandler.DeserializeJsonToObject<List<ImageViewModel>>(strReqStream);

            if(images !=null)
            {
                 foreach(var image in images)
                {
                    var model = _dbContext.Images.Where(i=>i.Id == image.Id).FirstOrDefault();
                    if (model != null)
                    {
                        model.Sequence = image.Sequence;
                        _dbContext.SaveChanges();
                    }
                }
            }
           


            return Json(true);
        }

        [HttpPost]
        public ActionResult DeleteImage(int Id)
        {
            Message message = new Message();
            message.Success = true;

            try{
                var image = _dbContext.Images.Where(i => i.Id == Id).FirstOrDefault();
                if (image != null)
                {
                    //删除原来图片
                    if (!string.IsNullOrEmpty(image.ImageUrl))
                    {
                        if (System.IO.File.Exists(Server.MapPath(image.ImageUrl)))
                            System.IO.File.Delete(Server.MapPath(image.ImageUrl));
                    }


                    _dbContext.Images.Remove(image);
                    _dbContext.SaveChanges();
                }

            }catch(Exception e){
                message.Success = false;
                message.Content = "图片删除失败。异常："+e.Message;
               
            }
            return Json(message);
        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="model"></param>
        /// <param name="image"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult UploadHomeBGImage(ImageViewModel model, string id, string name, string type, string lastModifiedDate, int size, HttpPostedFileBase file)
        {
                string virtualUrl = "";
                Message message = new Message();
                message.Success = true;

                try
                {
                    if (file != null)
                    {
                        FileInfo articleImageFile = new FileInfo(file.FileName);
                        string saveName = Guid.NewGuid().ToString() + articleImageFile.Extension;
                        virtualUrl = Path.Combine(homebgVirtualFloader, saveName);
                        string physicleDirectory = Server.MapPath(homebgVirtualFloader);
                        string physicalUrl = Path.Combine(physicleDirectory, saveName);
                        if (!System.IO.Directory.Exists(physicleDirectory))
                        {
                            System.IO.Directory.CreateDirectory(physicleDirectory);
                        }
                        file.SaveAs(physicalUrl);

                    }
                    //图片顺序
                    var totalImages = _dbContext.Images.Where(i => i.Type == Common.Image_HomeBG).ToList();
                    var sequence = totalImages.Count + 1;

                    var imageModel = new Image()
                    {
                        ImageUrl = virtualUrl,
                        Sequence = sequence,
                        Type = Common.Image_HomeBG
                    };

                    _dbContext.Images.Add(imageModel);
                    _dbContext.SaveChanges();

                    
                }catch(Exception e){
                    message.Success = false;
                    message.Content = "上传失败。异常："+e.Message+e.InnerException+e;
                }

                return Json(message);
            
        }

        #endregion

    }
}