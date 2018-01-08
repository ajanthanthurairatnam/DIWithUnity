using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeReminder.Models.Classes;

namespace TimeReminder.Models.Interfaces
{
    public interface ITimeReminderUserService
    {
        IEnumerable<TimeReminderUser> TimeReminderUsers { get; set; }

        TimeReminderUser GetTimeReminderUser(int id);
        TimeReminderUser SaveTimeReminderUser(TimeReminderUser timeReminder);
        void DeleteTimeReminderUser(int id);
    }
}
