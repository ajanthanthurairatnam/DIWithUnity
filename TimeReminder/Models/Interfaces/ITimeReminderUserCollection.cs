﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeReminder.Models.Classes;

namespace TimeReminder.Models.Interfaces
{
    public interface ITimeReminderUserCollection
    {
        IEnumerable<TimeReminderUser> TimeReminderUsers { get; set; }


    }
}