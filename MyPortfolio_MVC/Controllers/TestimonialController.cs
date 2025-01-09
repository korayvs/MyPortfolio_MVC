using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Collections.Specialized.BitVector32;

namespace MyPortfolio_MVC.Controllers
{
    public class TestimonialController : Controller
    {
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();
        public ActionResult Index()
        {
            var values = db.TblTestimonials.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTestimonial(TblTestimonial model, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null)
                {
                    var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    var saveLocation = currentDirectory + "images\\";
                    var fileName = Path.Combine(saveLocation, model.ImageFile.FileName);
                    model.ImageFile.SaveAs(fileName);
                    model.ImageUrl = "/images/" + model.ImageFile.FileName;
                }

                db.TblTestimonials.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult DeleteTestimonial(int id)
        {

            var delvalue = db.TblTestimonials.Find(id);
            db.TblTestimonials.Remove(delvalue);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var testimonial = db.TblTestimonials.Find(id);
            return View(testimonial);
        }

        [HttpPost]
        public ActionResult UpdateTestimonial(TblTestimonial model, HttpPostedFileBase ImageFile)
        {
            var value = db.TblTestimonials.Find(model.TestimonialId);
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null)
                {
                    var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    var saveLocation = currentDirectory + "images\\";
                    var fileName = Path.Combine(saveLocation, model.ImageFile.FileName);
                    model.ImageFile.SaveAs(fileName);
                    model.ImageUrl = "/images/" + model.ImageFile.FileName;
                }

                value.NameSurname = model.NameSurname;
                value.ImageUrl = model.ImageUrl;
                value.Title = model.Title;
                value.Comment = model.Comment;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}