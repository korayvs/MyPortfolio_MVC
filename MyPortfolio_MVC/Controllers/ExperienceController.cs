using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio_MVC.Controllers
{
    public class ExperienceController : Controller
    {
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();
        public ActionResult Index()
        {
            var values = db.TblExperiences.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateExperience()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateExperience(TblExperience exp)
        {
            db.TblExperiences.Add(exp);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));             // nameof(Index) = ("Index")
        }

        public ActionResult DeleteExperience(int id)
        {
            var value = db.TblExperiences.Find(id);
            db.TblExperiences.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateExperience(int id)
        {
            var experience = db.TblExperiences.Find(id);
            return View(experience);
        }

        [HttpPost]
        public ActionResult UpdateExperience(TblExperience exp)
        {
            var value = db.TblExperiences.Find(exp.ExperienceId);
            value.CompanyName = exp.CompanyName;
            value.Description = exp.Description;
            value.StartDate = exp.StartDate;
            value.EndDate = exp.EndDate;
            value.Title = exp.Title;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}