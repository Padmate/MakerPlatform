﻿using MakerPlatform.Models;
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
            List<string> bgImageUrls = new List<string>();
            string physicleDirectory = Server.MapPath(homebgVirtualFloader);


            string[] allFiles = System.IO.Directory.GetFiles(physicleDirectory);
            foreach (string file in allFiles)
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(file);
                if (AllowImageExtensions.Contains(fi.Extension.ToLower()))
                {
                    var imageUrl = Path.Combine(homebgVirtualFloader, fi.Name);
                    bgImageUrls.Add(imageUrl);

                }
            }
            return Json(bgImageUrls);
        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="model"></param>
        /// <param name="image"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult UploadHomeBGImage(ImageViewModel model, HttpPostedFileBase bgImage)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string virtualUrl = "";
                    if (bgImage != null)
                    {
                        FileInfo articleImageFile = new FileInfo(bgImage.FileName);
                        string saveName = Guid.NewGuid().ToString() + articleImageFile.Extension;
                        virtualUrl = Path.Combine(homebgVirtualFloader, saveName);
                        string physicleDirectory = Server.MapPath(homebgVirtualFloader);
                        string physicalUrl = Path.Combine(physicleDirectory, saveName);
                        if (!System.IO.Directory.Exists(physicleDirectory))
                        {
                            System.IO.Directory.CreateDirectory(physicleDirectory);
                        }
                        bgImage.SaveAs(physicalUrl);

                    }

                    var imageModel = new Image()
                    {
                        ImageUrl = virtualUrl,
                        Sequence = model.Sequence,
                        Type = Common.Image_HomeBG
                    };

                    _dbContext.Images.Add(imageModel);
                    _dbContext.SaveChanges();

                    return View(model);
                    
                }catch(Exception e){
                    ModelState.AddModelError("", "上传失败:" + e.Message);
                    return View(model);
                }
                
            }

            return View(model);
            
        }
        #endregion

    }
}