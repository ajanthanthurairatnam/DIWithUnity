using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TimeReminder.Models.DataAccess;

namespace TimeReminder.Controllers
{
    public class UserRemindersController : Controller
    {
        private ReminderDBEntities db = new ReminderDBEntities();

        // GET: UserReminders
        public ActionResult Index()
        {
            var userReminders = db.UserReminders.Include(u => u.User);
            return View(userReminders.ToList());
        }

        // GET: UserReminders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserReminder userReminder = db.UserReminders.Find(id);
            if (userReminder == null)
            {
                return HttpNotFound();
            }
            return View(userReminder);
        }

        // GET: UserReminders/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Users, "ID", "UserName");
            return View();
        }

        // POST: UserReminders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserID,Reminder,ReminderDate")] UserReminder userReminder)
        {
            if (ModelState.IsValid)
            {
                db.UserReminders.Add(userReminder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Users, "ID", "UserName", userReminder.UserID);
            return View(userReminder);
        }

        // GET: UserReminders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserReminder userReminder = db.UserReminders.Find(id);
            if (userReminder == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Users, "ID", "UserName", userReminder.UserID);
            return View(userReminder);
        }

        // POST: UserReminders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserID,Reminder,ReminderDate")] UserReminder userReminder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userReminder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Users, "ID", "UserName", userReminder.UserID);
            return View(userReminder);
        }

        // GET: UserReminders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserReminder userReminder = db.UserReminders.Find(id);
            if (userReminder == null)
            {
                return HttpNotFound();
            }
            return View(userReminder);
        }

        // POST: UserReminders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserReminder userReminder = db.UserReminders.Find(id);
            db.UserReminders.Remove(userReminder);
            db.SaveChanges();
            return RedirectToAction("Index");
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
