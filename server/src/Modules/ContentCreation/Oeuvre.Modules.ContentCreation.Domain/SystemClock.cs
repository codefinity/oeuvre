using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.ContentCreation.Domain
{
    public static class SystemClock
    {
        private static DateTime? simulatedDateTime;

        public static DateTime Now
        {
            get
            {
                if (simulatedDateTime.HasValue)
                {
                    return simulatedDateTime.Value;
                }

                return DateTime.UtcNow;
            }
        }

        public static void Set(DateTime customDate) => simulatedDateTime = customDate;

        public static void Reset() => simulatedDateTime = null;
    }
}
