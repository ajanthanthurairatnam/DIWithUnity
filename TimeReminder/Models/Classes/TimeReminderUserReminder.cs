using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimeReminder.Models.DataAccess;
using TimeReminder.Models.Interfaces;

namespace TimeReminder.Models.Classes
{
    public class TimeReminderUserReminder : ITimeReminderUserReminder
    {
        public IEnumerable<TimeReminderUser> TimeReminderUsers { get; set; }      

        public int ID { get; set; }
        public int UserID { get; set; }
        public string Reminder { get; set; }
        public DateTime ReminderDate { get; set; }
    }
}