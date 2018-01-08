using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeReminder.Models.Interfaces
{
    public interface ITimeReminderUser
    {
        int ID { get; set; }
        string UserName { get; set; }

    }
}
