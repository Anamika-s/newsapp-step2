using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using News_WebApp.Models;
using News_WebApp.Repository;

namespace News_WebApp.Controllers
{
    public class NewsController : Controller
    {
        INewsRepository _newsRepo;
        IWebHostEnvironment _webhost;
        public NewsController(INewsRepository newsRepository , IWebHostEnvironment  webHostEnvironment )
        {
            _newsRepo = newsRepository;
            _webhost = webHostEnvironment;
        }
        // GET: NewsController
        public async Task<ActionResult> Index()
           
            {
            if (TempData["userId"] != null)
            {
                ViewBag.userId = TempData["userId"].ToString();
                TempData["user"] = ViewBag.userId;
            }
             if (TempData["msg"] != null)
            {
                ViewBag.msg = TempData["msg"].ToString();
            }
            List<News> news = await _newsRepo.GetAllNews(ViewBag.userId);
            return View(news);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(News news)
        { 
            
            if (TempData["user"] != null)
            {
                
                news.UserId = TempData["user"].ToString();
            }


            string wwwRootPath = _webhost.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(news.urlImage.FileName);
            string extension = Path.GetExtension(news.urlImage.FileName);
            fileName = fileName + extension;
            news.UrlToImage = fileName.ToString();
            string path = Path.Combine(wwwRootPath+ "/images/" + fileName );
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                await news.urlImage.CopyToAsync(fs);
            }

            News obj= await _newsRepo.AddNews(news);
            if (obj != null)
            {
                TempData["msg"] = "Record inserted";
                TempData["userId"] = news.UserId;
            }
            else
            {
                TempData["userId"] = news.UserId;
                TempData["msg"] = "News with this title already exist";
            }
            return RedirectToAction("Index");
        }
        
        

        

        

        

        // GET: NewsController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            News news = await _newsRepo.GetNewsById(id);
            if (news != null)
                return View(news);
            else
            {
                TempData["msg"] = "Rceord with this ID does not exist";
                return RedirectToAction("Index");
            }
        }

        // POST: NewsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id , News news)
        {
            var obj = await _newsRepo.GetNewsById(id);
            if (obj != null)
            {
                // delete image from folder
                var imagePath =  Path.Combine(_webhost.WebRootPath, "images", obj.UrlToImage);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);

                }
            }
            bool flag = await _newsRepo.RemoveNews(id);
            if (flag == true)
            {
                TempData["msg"] = "Record Deleted";
                return RedirectToAction("Index");
            }
            else
                return View();
        }
    }
}
