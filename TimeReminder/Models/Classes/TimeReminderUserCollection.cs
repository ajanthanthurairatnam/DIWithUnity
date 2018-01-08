using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimeReminder.Models.DataAccess;
using TimeReminder.Models.Interfaces;

namespace TimeReminder.Models.Classes
{
    public class TimeReminderUserCollection : ITimeReminderUserCollection
    {       
        public IEnumerable<TimeReminderUser> TimeReminderUsers { get; set; }

        public TimeReminderUserCollection()
        {
            using (var db = new ReminderDBEntities())
            {
                this.TimeReminderUsers = db.Users.Select(p => new TimeReminderUser { ID = p.ID, UserName = p.UserName }).ToList();
            }
        }
    }
}