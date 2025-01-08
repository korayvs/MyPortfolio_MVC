using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio_MVC.Controllers
{
    public class ContactController : Controller
    {
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();
        public ActionResult Index()
        {
            var value = db.TblContacts.ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            var value = db.TblContacts.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateContact(TblContact cntct)
        {
            var value = db.TblContacts.Find(cntct.ContactId);

            if (ModelState.IsValid)
            {
                value.Phone = cntct.Phone;
                value.Email = cntct.Email;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(value);
        }
    }
}