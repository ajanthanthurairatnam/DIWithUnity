using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimeReminder.Models.Interfaces;
using TimeReminder.Models.DataAccess;

namespace TimeReminder.Models.Classes
{
    public class TimeReminderUser : ITimeReminderUser
    {
        public int ID { get; set; }
        public string UserName { get; set; }

    }
}