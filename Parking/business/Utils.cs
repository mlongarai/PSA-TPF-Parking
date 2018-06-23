using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking.business
{
    public static class Utils
    {
        public static DateTime alterarHora(DateTime dateTime, int hours, int minutes, int seconds)
        {
            return new DateTime(
                dateTime.Year,
                dateTime.Month,
                dateTime.Day,
                hours,
                minutes,
                seconds,
                dateTime.Millisecond,
                dateTime.Kind);
        }
    }
}
