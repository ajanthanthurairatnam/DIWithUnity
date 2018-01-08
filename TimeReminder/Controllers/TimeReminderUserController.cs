using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeReminder.Models.Interfaces;
using TimeReminder.Models.Classes;


namespace TimeReminder.Controllers
{
    public class TimeReminderUserController : Controller
    {
        private ITimeReminderUserService timeReminderUserService;
       

        /// <summary>
        /// 
        /// </summary>
        public TimeReminderUserController(ITimeReminderUserService timeReminderUserService)
        {            
                this.timeReminderUserService = timeReminderUserService;             
        }    

        // GET: TimeReminderUser
        public ActionResult Index()
        {
            var model = timeReminderUserService.TimeReminderUsers;
            return View(model);
        }

        // GET: TimeReminderUser/Details/5
        public ActionResult Details(int id)
        {
            var model = timeReminderUserService.GetTimeReminderUser(id);
            return View(model);
        }

        // GET: TimeReminderUser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TimeReminderUser/Create
        [HttpPost]
        public ActionResult Create(TimeReminderUser timeReminderUser)
        {
            try
            {
                // TODO: Add insert logic here
                timeReminderUser = timeReminderUserService.SaveTimeReminderUser(timeReminderUser);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TimeReminderUser/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                // TODO: Add insert logic here
                var model = timeReminderUserService.GetTimeReminderUser(id);
                return View(model);
            }
            catch
            {
                return View();
            }           
        }

        // POST: TimeReminderUser/Edit/5
        [HttpPost]
        public ActionResult Edit(TimeReminderUser timeReminderUser)
        {
            try
            {
                // TODO: Add update logic here
                timeReminderUser = timeReminderUserService.SaveTimeReminderUser(timeReminderUser);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TimeReminderUser/Delete/5
        public ActionResult Delete(int id)
        {
            var model = timeReminderUserService.GetTimeReminderUser(id);
            return View(model);
        }

        // POST: TimeReminderUser/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                timeReminderUserService.DeleteTimeReminderUser(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
