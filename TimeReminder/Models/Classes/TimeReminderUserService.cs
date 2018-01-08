using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimeReminder.Models.DataAccess;
using TimeReminder.Models.Interfaces;

namespace TimeReminder.Models.Classes
{
    public class TimeReminderUserService : ITimeReminderUserService
    {       
        public IEnumerable<TimeReminderUser> TimeReminderUsers { get; set; }

        public TimeReminderUserService()
        {
            using (var db = new ReminderDBEntities())
            {
                this.TimeReminderUsers = db.Users.Select(p => new TimeReminderUser { ID = p.ID, UserName = p.UserName }).ToList();
            }
        }

        public TimeReminderUser GetTimeReminderUser(int id)
        {
            TimeReminderUser timeReminderUser;
            using (var db = new ReminderDBEntities())
            {
                timeReminderUser = db.Users.Select(p => new TimeReminderUser { ID = p.ID, UserName = p.UserName }).FirstOrDefault();
            }
            return timeReminderUser;
        }

        public TimeReminderUser SaveTimeReminderUser(TimeReminderUser timeReminderUser)
        {
            if (timeReminderUser.ID == 0)
            {
              
                using (var db = new ReminderDBEntities())
                {
                    User user = new User() { UserName = timeReminderUser.UserName };
                    db.Users.Add(user);
                    db.SaveChanges();
                    timeReminderUser.ID = user.ID;
                }
            }
            else
            {
                using (var db = new ReminderDBEntities())
                {
                    var user = db.Users.SingleOrDefault(u => u.ID == timeReminderUser.ID);
                    if (user != null)
                    {
                        user.UserName = timeReminderUser.UserName;
                        db.SaveChanges();
                    }
                }
            }
            return timeReminderUser;
        }

      

        public void DeleteTimeReminderUser(int id)
        {
            using (var db = new ReminderDBEntities())
            {
                var result = db.Users.SingleOrDefault(u => u.ID == id);
                if (result != null)
                {
                    db.Users.Remove(result);
                    db.SaveChanges();
                }
            }
        }
    }
}