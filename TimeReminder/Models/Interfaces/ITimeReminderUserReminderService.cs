using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeReminder.Models.Classes;

namespace TimeReminder.Models.Interfaces
{
    public interface ITimeReminderUserReminderService
    {
        IEnumerable<TimeReminderUser> TimeReminderUsers();
        IEnumerable<TimeReminderUserReminder> GetReminders(int UserID);
        TimeReminderUserReminder GetReminder(int UserID,DateTime ReminderDate);
        TimeReminderUserReminder GetReminderByID(int id);
        TimeReminderUserReminder SaveMyReminder(TimeReminderUserReminder timeReminderUserReminder);
        void DeleteMyReminder(int id);
    }
}
