using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCompounds.Extensions
{
    /// <summary>
    /// Extensions for the <see cref="DateTime"/> object.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Rounds a DateTime to the nearest amount represented by the TimeSpan.
        /// </summary>
        /// <param name="date">The date to round.</param>
        /// <param name="roundAmount">The amount to be rounded by.</param>
        /// <returns></returns>
        public static DateTime RoundUp(this DateTime date, TimeSpan roundAmount)
        {
            return new DateTime((date.Ticks + roundAmount.Ticks - 1) / roundAmount.Ticks * roundAmount.Ticks, date.Kind);
        }
    }
}
