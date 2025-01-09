using MyPortfolio_MVC.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio_MVC.Controllers
{
    public class SocialMediaController : Controller
    {
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();
        public ActionResult Index()
        {
            var values = db.TblSocialMedias.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateSM()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSM(TblSocialMedia smmodel)
        {
            db.TblSocialMedias.Add(smmodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSM(int id)
        {
            var value = db.TblSocialMedias.Find(id);
            db.TblSocialMedias.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateSM(int id)
        {
            var socialMedia = db.TblSocialMedias.Find(id);
            return View(socialMedia);
        }

        [HttpPost]
        public ActionResult UpdateSM(TblSocialMedia model)
        {
            var value = db.TblSocialMedias.Find(model.SocialMediaId);
            value.Name = model.Name;
            value.Url = model.Url;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}