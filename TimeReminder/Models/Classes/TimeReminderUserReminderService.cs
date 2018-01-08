using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimeReminder.Models.DataAccess;
using TimeReminder.Models.Interfaces;

namespace TimeReminder.Models.Classes
{
    public class TimeReminderUserReminderService : ITimeReminderUserReminderService
    {

        public IEnumerable<TimeReminderUser> TimeReminderUsers()
        {
            IEnumerable<TimeReminderUser> TimeReminderUsers;
            using (var db = new ReminderDBEntities())
            {
                TimeReminderUsers = db.Users.Select(p => new TimeReminderUser { ID = p.ID, UserName = p.UserName }).ToList();
            }

            return TimeReminderUsers;
        }

        public void DeleteMyReminder(int id)
        {
            using (var db = new ReminderDBEntities())
            {
                var result = db.UserReminders.SingleOrDefault(u => u.ID == id);
                if (result != null)
                {
                    db.UserReminders.Remove(result);
                    db.SaveChanges();
                }
            }
        }

        public IEnumerable<TimeReminderUserReminder> GetReminders(int UserID)
        {
            IEnumerable<TimeReminderUserReminder> MyReminders;
            using (var db = new ReminderDBEntities())
            {
                MyReminders = db.UserReminders.Select(
                    p => new TimeReminderUserReminder { ID = p.ID, Reminder = p.Reminder,ReminderDate=p.ReminderDate,
                    UserID =p.UserID,TimeReminderUsers= db.Users.Select
                    (e => new TimeReminderUser 
                    {
                        ID = e.ID,
                        UserName =e.UserName
                    }
                    )
                    }).Where(p=>p.UserID==UserID).ToList();
               
            }
            return MyReminders;
        }

        public TimeReminderUserReminder GetReminder(int UserID, DateTime ReminderDate)
        {
            TimeReminderUserReminder Reminder;
            using (var db = new ReminderDBEntities())
            {
                Reminder = db.UserReminders.Select(
                    p => new TimeReminderUserReminder
                    {
                        ID = p.ID,
                        Reminder = p.Reminder,
                        ReminderDate = p.ReminderDate,
                        UserID = p.UserID,
                        TimeReminderUsers = db.Users.Select
                    (e => new TimeReminderUser
                    {
                        ID = e.ID,
                        UserName = e.UserName
                    }
                    )
                    }).Where(p => p.UserID == UserID && p.ReminderDate==ReminderDate).FirstOrDefault();

            }
            return Reminder;
        }

        public TimeReminderUserReminder GetReminderByID(int id)
        {
            TimeReminderUserReminder Reminder;
            using (var db = new ReminderDBEntities())
            {
                Reminder = db.UserReminders.Select(
                    p => new TimeReminderUserReminder
                    {
                        ID = p.ID,
                        Reminder = p.Reminder,
                        ReminderDate = p.ReminderDate,
                        UserID = p.UserID,
                        TimeReminderUsers = db.Users.Select
                    (e => new TimeReminderUser
                    {
                        ID = e.ID,
                        UserName = e.UserName
                    }
                    )
                    }).Where(p => p.ID == id).FirstOrDefault();

            }
            return Reminder;
        }

        public TimeReminderUserReminder SaveMyReminder(TimeReminderUserReminder timeReminderUserReminder)
        {
            if (timeReminderUserReminder.ID == 0)
            {

                using (var db = new ReminderDBEntities())
                {
                    UserReminder userreminder = new UserReminder() { Reminder = timeReminderUserReminder.Reminder,ReminderDate= timeReminderUserReminder.ReminderDate, UserID= timeReminderUserReminder.UserID};
                    db.UserReminders.Add(userreminder);
                    db.SaveChanges();
                    timeReminderUserReminder.ID = userreminder.ID;
                }
            }
            else
            {
                using (var db = new ReminderDBEntities())
                {
                    var userReminder = db.UserReminders.SingleOrDefault(u => u.ID == timeReminderUserReminder.ID);
                    if (userReminder != null)
                    {
                        userReminder.Reminder = timeReminderUserReminder.Reminder;
                        userReminder.ReminderDate = timeReminderUserReminder.ReminderDate;
                        userReminder.UserID = timeReminderUserReminder.UserID;
                        db.SaveChanges();
                    }
                }
            }
            return timeReminderUserReminder;
        }
    }
}