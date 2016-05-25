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
    public class ArticleController:BaseController
    {
        MakerDBContext _dbContext = new MakerDBContext();

        public ActionResult Index()
        {
            //活动预告
            List<Article> activityForecastArticles = _dbContext.Atricles
                .Where(a => a.Type == Common.ActivityForecast)
                .OrderByDescending(a=>a.Pubtime)
                .ToList();
            //精彩活动
            List<Article> wonderfulActivityArticles = _dbContext.Atricles
                .Where(a => a.Type == Common.WonderfulActivity)
                .OrderByDescending(a => a.Pubtime)
                .ToList();

            ViewData["activityForecastArticles"] = activityForecastArticles;
            ViewData["wonderfulActivityArticles"] = wonderfulActivityArticles;

            return View();
        }

        public ActionResult ShowContent(string id)
        {
            
            try
            {
                if (string.IsNullOrEmpty(id))
                    return RedirectToAction("Error", "Home");
                Int32 articleId = System.Convert.ToInt32(id);
                var article = _dbContext.Atricles.FirstOrDefault(a => a.Id == articleId);

                if (article == null)
                    return RedirectToAction("Error", "Home");

                ViewData["article"] = article;

            }catch(Exception e)
            {
                return RedirectToAction("Error","Home");
            }
            
            return View();
        }

        [HttpGet]
        [Authorize(Roles="Admin")]
        public ActionResult Add()
        {
            return View();
        }

         // POST:
        [HttpPost]
        [ValidateInput(false)]
        [Authorize(Roles="Admin")]
        public ActionResult Add(ArticleViewModel model,HttpPostedFileBase articleImage,string returnUrl)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    string virtualUrl = "";
                    if(articleImage != null)
                    {
                        FileInfo articleImageFile = new FileInfo(articleImage.FileName);
                        string saveName = Guid.NewGuid().ToString() + articleImageFile.Extension;
                        string virtualFloder = "../img/Articles/";
                        virtualUrl = Path.Combine(virtualFloder, saveName);
                        string physicalUrl = Path.Combine(Server.MapPath(virtualFloder), saveName);
                        articleImage.SaveAs(physicalUrl);
                    }
                    

                    var article = new Article()
                    {
                        Title = model.Title,
                        SubTitle = model.SubTitle,
                        Description = model.Description,
                        ArticleImage = virtualUrl,
                        Content = model.Content,
                        CreateDate = DateTime.Now,
                        Creator = User.Identity.Name,
                        Pubtime =model.Pubtime,
                        Type = model.ArticleType
                    };

                    _dbContext.Atricles.Add(article);
                    _dbContext.SaveChanges();
                    //返回文章显示页面
                    return Redirect("/Article/ShowContent?id="+article.Id.ToString());

                }catch(Exception e)
                {
                    ModelState.AddModelError("", "发布异常:"+e.Message);
                    return View(model);
                }
                
            }
            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            return View(model);
        }  

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(string id)
        {

            try
            {
                if (string.IsNullOrEmpty(id))
                    return RedirectToAction("Error", "Home");
                Int32 articleId = System.Convert.ToInt32(id);
                var article = _dbContext.Atricles.FirstOrDefault(a => a.Id == articleId);

                if (article == null)
                    return RedirectToAction("Error", "Home");

                ViewData["article"] = article;

            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Home");
            }

            return View();
        }

        // POST:
        [HttpPost]
        [ValidateInput(false)]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(ArticleViewModel model, HttpPostedFileBase articleImage, string returnUrl)
        {
            var article = _dbContext.Atricles.FirstOrDefault(a => a.Id == model.Id);
            ViewData["article"] = article;
            if (ModelState.IsValid)
            {
                try
                {


                    string virtualUrl = article.ArticleImage;
                    if (articleImage != null)
                    {
                        //保存图片
                        FileInfo articleImageFile = new FileInfo(articleImage.FileName);
                        string saveName = Guid.NewGuid().ToString() + articleImageFile.Extension;
                        string virtualFloder = "../img/Articles/";
                        virtualUrl = Path.Combine(virtualFloder, saveName);
                        string physicalUrl = Path.Combine(Server.MapPath(virtualFloder), saveName);
                        articleImage.SaveAs(physicalUrl);

                        //删除原来图片
                        if (!string.IsNullOrEmpty(article.ArticleImage))
                        {
                            if (System.IO.File.Exists(Server.MapPath(article.ArticleImage)))
                                System.IO.File.Delete(Server.MapPath(article.ArticleImage));
                        }

                    }


                    article.Title = model.Title;
                    article.SubTitle = model.SubTitle;
                    article.Description = model.Description;
                    article.ArticleImage = virtualUrl;
                    article.Content = model.Content;
                    article.ModifiedDate = DateTime.Now;
                    article.Modifier = User.Identity.Name;
                    article.Pubtime = DateTime.Now;
                    

                    _dbContext.SaveChanges();
                    //返回文章显示页面
                    return Redirect("/Article/ShowContent?id=" + article.Id.ToString());

                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", "发布异常:" + e.Message);
                    return View(model);
                }

            }
            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            return View(model);
        }  

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Int32 id)
        {
            var article = _dbContext.Atricles.FirstOrDefault(a => a.Id == id);
            //删除图标
            //删除原来图片
            if (!string.IsNullOrEmpty(article.ArticleImage))
            {
                if (System.IO.File.Exists(Server.MapPath(article.ArticleImage)))
                    System.IO.File.Delete(Server.MapPath(article.ArticleImage));
            }

            _dbContext.Atricles.Remove(article);
            _dbContext.SaveChanges();
            return RedirectToAction("Index","Article"); ;
        }
    }
}