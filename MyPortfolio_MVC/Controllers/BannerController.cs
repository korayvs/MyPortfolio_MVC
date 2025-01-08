using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio_MVC.Controllers
{
    public class BannerController : Controller
    {
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();
        public ActionResult Index()
        {
            var values = db.TblBanners.ToList();
            return View(values);
        }

        public ActionResult ShowBanner(int id)
        {
            var allBanners = db.TblBanners.ToList();

            foreach (var banners in allBanners)
            {
                banners.IsShown = false;
            }

            var selectedBanner = db.TblBanners.FirstOrDefault(x => x.Bannerid == id);

            if (selectedBanner != null)
            {
                selectedBanner.IsShown = true;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeleteBanner(int id)
        {
            var value = db.TblBanners.Find(id);

            if (value != null)
            {
                int bcount = db.TblBanners.Count();

                if (bcount <= 1)
                {
                    TempData["bannerDeleteError"] = "Son kalan banner silinemez.";
                    return RedirectToAction("Index");
                }

                db.TblBanners.Remove(value);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateBanner()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBanner(TblBanner banner)
        {
            if (ModelState.IsValid)
            {
                var allBanners = db.TblBanners.ToList();

                foreach (var existingBanner in allBanners)
                {
                    existingBanner.IsShown = false;
                }

                banner.IsShown = true;
                db.TblBanners.Add(banner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(banner);
        }
    }
}