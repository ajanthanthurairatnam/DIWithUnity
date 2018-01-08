using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeReminder.Models.Classes;
using TimeReminder.Models.Interfaces;

namespace TimeReminder.Controllers
{
    public class TimeReminderUserReminderController : Controller
    {
        private ITimeReminderUserReminderService timeReminderUserReminderService;


        /// <summary>
        /// 
        /// </summary>
        public TimeReminderUserReminderController(ITimeReminderUserReminderService timeReminderUserReminderService)
        {
            this.timeReminderUserReminderService = timeReminderUserReminderService;
        }

        // GET: TimeReminderUserReminder
        public ActionResult Index()
        {
            var model = timeReminderUserReminderService.GetReminders(1);
            return View(model);
        }

        // GET: TimeReminderUserReminder/Details/5
        public ActionResult Details(int id)
        {
            var model = timeReminderUserReminderService.GetReminderByID(id);
            return View(model);
            
        }

        // GET: TimeReminderUserReminder/Create
        public ActionResult Create()
        {
            TimeReminderUserReminder timeReminderUserReminder = new TimeReminderUserReminder();
            timeReminderUserReminder.TimeReminderUsers = timeReminderUserReminderService.TimeReminderUsers();
            return View(timeReminderUserReminder);
        }

        // POST: TimeReminderUserReminder/Create
        [HttpPost]
        public ActionResult Create(TimeReminderUserReminder timeReminderUserReminder)
        {
            try
            {
                // TODO: Add insert logic here
                timeReminderUserReminder = timeReminderUserReminderService.SaveMyReminder(timeReminderUserReminder);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TimeReminderUserReminder/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                // TODO: Add insert logic here
                var model = timeReminderUserReminderService.GetReminderByID(id);
                model.TimeReminderUsers = timeReminderUserReminderService.TimeReminderUsers();
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        // POST: TimeReminderUserReminder/Edit/5
        [HttpPost]
        public ActionResult Edit(TimeReminderUserReminder timeReminderUserReminder)
        {
            try
            {
                // TODO: Add update logic here
                timeReminderUserReminder = timeReminderUserReminderService.SaveMyReminder(timeReminderUserReminder);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TimeReminderUserReminder/Delete/5
        public ActionResult Delete(int id)
        {
            var model = timeReminderUserReminderService.GetReminderByID(id);
            return View(model);
        }

        // POST: TimeReminderUserReminder/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                timeReminderUserReminderService.DeleteMyReminder(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
