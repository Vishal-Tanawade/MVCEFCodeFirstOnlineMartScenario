using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCEFCodeFirstOnlineMartScenario;
using MVCEFCodeFirstOnlineMartScenario.Models;

namespace MVCEFCodeFirstOnlineMartScenario.Controllers
{
    public class UsersController : Controller
    {
        private AppDBContext db = new AppDBContext();

        // GET: Users
        public ActionResult Index()
        {

            int? id = Convert.ToInt32(Session["UserId"]);
            if (id == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var users = db.Users.Include(u => u.SecurityQuestion).Include(u => u.UserType);
            return View(users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.QuId = new SelectList(db.SecurityQuestions, "QuId", "Question");
            ViewBag.UserTypeID = new SelectList(db.UserTypes, "UserTypeID", "UserTypeName");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,UserTypeID,FirstName,LastName,UserName,Dob,PhoneNo,Email,Password,QuId,Answer")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.QuId = new SelectList(db.SecurityQuestions, "QuId", "Question", user.QuId);
            ViewBag.UserTypeID = new SelectList(db.UserTypes, "UserTypeID", "UserTypeName", user.UserTypeID);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuId = new SelectList(db.SecurityQuestions, "QuId", "Question", user.QuId);
            ViewBag.UserTypeID = new SelectList(db.UserTypes, "UserTypeID", "UserTypeName", user.UserTypeID);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,UserTypeID,FirstName,LastName,UserName,Dob,PhoneNo,Email,Password,QuId,Answer")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QuId = new SelectList(db.SecurityQuestions, "QuId", "Question", user.QuId);
            ViewBag.UserTypeID = new SelectList(db.UserTypes, "UserTypeID", "UserTypeName", user.UserTypeID);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SignOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
