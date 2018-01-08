using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeReminder.Models.Classes;

namespace TimeReminder.Models.Interfaces
{
   public interface ITimeReminderUserReminder
    {
        IEnumerable<TimeReminderUser> TimeReminderUsers { get; set; }
        int ID { get; set; }
        int UserID { get; set; }
        string Reminder { get; set; }
        DateTime ReminderDate { get; set; }
    }
}
