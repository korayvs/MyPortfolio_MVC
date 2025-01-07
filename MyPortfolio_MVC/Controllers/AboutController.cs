using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace MyPortfolio_MVC.Controllers
{
    public class AboutController : Controller
    {
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();
        public ActionResult Index()
        {
            var about = db.TblAbouts.ToList();
            return View(about);
        }

        [HttpGet]
        public ActionResult AboutUpdate(int id)
        {
            var about = db.TblAbouts.Find(id);
            return View(about);
        }

        [HttpPost]
        public ActionResult AboutUpdate(TblAbout model)
        {
            var value = db.TblAbouts.Find(model.AboutId);
            if (ModelState.IsValid)
            {
                //Image
                if (model.ImageFile != null)
                {
                    var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    var saveLocation = currentDirectory + "images\\";
                    var fileName = Path.Combine(saveLocation, model.ImageFile.FileName);
                    model.ImageFile.SaveAs(fileName);
                    model.ImageUrl = "/images/" + model.ImageFile.FileName;
                }
                //CV
                if (model.CvFile != null)
                {
                    var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    var cvSaveLocation = currentDirectory + "Cv\\";
                    if (!Directory.Exists(cvSaveLocation))
                    {
                        Directory.CreateDirectory(cvSaveLocation);
                    }
                    var cvFileName = Path.Combine(cvSaveLocation, model.CvFile.FileName);
                    model.CvFile.SaveAs(cvFileName);
                    model.CvUrl = "/Cv/" + model.CvFile.FileName; //CV'nin veri tabanına kaydetmesi
                }

                value.Title = model.Title;
                value.ImageUrl = model.ImageUrl;
                value.Discription = model.Discription;
                value.CvUrl = model.CvUrl;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}