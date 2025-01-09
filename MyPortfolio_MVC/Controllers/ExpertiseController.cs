﻿using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio_MVC.Controllers
{
    public class ExpertiseController : Controller
    {
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();
        public ActionResult Index()
        {
            var value = db.TblExpertises.ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult CreateExpertise()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateExpertise(TblExpertis model)
        {
            db.TblExpertises.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateExpertise(int id)
        {
            var value = db.TblExpertises.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateExpertise(TblExpertis model)
        {
            var value = db.TblExpertises.Find(model.ExpertiseId);
            value.Title = model.Title;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteExpertise(int id)
        {
            var value = db.TblExpertises.Find(id);
            db.TblExpertises.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}