using MvcMovie.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovie.Controllers
{
    public class HomeController : Controller
    {
        private MusicStoreEntities storeDB = new MusicStoreEntities();
       
        
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Video video)
        {
            foreach (var file in video.Files)
            {
                if (file.ContentLength <= 0) return null;
                {

                    var fileName = Path.GetFileName(file.FileName);
          
                    if (fileName == null) return null;
                    var path = Path.Combine(Server.MapPath("~/Content/Videos"), fileName);
                    file.SaveAs(path);
                }
            }
                return RedirectToAction("Index");
            
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        // GET: /Store/GenreMenu
        public string Browse(string genre)
        {
            string message = HttpUtility.HtmlEncode("Store.Browse, Genre = " + genre);

            return message;
        }

        // GET: /Store/Details
        public ActionResult Details(int id)
        {
            var album = new Album { Title = "Album " + id };

            return View(album);
        }
       
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}