using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation
{
    public static class DateTimeExpander
    {
        public static DateTime LastWeekMonday
        {
            get
            {
                DateTime lastMonday;
                DateTime today = DateTime.Today;
                lastMonday = today.AddDays(-7.0);
                while (lastMonday.DayOfWeek != DayOfWeek.Monday)
                {
                    lastMonday = lastMonday.AddDays(-1.0);
                }

                return lastMonday;
            }
        }

        public static DateTime LastSunday
        {
            get
            {
                return LastWeekMonday.AddDays(6);
            }
        }
    }
}
