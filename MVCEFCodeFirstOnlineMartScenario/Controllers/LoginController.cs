using MVCEFCodeFirstOnlineMartScenario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEFCodeFirstOnlineMartScenario.Controllers
{
    public class LoginController : Controller
    {
        private AppDBContext db = new AppDBContext();
        // GET: Login
        public ActionResult Index()
        {
            ViewBag.UserTypeID = new SelectList(db.UserTypes, "UserTypeID", "UserTypeName");
            return View();
        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {

            ViewBag.QuId = new SelectList(db.SecurityQuestions, "QuId", "Question");
            ViewBag.UserTypeID = new SelectList(db.UserTypes.Where(u=>u.UserTypeID==2), "UserTypeID", "UserTypeName"); // where clause is used to restrict only user type create
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Login(User user)
        {
            User usr = db.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);

            if (user.Email == "admin@onlinemart.com" && user.Password == "admin@123")
            {
                return RedirectToAction("Index", "Users");
            }

            //User usr = db.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
            if (usr != null)
            {
                Session["UserId"] = usr.UserId;
                if (user.UserTypeID == 1)
                {
                    return RedirectToAction("Index", "Users");
                }
                else if (user.UserTypeID == 2)
                {
                    return RedirectToAction("Details", "Customer");

                }
                else if (user.UserTypeID == 4)
                {
                    return RedirectToAction("Index", "User");
                }



            }
            ViewData["Status"] = "Invalid user name or password!!";

            ViewBag.UserTypeID = new SelectList(db.UserTypes, "UserTypeID", "UserTypeName");
            return View("Index");

        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
